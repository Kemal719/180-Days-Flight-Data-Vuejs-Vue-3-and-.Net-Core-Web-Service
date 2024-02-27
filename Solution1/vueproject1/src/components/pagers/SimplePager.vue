<template>
    <div class="simple-pager">
        <button v-if="pageIndex != 1" @click="pageIndexChanged(1)">
            First
        </button>
        <button v-if="pageIndex != 1" @click="pageIndexChanged(pageIndex - 1)">
            Previous
        </button>
        <button v-for="item in totalPageCount" :key="item" @click="pageIndexChanged(item)" :disabled="item == pageIndex">
            {{ item }}
        </button>
        <button v-if="pageIndex != totalPageCount" @click="pageIndexChanged(pageIndex + 1)">
            Next
        </button>
        <button v-if="pageIndex != totalPageCount" @click="pageIndexChanged(totalPageCount)">
            Last
        </button>
    </div>
</template>

<script lang="ts" setup>
    import { defineProps, PropType, defineEmits } from "vue";

    //necessary proparties
    const props = defineProps({

        pageIndex: { type: Number, required: true, default: () => 1 },

        pageSize: { type: Number, required: false, default: () => 1 },

        totalPageCount: { required: true, type: Number }
    });

    const emit = defineEmits(["update:pageIndex"]);

    const pageIndexChanged = (newPageIndex: number) => {
        emit("update:pageIndex", newPageIndex);

        const searchURL = new URL(window.location.href);
        searchURL.searchParams.set('pageSizes', Number(props.pageSize).toString());
        searchURL.searchParams.set('pageIndex', newPageIndex.toString());

        window.history.pushState({}, '', searchURL);
        window.location.reload();
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    .simple-pager {
        float: right;
    }
</style>
