<script setup>
    import { MDBBtn, MDBTable } from 'mdb-vue-ui-kit';
    import { createSalesRep, deleteSalesRep, getAllSalesReps, getSalesRep } from '../services/salesRepService';
    import { ref, onMounted } from "vue";
import ViewSalesRepModal from './ViewSalesRepModal.vue';
import CreateSalesRepModal from './CreateSalesRepModal.vue';

    const salesreps = ref([]);
    const showViewModal = ref(false);
    const showCreateModal = ref(false);
    const selectedSalesRep = ref({});

    onMounted(async() =>{
        salesreps.value = await getAllSalesReps();
        console.log(salesreps.value)
    });

    async function openViewModal(id){
        selectedSalesRep.value = await getSalesRep(id);
        showViewModal.value = true;
    }

    function closeViewModal(){
        showViewModal.value = false;
    }

    function openCreateModal(){
        showCreateModal.value = true;
    }

    function closeCreateModal(){
        showCreateModal.value = false;
    }

    async function postSalesRep(salesRep){
        await createSalesRep(salesRep);
        salesreps.value = await getAllSalesReps();
    }

    async function deleteSelectedSalesRep(id){
        if (!confirm("Are you sure you want to delete this sales rep?")){
            return;
        }

        await deleteSalesRep(id);
        salesreps.value = await getAllSalesReps();
    }

</script>
<template>
    <MDBBtn color="success" @click="openCreateModal">Create Sales Rep</MDBBtn>
    <MDBTable>
        <thead>
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Sales Rep</th>
                <th scope="col">Actions</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="salesrep in salesreps" :key="salesrep.id" scope="row">
                <td>{{ salesrep.id }}</td>
                <td>{{ salesrep.firstName }} {{ salesrep.lastName }}</td>
                <td>
                    <MDBBtn color="info" @click="openViewModal(salesrep.id)">View</MDBBtn>
                    <MDBBtn color="danger" @click="deleteSelectedSalesRep(salesrep.id)">Delete</MDBBtn>
                </td>
            </tr>
        </tbody>
    </MDBTable>

    <ViewSalesRepModal
    v-if="showViewModal"
    :salesrep="selectedSalesRep"
    @close="closeViewModal"/>

    <CreateSalesRepModal
    v-if="showCreateModal"
    @close="closeCreateModal"
    @create="postSalesRep"/>
</template>