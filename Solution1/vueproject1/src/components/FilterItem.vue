<template>
    <div class="filter_item_container" tabindex="1" @click="focus" contenteditable="false">
        {{ filter.column.title }}
    </div>
</template>

<script lang="ts" setup>
import { defineProps, PropType } from "vue";
import { FilterItem as FilterItemData } from './types';


const props = defineProps({

    filter: { type: Object as PropType<FilterItemData>, required: true }

});

const focus = (e: Event) => {
    //debugger;
    e.stopPropagation();
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.filter_item_container {
    display: inline-block;
    border: 1px solid black;
    border-radius: 15px;
    padding: 2px 10px;
    margin: 0 5px;
    -webkit-box-shadow: 3px 3px 15px -2px #000000;
    box-shadow: 3px 3px 15px -2px #000000;

    &:hover {
        -webkit-box-shadow: 3px 3px 15px -8px #000000;
        box-shadow: 3px 3px 15px -8px #000000;
    }
}
</style>
