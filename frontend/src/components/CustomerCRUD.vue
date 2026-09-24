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
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Phone</th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="customer in customers" :key="customer.id">
                <td>{{ customer.id }}</td>
                <td>{{ customer.firstName }}</td>
                <td>{{ customer.lastName }}</td>
                <td>{{ customer.email }}</td>
                <td>{{ customer.phone }}</td>
            </tr>
        </tbody>
    </table>
</template>