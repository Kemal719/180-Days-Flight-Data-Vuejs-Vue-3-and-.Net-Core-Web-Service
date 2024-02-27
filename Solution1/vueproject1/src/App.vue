<template>
    <div id="app">
        <DataView :columnList="columns"  title="180-Day Sabiha Gökçen Airport Flight Information Screen" showSearchBar showPager
            :showPagerSelector="false" :pagerType="0">
        </DataView>
    </div>
</template>

<script lang="ts" setup>
import DataView from "./components/DataView.vue";
import { AlignType, ColumnDataTypeEnum, ColumnType, DataRow } from './components/types';

//variable where the type of incoming data is entered
const columns: ColumnType[] = [
    {
        fieldName: "id",
        title: "ID",
        data: { type: ColumnDataTypeEnum.Number },
    },
    {
        fieldName: "havaAlaniAdi",
        title: "Airport Name",
        header: { align: AlignType.Left },
        data: { align: AlignType.Left },
    },
    {
        fieldName: "havaAlaniVaris",
        title: "Airport Arrival",
        data: { type: ColumnDataTypeEnum.Text },
    },
    {
        fieldName: "kalkisSaati",
        title: "Departure Time",
        data: {
            type: ColumnDataTypeEnum.DateTime,
            dateTimeColumn: {
                importFormat: 'YYYY/MM/DD',
                exportFormat: 'MM/DD/YYYY',
            },
        },
    },
    {
        fieldName: "varisSaati",
        title: "Arrival Time",
        data: {
            type: ColumnDataTypeEnum.DateTime,
            dateTimeColumn: {
                importFormat: 'YYYY/MM/DD',
                exportFormat: 'MM/DD/YYYY',
            },
        },
    },
    {
        fieldName: "havaYoluSirketi",
        title: "Airline Company",
        data: { type: ColumnDataTypeEnum.Text },
    },
    {
        fieldName: "ucusNo",
        title: "Flight No.",
        data: { type: ColumnDataTypeEnum.Text },
    },
    {
        fieldName: "ucusDurumu",
        title: "Flight Status",
        data: { type: ColumnDataTypeEnum.Boolean },
    },
    {
        fieldName: "tarih",
        title: "Date",
        data: {
            type: ColumnDataTypeEnum.DateTime,
            dateTimeColumn: {
                importFormat: 'YYYY/MM/DD',
                exportFormat: 'MM/DD/YYYY',
            },
        },
    }
];

</script>

<style lang="scss">
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
}
</style>
