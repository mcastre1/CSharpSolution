<script setup>
import { onMounted, ref } from "vue";
import { getAllSalesReps } from "../services/salesRepService";

const selectedSalesRep = ref({});
const salesreps = ref([]);

onMounted(async () => {
    salesreps.value = await getAllSalesReps();
    console.log(salesreps)
});

</script>

<template>
    <div>
        <!-- Sales Rep Dropdown -->
        <label> Sales Rep </label>
        <select>
            <option disabled value="">Select a sales rep</option>
            <option v-for="rep in salesreps" :key="rep.id" :value="rep.id">
                {{ rep.firstName + " " + rep.lastName}}
            </option>
        </select>

        <!-- Show selected rep -->
        <div v-if="selectedSalesRep">
            <p>{{ selectedSalesRep.firstName }}</p>
        </div>
    </div>
</template>