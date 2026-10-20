<script setup>
import { onMounted, ref } from "vue";
import { getAllSalesReps } from "../services/salesRepService";
import { getAllCustomers } from "../services/customerService";

const selectedSalesRep = ref();
const selectedCustomer = ref();
const salesreps = ref([]);
const customers = ref([]);

onMounted(async () => {
    salesreps.value = await getAllSalesReps();
    customers.value = await getAllCustomers();

    console.log(customers);
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