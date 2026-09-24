<script setup>
    import { ref, onMounted } from "vue";
    import { getAllCustomers } from '../services/customerService';
    import { MDBBtn, MDBTable} from 'mdb-vue-ui-kit';

    const customers = ref([]);

    onMounted(async () => {
        customers.value = await getAllCustomers();
        console.log(customers.value);
    });
</script>
<template>
    <MDBTable>
        <thead>
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Customer</th>
                <th scope="col">Actions</th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="customer in customers" :key="customer.id" scope="row">
                <td>{{ customer.id }}</td>
                <td>{{ customer.firstName }} {{ customer.lastName  }}</td>
                <td><MDBBtn color="primary">Primary</MDBBtn> Delete</td>
            </tr>
        </tbody>
    </MDBTable>
</template>