<template>
    <div class="data-view">
        <TitleBar :title="title" v-if="(title || '') != ''" />
        <div class="search-bar" style="height:100px;" @blur="showColumnList = false">
            <div class="input-group mb-3">
                <div style="width: 600px !important;  float: left;">
                    <div style="width: 300px !important; float: left;">
                        Date Range Initial:
                        <VueDatePicker v-model="date" locale="en" cancelText="Cancel" selectText="Select"
                                       :min-date="minDateIlk" :max-date="maxDateIlk" prevent-min-max-navigation />
                    </div>
                    <div style="width: 300px !important; float: left;">
                        Date Range Last:
                        <VueDatePicker v-model="dateSon" locale="en" cancelText="Cancel" selectText="Select"
                                       :min-date="minDateSon" :max-date="maxDateSon" prevent-min-max-navigation />
                    </div>
                </div>
                &nbsp;&nbsp;
                <button class="button button2" style="height: 35px !important; margin-top: 25px;" @click="emitEvent">
                    Send Selected Date
                </button>
                &nbsp;&nbsp; <input style="height: 35px !important; margin-top: 25px;" placeholder="Search by Flight No"
                                    :value="keywords" class="form-control" @keyup="queryForKeywords">
                &nbsp;&nbsp; <input style="height: 35px !important; margin-top: 25px;"
                                    placeholder="Search by Airport Arrival" :value="keywordsArr" class="form-control"
                                    @keyup="queryForKeywordsDown">
                &nbsp;&nbsp; <button class="button button2" style="height: 35px !important; margin-top: 25px;"
                                     @click="clearquery">
                    Clear Search
                </button>
            </div>
        </div>
        <div class="scroll scroll-color-auto"
             style="height: 485px !important; width: 99.8%; overflow-y: scroll; scrollbar-width: 20px;">
            <!-- Data Table -->
            <table style="width:100%;" v-if="showTableList">
                <thead>
                    <tr class="header-row" style="position: sticky; z-index: 100;top: 0;">
                        <td v-if="showIndexColumn">#</td>
                        <HeaderColumn v-for="column in columnList"
                                      :key="'header-' + (column.fieldName || column.columnName || column.data?.customComponentName)"
                                      :column="column"></HeaderColumn>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(row, index) in pageData" :key="index" class="data-row">
                        <td v-if="showIndexColumn">{{ Number(1 + index) }}</td> <!--Number(startRowIndex) -->
                        <td v-for="column in columnList"
                            :key="'' + index + '-' + (column.fieldName || column.columnName || column.data?.customComponentName)">
                            {{ row[column.fieldName] }}
                        </td>
                    </tr>
                </tbody>
            </table>
            <!-- Data Table End -->
            <div style="clear: both; padding-top: 30px!important; float: left; text-align: center;width: 100%;">
                <span class="h2" v-if="!showTableList">{{ state.messageTop }}</span>
            </div>
        </div>

        <!-- Pager.vue -->
        <Pager v-if="showPager" :pagerType="innerPagerType" @update:pagerType="updatePagerType" :pageSizes="pageSizes"
               v-model:pageSize="dataService.pageSize.value" v-model:pageIndex="dataService.pageIndex.value"
               :totalRowCount="dataService.totalRowCount" :showPagerSelector="showPagerSelector"
               :totalShowRowCount="totalShowRowCount" />
    </div>
</template>

<!-- v-model -->
<script lang="ts" setup>

import { defineProps, PropType, defineEmits, onMounted, ref, reactive } from "vue";
import { ColumnType, PagerType, DataRow, FilterItem as FilterItemData } from './types';
import HeaderColumn from "./HeaderColumn.vue";
import Pager from "./Pager.vue";
import TitleBar from "./TitleBar.vue";
import { DataService } from './data-service';
import axios from 'axios';

//Seacrh Items
const date = ref(new Date('2023-11-15'));

const dateSon = ref(new Date('2023-11-15'));

const minDateIlk = new Date('2023-11-15');

const maxDateIlk = new Date('2024-05-12');

const minDateSon = new Date('2023-11-15');

const maxDateSon = new Date('2024-05-12');

const showColumnList = ref(false);

const showTableList = ref(false);

const keywords = ref("");

const keywordsArr = ref("");

function queryForKeywords(event) {
    const value = event.target.value;
    keywords.value = value;

    pageData.value = tempData.value;

    if (keywords.value.length > 1 && keywordsArr.value.length > 1) {
        pageData.value = pageData.value.filter(
            ({ havaAlaniVaris, ucusNo }) => [havaAlaniVaris, ucusNo]
                .some(val => val.toLowerCase().includes(keywords.value.toLowerCase()) || val.toLowerCase().includes(keywordsArr.value.toLowerCase())
                ));
    }
    else if (keywords.value.length > 1) {
        pageData.value = pageData.value.filter(
            ({ ucusNo }) => [ucusNo]
                .some(val => val.toLowerCase().includes(keywords.value.toLowerCase())
                ));
    }
    else if (keywordsArr.value.length > 1) {
        pageData.value = pageData.value.filter(
            ({ havaAlaniVaris }) => [havaAlaniVaris]
                .some(val => val.toLowerCase().includes(keywordsArr.value.toLowerCase())
                ));
    }
    else {
        pageData.value = tempData.value;
    }
}

