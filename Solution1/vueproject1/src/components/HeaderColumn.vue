<template>
    <th :class="headClass">
        {{ column.title }}
    </th>
</template>

<script lang="ts" setup>
import { defineProps, PropType } from "vue";
import { ColumnType, AlignType } from './types';
import { ConvertAlignTypeToString } from './functions';

const props = defineProps({

    column: { type: Object as PropType<ColumnType>, required: true },

});

const headClass = () => {
    if (props.column.header) {
        return [ConvertAlignTypeToString(props.column.header.align)];
    }
    return ["left"];
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.left {
    text-align: left
}

.right {
    text-align: right
}

.center {
    text-align: center
}
</style>
