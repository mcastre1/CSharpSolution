<script setup>
import { onMounted, ref } from "vue";
import { getAllSalesReps } from "../services/salesRepService";
import { getAllCustomers } from "../services/customerService";
import { getAllProducts } from "../services/productService";

const selectedSalesRep = ref();
const selectedCustomer = ref();
const selectedProduct = ref();
const salesreps = ref([]);
const customers = ref([]);
const products = ref([]);

onMounted(async () => {
    salesreps.value = await getAllSalesReps();
    customers.value = await getAllCustomers();
    products.value = await getAllProducts();
});

</script>

<template>
    <div>
        <!-- Sales Rep Dropdown -->
        <label> Sales Rep </label>
        <select v-model="selectedSalesRep">
            <option disabled value="">Select a sales rep</option>
            <option v-for="rep in salesreps" :key="rep.id" :value="rep">
                {{ rep.firstName + " " + rep.lastName}}
            </option>
        </select>

        <!-- Show selected rep -->
        <div v-if="selectedSalesRep">
            <p>{{ selectedSalesRep.firstName + " " + selectedSalesRep.lastName}}</p>
        </div>

        <label> Customer </label>
        <select v-model="selectedCustomer">
            <option disabled value="">Select a costumer</option>
            <option v-for="customer in customers" :key="customer.id" :value="customer">
                {{ customer.firstName }}
            </option>
        </select>

        <div v-if="selectedCustomer">
            <p>{{ selectedCustomer.firstName }}</p>
        </div>
        <div>
            <label>Products</label>
            <select v-model="selectedProduct">
                <option disabled value="">Select a product</option>
                <option v-for="product in products" :key="product.id" :value="product">
                    {{ product.name }} {{ product.price }}
                </option>
            </select>
        </div>
        <div v-if="selectedProduct">
            <h2>Selected Product</h2>
            <table style="width: 100%;">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tr>
                    <td>{{ selectedProduct.name }}</td>
                    <td>{{ selectedCustomer.price }}</td>
                </tr>
            </table>
        </div>
        
        <div>
            <hr>Sale Items</hr>
            <table class="sales-table">
                <thead>
                    <tr>
                        <th>Item Name</th>
                        <th>Description</th>
                        <th>Price</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</template>

<style>
.sales-table{
    width: 100%;
}
</style>