function queryForKeywordsDown(event) {
    const value = event.target.value;
    keywordsArr.value = value;

    pageData.value = tempData.value;

    if (keywords.value.length > 1 && keywordsArr.value.length > 1) {
        pageData.value = pageData.value.filter(
            ({ havaAlaniVaris, ucusNo }) => [havaAlaniVaris, ucusNo]
                .some(val => val.toLowerCase().includes(keywords.value.toLowerCase()) || val.toLowerCase().includes(keywordsArr.value.toLowerCase())
                ));
    }
    else if (keywords.value.length > 1) {
        pageData.value = pageData.value.filter(
            ({ ucusNo }) => [ucusNo]
                .some(val => val.toLowerCase().includes(keywords.value.toLowerCase())
                ));
    }
    else if (keywordsArr.value.length > 1) {
        pageData.value = pageData.value.filter(
            ({ havaAlaniVaris }) => [havaAlaniVaris]
                .some(val => val.toLowerCase().includes(keywordsArr.value.toLowerCase())
                ));
    }
    else {
        pageData.value = tempData.value;
    }

}

const emitEvent = () => {
    if (date.value <= dateSon.value) {
        const searchURL = new URL("https://127.0.0.1:5173/");
        searchURL.searchParams.set('firstDate', date.value.toLocaleDateString());
        searchURL.searchParams.set('lastDate', dateSon.value.toLocaleDateString());

        window.history.pushState({}, '', searchURL);
        window.location.reload();
    }
    else {
        alert("The first date selected cannot be smaller than the last date!");
    }
}

const clearquery = () => {
    pageData.value = tempData.value;
    keywords.value = "";
    keywordsArr.value = "";
}

const filters = ref<FilterItemData[]>([]);

const columnClicked = (column: ColumnType) => {
    filters.value.push({ column });
    showColumnList.value = false;
    date.value = new Date('2023-11-15');
    dateSon.value = new Date('2023-11-15');
}

//Search Items End

const columindex = ref(1);

function getSlotName(column: ColumnType): string {
    columindex.value++;
    return "column_" + column.columnName;
}

columindex.value = 1;

let totalShowRowCount = ref(0);

let messageTop = ref("Progress ...");

    //link to the web service from which data is retrieved
const dataURL = ref("http://localhost:6001/api/Denetci?first=2023-11-15&last=2023-11-15&sayfaAl=0&listeAl=0");

let pageData = ref<DataRow[]>([]);

    //Variable required for subsequent resetting of data
let tempData: Record<string, any> = ref([{}]);

const state = reactive({
	totalShowRowCount,messageTop
});

    //Data retrieval function
const getAllData = async () => {
    try {
        const resp = await axios.get(
            dataURL.value,
            {
                headers: {
                    'Accept-Encoding': 'application/json',
                }
            }
        );

        tempData.value = resp.data;
        state.totalShowRowCount = resp.data.length;
        pageData.value = tempData.value;

        if (state.totalShowRowCount > 0) {
            showTableList.value = true;
            state.messageTop="";
        }
        else {
            showTableList.value = false;
            state.messageTop="After all, There is no Data";
        }

    } catch (err) {
        pageData.value.splice(0);
        console.error(err);
        showTableList.value = false;
        state.messageTop="After all, There is no Data";
    }
};

let localpageSizes = ref(0);

let localPageLine = ref(0);

let innerPagerType: PagerType = PagerType.SimplePager;

    //necessary proparties
const props = defineProps({

    columnList: { type: Array as PropType<ColumnType[]>, required: true },

    title: { required: false, type: String, default: () => '' },

    showSearchBar: { required: true, type: Boolean, default: () => true },

    showPager: { required: false, type: Boolean, default: () => true },

    showPagerSelector: { required: false, type: Boolean, default: () => true },

    pagerType: { required: false, type: Number, default: () => PagerType.SimplePager },

    pageSizes: { required: false, type: Array as PropType<number[]>, default: () => [1, 10, 15, 18] },

    showIndexColumn: { type: Boolean, required: false, default: () => true },

});

    //the main function that runs the page
onMounted(() => {
    setQueryStringDefaults(); //retrieves elements from a page query
    getAllData();
   
    innerPagerType = props.pagerType;

    refresh();
})

//set data service
const dataService: DataService = new DataService(tempData.value);

const refresh = () => {

    if (localpageSizes.value != 0) {
        pageData.value = dataService.getPageData(Number(localpageSizes.value), totalPageIndex());
    }
    else {
        pageData.value = dataService.getPageData(0, totalPageIndex());
    }

    localPageLine.value = totalPageIndex();
    localpageSizes.value = dataService.pageSize.value;
}

