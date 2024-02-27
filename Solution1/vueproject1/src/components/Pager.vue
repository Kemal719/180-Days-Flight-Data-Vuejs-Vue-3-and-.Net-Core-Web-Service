<template>
	<div class="pager">
		<div class="pager-left">
			<span>
				Show
				<select :value="localpageSizes" @input="emitUpdatePageSize">
					<option v-for="item in pageSizes" :key="item" :value="item">{{ item }}</option>
				</select>
				Days.
			</span>
			<span>Showing {{ startRowIndex() == 0 ? 1 : startRowIndex() }} to {{ finishRowIndex() }} of {{ totalRowCount }}
				Days</span>
			<br />
			<span>Showing {{ totalShowRowCount }} entries</span>
		</div>
		<div class="pager-right">
			<PagerSelector v-if="showPagerSelector" :pagerType="pagerType" @update:pagerType="pagerTypeChanged" />
			<SimplePager v-if="pagerType == 0" :pageIndex="localPageLine" :pageSize="localpageSizes"
				@update:pageIndex="pageIndexChanged" :totalPageCount="totalPageCount()" />

			<div class="clear"></div>
		</div>
		<div class="clear"></div>
	</div>
</template>

<script lang="ts" setup>
import { defineProps, PropType, defineEmits, ref, reactive } from "vue";
import SimplePager from './pagers/SimplePager.vue';
import { PagerType } from './types';

    //necessary proparties
const props = defineProps({

	pagerType: { type: Number, required: false, default: () => PagerType.SimplePager },

	customPagerComponentName: { required: false, type: String, default: () => "" },

	showPagerSelector: { required: false, type: Boolean, default: () => true },

	pageSizes: { required: false, type: Array as PropType<number[]> },

	pageSize: { type: Number, required: false, default: () => 1 },

	pageIndex: { type: Number, required: true, default: () => 1 },

	totalRowCount: { type: Number, required: true, default: () => 180 },

	totalShowRowCount: { type: Number, required: true, default: () => 0 }
});

const emits = defineEmits(
	["update:pageIndex", "update:pagerType", "update:pageSize"]
);

const pageIndexChanged = (newPageIndex: number) => {
	// emty
}

const pagerTypeChanged = (newPageType: PagerType) => {
	// emty
}

let pagerComponent = (): string => {
	switch (props.pagerType) {
		case PagerType.SimplePager:
			return "SimplePager";

		case PagerType.Custom:
			return props.customPagerComponentName;

		default:
			return "SimplePager";
	}
}

let localpageSizes = ref(1);
let localPageLine = ref(1);

const newPageIndex = ref(0);
const state = reactive({
	newPageIndex,localpageSizes,localPageLine
})

    //retrieves elements from a page query
const setQueryStringDefaults = () => {
	let queryString = window.location.search;
	let urlParams = new URLSearchParams(queryString);

	if (urlParams.has('pageSizes')) {
		state.localpageSizes = Number(String(urlParams.get('pageSizes')));
	}
	else {
		state.localpageSizes = 1;
	}

	if (urlParams.has('pageIndex')) {
		state.localPageLine = Number(urlParams.get('pageIndex'));
	}
	else {
		state.localPageLine = 1;
	}
}

setQueryStringDefaults();

    //Paging Functions 
let totalPageCount = (): number => {

	if (props.totalRowCount > 0 && state.localpageSizes > 0) {
		return Math.ceil(props.totalRowCount / state.localpageSizes);
	}
	return 0;
}

let totalPageIndex = (): number => {
	if (state.localPageLine > state.localpageSizes) {
		return Math.floor(state.localPageLine / state.localpageSizes);
	}
	else if ((state.localpageSizes) > 1 && (state.localPageLine > totalPageCount())) {
		return Math.floor(state.localPageLine / state.localpageSizes);
	}
	else if (state.localpageSizes == 10 && (state.localPageLine < totalPageCount())) {
		return state.localPageLine;
	}
	else {
		return state.localPageLine;
	}
}

const startRowIndex = (): number => {
	if (state.localPageLine > state.localpageSizes) {
		return Math.floor(state.localPageLine * state.localpageSizes);
	}
	else if ((state.localpageSizes) > 1 && (state.localPageLine > totalPageCount())) {
		return Math.floor(state.localPageLine / state.localpageSizes);
	}
	else if (state.localpageSizes == 10 && (state.localPageLine < totalPageCount())) {
		return Number((state.localPageLine - 1) * state.localpageSizes);
	}
	else {
		return Number((state.localPageLine - 1) * state.localpageSizes);
	}
}

const finishRowIndex = (): number => {
	const ret = Number(startRowIndex() + state.localpageSizes);
	return ret < props.totalRowCount ? ret : props.totalRowCount;
}

const emitUpdatePageSize = (event: Event) => {
	if (event && event.target) {

		emits('update:pageSize', Number((event.target as any).value));
        const searchURL = new URL("https://127.0.0.1:5173/");
		searchURL.searchParams.set('pageSizes', Number((event.target as any).value).toString());

		state.localpageSizes=Number((event.target as any).value);
		state.newPageIndex = totalPageIndex()<=0?1:totalPageIndex();
		searchURL.searchParams.set('pageIndex', state.newPageIndex.toString());

		console.log("Page Size: " + searchURL);
        //history.replaceState(null, null, window.location.pathname + "your thing here")
		window.history.pushState({}, '', searchURL);
		window.location.reload();
	}
}
    //Paging Functions End
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.pager {
	margin: 5px 0;
	padding: 10px 10px;
	background-color: blue;
	color: white;
	text-align: left;

	.pager-left {
		float: left;
		width: 30%;
		text-align: left;
	}

	.pager-right {
		float: left;
		width: 70%;
		text-align: right;
	}

	.clear {
		clear: both;
	}
}
</style>
