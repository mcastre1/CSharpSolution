<script setup>
import { getAllProducts } from '../services/productService.js';
import { ref } from 'vue';

const products = ref([])

async function getProducts(){
    products.value = await getAllProducts();
}

</script>
<template>
</template>