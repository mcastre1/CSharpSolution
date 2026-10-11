<script setup>
import { getAllProducts } from '../services/productService.js';
import { onMounted, ref } from 'vue';
import {MDBBtn, MDBTable} from 'mdb-vue-ui-kit';
import CreateProductModal from './CreateProductModal.vue';

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
    console.log("Create modal opened");
    createModal.value = true;
}

function hideCreateModal(){
    createModal.value = false;
}

function sendCreateProduct(product){
    console.log(product);
}

</script>
<template>
    <MDBBtn color="success" @click="showCreateModal">Create Product</MDBBtn>
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

    <CreateProductModal
    v-if="createModal"
    @create="sendCreateProduct"
    @close="hideCreateModal"/>
</template>