<script setup>
    import { MDBTable } from 'mdb-vue-ui-kit';
    import { getAllSalesReps } from '../services/salesRepService';
    import { ref, onMounted } from "vue";

    const salesreps = ref([]);

    onMounted(async() =>{
        salesreps.value = await getAllSalesReps();
        console.log(salesreps.value)
    });

</script>
<template>
    <button>Create Sales Rep</button>
    <MDBTable>
        <thead>
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Sales Rep</th>
                <th scope="col">Actions</th>
            </tr>
        </thead>
        <tbody>

        </tbody>
    </MDBTable>
</template>