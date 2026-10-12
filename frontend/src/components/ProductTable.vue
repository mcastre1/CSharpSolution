<script setup>
import { createProcut, getAllProducts } from '../services/productService.js';
import { onMounted, ref } from 'vue';
import {MDBBtn, MDBTable} from 'mdb-vue-ui-kit';
import CreateProductModal from './CreateProductModal.vue';
import ViewProductModal from './ViewProductModal.vue';

const products = ref([]);
const createModal = ref(false);
const viewModal = ref(false);

async function getProducts(){
    products.value = await getAllProducts();
}

onMounted(async ()=>{
    await getProducts();
    console.log(products.value);
});

function showCreateModal(){
    console.log("Create modal opened");
    createModal.value = true;
}

function hideCreateModal(){
    createModal.value = false;
}

function showViewModal(){
    viewModal.value = true;
}

function hideViewModal(){
    viewModal.value = false;
}

async function sendCreateProduct(product){
    console.log(product);
    var res = await createProcut(product);
    console.log(res);
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

    <ViewProductModal
    v-if="viewModal"
    @close="hideViewModal"/>
</template>