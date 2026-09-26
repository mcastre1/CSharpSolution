<script setup>
    import { ref, onMounted } from "vue";
    import { getAllCustomers } from '../services/customerService';
    import { MDBBtn, MDBTable} from 'mdb-vue-ui-kit';
    import Modal from './Modal.vue';

    const customers = ref([]);
    const showModal = ref(false)

    onMounted(async () => {
        customers.value = await getAllCustomers();
        console.log(customers.value);
    });

    function openModal() {
        showModal.value = true
    }

    function closeModal() {
        showModal.value = false
    }
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
                <td>
                    <MDBBtn color="info" @click="openModal">Read</MDBBtn> 
                    <MDBBtn color="danger">Delete</MDBBtn>
                </td>
            </tr>
        </tbody>
    </MDBTable>
    <Modal 
        v-if="showModal"
        title="Add a new customer"
        @close="closeModal"
    >
        <p>This is inside the modal</p>
    </Modal>
</template>