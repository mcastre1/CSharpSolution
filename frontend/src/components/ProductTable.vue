<script setup>
import { getAllProducts } from '../services/productService.js';
import { onMounted, ref } from 'vue';

const products = ref([])

async function getProducts(){
    products.value = await getAllProducts();
}

onMounted(()=>{
    getProducts();
    console.log(products.value);
});

</script>
<template>
</template>