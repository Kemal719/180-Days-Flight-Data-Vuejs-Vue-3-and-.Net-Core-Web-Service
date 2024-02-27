<template>
    <div class="title-bar">
       <h2> {{ title }} </h2>
    </div>
</template>

<script lang="ts" setup>
import { defineProps } from "vue";

const props = defineProps({

    title: { type: String, required: false }

})

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.title-bar {
    // margin-bottom: 5px;
    padding: 10px 10px;
    background-color: blue;
    color: white;
    text-align: center;
}
</style>
