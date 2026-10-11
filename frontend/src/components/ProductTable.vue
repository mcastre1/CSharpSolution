<script setup>
import { getAllProducts } from '../services/productService.js';
import { onMounted, ref } from 'vue';
import {MDBBtn, MDBTable} from 'mdb-vue-ui-kit';

const products = ref([]);
const createModal = ref(false);

async function getProducts(){
    products.value = await getAllProducts();
}

onMounted(()=>{
    getProducts();
    console.log(products.value);
});

function showCreateModal(){
    createModal.value = true;
}

function hideCreateModal(){
    createModal.value = false;
}

</script>
<template>
    <MDBBtn color="success">Create Product</MDBBtn>
    <MDBTable>
        <thead>
            <tr>
                <th scope="col"> ID </th>
                <th scope="col"> Name </th>
                <th scope="col"> Price </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="product in products" :key="product.id" scope="row">
                <td>{{ product.id }}</td>
                <td>{{ product.name }}</td>
                <td>{{ product.price }}</td>
            </tr>
        </tbody>
    </MDBTable>
</template>