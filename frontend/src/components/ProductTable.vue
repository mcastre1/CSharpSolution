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
    <MDBTable>
        <thead>
            <tr>
                <th scope="col"> ID </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="product in products" :key="product.id" scope="row">
                <td>{{ product.id }}</td>
            </tr>
        </tbody>
    </MDBTable>
</template>