<script setup>
    import { MDBBtn, MDBTable } from 'mdb-vue-ui-kit';
    import { getAllSalesReps, getSalesRep } from '../services/salesRepService';
    import { ref, onMounted } from "vue";
import ViewSalesRepModal from './ViewSalesRepModal.vue';

    const salesreps = ref([]);
    const showViewModal = ref(false);

    onMounted(async() =>{
        salesreps.value = await getAllSalesReps();
        console.log(salesreps.value)
    });

    async function openViewModal(id){
        var selectedSalesRep = await getSalesRep(id);
        console.log(selectedSalesRep);
    }

</script>
<template>
    <MDBBtn color="success">Create Sales Rep</MDBBtn>
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
                    <MDBBtn color="danger">Delete</MDBBtn>
                </td>
            </tr>
        </tbody>
    </MDBTable>

    <ViewSalesRepModal
    v-if="showViewModal"/>
</template>