//Paging Functions 
let totalPageCount = (): number => {

    if (Number(localpageSizes.value) > 0) {
        return Math.ceil(180 / Number(localpageSizes.value));
    }
    return 0;
}

let totalPageIndex = (): number => {

    if (Number(localpageSizes.value) > 1 && localPageLine.value > totalPageCount()) {
        return Math.floor(localPageLine.value / Number(localpageSizes.value));
    }
    else if (Number(localpageSizes.value) == 10 && localPageLine.value < totalPageCount()) {
        return localPageLine.value;
    }
    else {
        return localPageLine.value;
    }

}

const startRowIndex = (type: number): number => {
    return (dataService.pageIndex.value - 1) * dataService.pageSize.value + 1;
    }
    //Paging Functions End

const dataSourceChanged = (newDataSource: DataRow[]) => {
    if (dataService.dataSource !== newDataSource) {
        dataService.dataSource = newDataSource;
    }
    refresh();
}


const pageSizeChanged = () => {
    refresh();
}


const pageIndexChanged = () => {
    refresh();
}

const pagerTypeChanged = (pagerType: PagerType) => {
    innerPagerType = pagerType;
}


const emit = defineEmits(
    ["update:pagerType"]
);

const updatePagerType = (newPagerType: PagerType) => {
    innerPagerType = newPagerType;
    emit("update:pagerType", newPagerType);
}

    //retrieves elements from a page query
const setQueryStringDefaults = () => {
    let queryString = window.location.search;
    let urlParams = new URLSearchParams(queryString);
    let addUrl = "http://localhost:6001/api/Denetci";
    let denetle = "";
    const retval = ref(false);
    const total = ref(0);

    if (urlParams.has('pageSizes')) {
        localpageSizes.value = Number(String(urlParams.get('pageSizes')));
        if (!retval.value) {
            denetle += "?getList=" + localpageSizes.value;
            retval.value = true;
        }
        else {
            denetle += "&getList=" + localpageSizes.value;
        }
        total.value++;
    }
    else {
        if (!retval.value) {
            denetle += "?getList=0";
            retval.value = true;
        }
        else {
            denetle += "&getList=0";
        }
    }

    if (urlParams.has('pageIndex')) {
        localPageLine.value = Number(urlParams.get('pageIndex'));
        if (!retval.value) {
            denetle += "?getPageIndex=" + localPageLine.value;
            retval.value = true;
        }
        else {
            denetle += "&getPageIndex=" + localPageLine.value;
        }
        total.value++;
    }
    else {
        if (!retval.value) {
            denetle += "?getPageIndex=0";
            retval.value = true;
        }
        else {
            denetle += "&getPageIndex=0";
        }
    }

    if (urlParams.has('firstDate')) {
        if (!retval.value) {
            denetle += "?first=" + urlParams.get('firstDate');
            retval.value = true;
        }
        else {
            denetle += "&first=" + urlParams.get('firstDate');
        }
        total.value++;
    }
    else {
        if (!retval.value) {
            denetle += "?first=2023-11-15";
            retval.value = true;
        }
        else {
            denetle += "&first=2023-11-15";
        }
    }

    if (urlParams.has('lastDate')) {
        if (!retval.value) {
            denetle += "?last=" + urlParams.get('lastDate');
            retval.value = true;
        }
        else {
            denetle += "&last=" + urlParams.get('lastDate');
        }
        total.value++;
    }
    else {
        if (!retval.value) {
            denetle += "?last=2023-11-15";
            retval.value = true;
        }
        else {
            denetle += "&last=2023-11-15";
        }
    }

    if (total.value > 0)
        dataURL.value = addUrl + denetle;

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.button {
    background-color: #4CAF50;
    /* yesil */
    border: none;
    color: white;
    padding: 0px 14px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 4px 2px;
    cursor: pointer;
}

.button1 {
    background-color: white;
    /*buton ic renk */
    color: black;
    /*yazi rengi */
    border: 2px
        /* cizgi kalinligi */
        solid #4CAF50;
    /*cizgi rengi */
}

.button2 {
    background-color: white;
    /*buton ic renk */
    color: black;
    /*yazi rengi */
    border: 2px
        /* cizgi kalinligi */
        solid #008CBA;
    /*cizgi rengi */
}

.search-bar {
    padding: 5px;
    background-color: #eeeeee;
    color: black;
    text-align: left;

    input[type=text] {
        margin-right: 5px;
    }
}

.scroll {
    width: 20px;
    border: 1px solid grey;
    overflow: scroll;
    display: inline-block;
}

.scroll-color-auto {
    scrollbar-color: auto;
}

.scroll-color-colors {
    scrollbar-color: orange lightyellow;
}

.data-view {

    tr.header-row {
        background-color: #ddd;
    }

    tr.data-row {
        background-color: #eeeeee;
        cursor: pointer;

        &:nth-child(odd) {
            background-color: #fff;
        }

        &:hover {
            background-color: #ccc;
            color: forestgreen;
        }
    }
}</style>
