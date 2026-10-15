<script setup>
import { createProcut, deleteProduct, getAllProducts, putProduct } from '../services/productService.js';
import { onMounted, ref } from 'vue';
import {MDBBtn, MDBTable} from 'mdb-vue-ui-kit';
import CreateProductModal from './CreateProductModal.vue';
import ViewProductModal from './ViewProductModal.vue';

const products = ref([]);
const createModal = ref(false);
const viewModal = ref(false);
const selectedProduct = ref({});

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

function showViewModal(product){
    selectedProduct.value = product;
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

async function deleteProductId(id){
    if(!confirm(`Are you sure you want to delete product with id ${id}?`)){
        return;
    }
    
    await deleteProduct(id);
    products.value = await getAllProducts();
}

async function saveProduct(product){
    var res = await putProduct(product);
    products.value = await getAllProducts();
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
                <th scope="col"> Actions </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="product in products" :key="product.id" scope="row">
                <td>{{ product.id }}</td>
                <td>{{ product.name }}</td>
                <td>$ {{ product.price }}</td>
                <td>
                    <MDBBtn class="actionBtn" color="info" @click="showViewModal({'id':product.id, 'name':product.name, 'price':product.price})">View</MDBBtn> 
                    <MDBBtn class="actionBtn" color="danger" @click="deleteProductId(product.id)">Delete</MDBBtn>
                </td>
            </tr>
        </tbody>
    </MDBTable>

    <CreateProductModal
    v-if="createModal"
    @create="sendCreateProduct"
    @close="hideCreateModal"/>

    <ViewProductModal
    v-if="viewModal"
    :product="selectedProduct"
    @close="hideViewModal"
    @save="saveProduct"/>
</template>

<style>
.actionBtn {
    margin-left: 15px;
}
</style>