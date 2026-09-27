<script setup>
    import { ref, onMounted } from "vue";
    import { getAllCustomers, getCustomer} from '../services/customerService';
    import { MDBBtn, MDBTable} from 'mdb-vue-ui-kit';
    import Modal from './Modal.vue';

    const customers = ref([]);
    const showModal = ref(false);
    const selectedId = ref(null);
    const selectedCustomer = ref({});

    onMounted(async () => {
        customers.value = await getAllCustomers();
        console.log(customers.value);
    });

    async function openModal(id){
        selectedId.value = id;
        selectedCustomer.value = await getCustomer(id);
        showModal.value = true;
    }

    function closeModal() {
        showModal.value = false;
    }

    function saveCustomer(customer) {
        console.log("Saving customer");
        console.log(customer);
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
        :customer = "selectedCustomer"
        @close="closeModal"
        @save="saveCustomer"
    >
        <p>This is inside the modal</p>
    </Modal>
</template>