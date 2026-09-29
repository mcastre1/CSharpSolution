<script setup>
    import { ref, onMounted } from "vue";
    import { getAllCustomers, getCustomer, updateCustomer, deleteCustomer} from '../services/customerService';
    import { MDBBtn, MDBTable} from 'mdb-vue-ui-kit';
    import Modal from './Modal.vue';
import CreateCustomerModal from "./CreateCustomerModal.vue";

    const customers = ref([]);
    const showModal = ref(false);
    const selectedId = ref(null);
    const selectedCustomer = ref({});
    const showCreateModal = ref(false);

    onMounted(async () => {
        customers.value = await getAllCustomers();
        console.log(customers.value);
    });

    async function openModal(id){
        selectedId.value = id;
        selectedCustomer.value = await getCustomer(id);
        showModal.value = true;
    }

    function openCreateModal() {
        showCreateModal.value = true;
    }

    function closeModal() {
        showModal.value = false;
    }
    function closeCreateModal() {
        showCreateModal.value = false;
    }

    async function saveCustomer(customer) {
        var res = await updateCustomer(customer.id, customer);
        console.log("Saving customer");
        console.log(customer);
        customers.value = await getAllCustomers();
    }

    async function deleteSelected(id){
        if (!confirm("Are you sure you want to delete this customer?")) {
            return;
        }

        console.log("deleted customer: " + id);
        await deleteCustomer(id);
        customers.value = await getAllCustomers();
    }

    async function createCustomer(customer){
        console.log("created customer " + JSON.stringify(customer))
    }
</script>
<template>
    <button @click="openCreateModal"> Create Customer </button>
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
                    <MDBBtn color="danger" @click="deleteSelected(customer.id)">Delete</MDBBtn>
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

    <CreateCustomerModal
        v-if="showCreateModal"
        @close="closeCreateModal"
        @create="createCustomer">
        <p>Create Customer</p>
    </CreateCustomerModal>
</template>