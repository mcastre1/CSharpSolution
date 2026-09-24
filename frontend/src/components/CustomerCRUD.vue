<script setup>
    import { ref, onMounted } from "vue";
    import { getAllCustomers } from '../services/customerService'

    const customers = ref([]);

    onMounted(async () => {
        customers.value = await getAllCustomers();
        console.log(customers.value);
    });
</script>
<template>
    <table>
        <thead>
            <tr>
                <th>Id</th>
                <th>Customer</th>
                <th>Actions</th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="customer in customers" :key="customer.id">
                <td>{{ customer.id }}</td>
                <td>{{ customer.firstName }} {{ customer.lastName  }}</td>
                <td>Read Delete</td>
            </tr>
        </tbody>
    </table>
</template>