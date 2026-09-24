<script setup>
    import { ref, onMounted } from "vue";
    import { getAllCustomers } from '../services/customerService'

    const customers = ref([]);

    onMounted(async () => {
        customers.value = await getAllCustomers();
        console.log(customers);
    });
</script>
<template>
    <v-table>
        <thead>
            <tr>
                <th class="text-left">
                    Id
                </th>
                <th class="text-left">
                    First Name
                </th>
                <th class="text-left">
                    Last Name
                </th>
                <th class="text-left">
                    Email
                </th>
                <th class="text-left">
                    Phone Number
                </th>
            </tr>
            <tr v-for="customer in customers" :key="customer.Id">
                <td>{{customer.Id}}</td>
                <td>{{customer.FirstName}}</td>
                <td>{{customer.LastName}}</td>
                <td>{{customer.Email}}</td>
                <td>{{customer.Phone}}</td>
            </tr>
        </thead>
    </v-table>
</template>