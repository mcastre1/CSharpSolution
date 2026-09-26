<script setup>
    import { ref, onMounted } from "vue";
    import { getAllCustomers } from '../services/customerService';
    import { MDBBtn, MDBTable} from 'mdb-vue-ui-kit';
    import Modal from './Modal.vue';

    const customers = ref([]);
    const showModal = ref(false)
    const selectedId = ref(null)

    onMounted(async () => {
        customers.value = await getAllCustomers();
        console.log(customers.value);
    });

    function openModal(id) {
        selectedId.value = id;
        showModal.value = true;
    }

    function closeModal() {
        showModal.value = false;
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
                    <MDBBtn color="info" @click="openModal(customer.id)">Read</MDBBtn> 
                    <MDBBtn color="danger">Delete</MDBBtn>
                </td>
            </tr>
        </tbody>
    </MDBTable>
    <Modal 
        v-if="showModal"
        title="Add a new customer"
        :customerId = "selectedId"
        @close="closeModal"
    >
        <p>This is inside the modal</p>
    </Modal>
</template>