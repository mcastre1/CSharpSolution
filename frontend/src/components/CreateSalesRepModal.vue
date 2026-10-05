<template>
  <div class="modal-backdrop" @click.self="close">
    <div class="modal-content">
      <h2>Create Sales Rep</h2>

      <form class="form">
        <div class="form-group">
          <label>First Name</label>
          <input type="text" v-model="newSalesRep.firstName" required/>
        </div>

        <div class="form-group">
          <label>Last Name</label>
          <input type="text" v-model="newSalesRep.lastName" required/>
        </div>
      </form>

      <div class="actions">
        <button class="modal-btn" @click="close">Close</button>
        <button class="modal-btn modal-btn-primary" @click="create">Create</button>
      </div>
    </div>
  </div>
</template>

<script setup>
import {reactive} from "vue";
const emit = defineEmits(["close", "create"]);

const newSalesRep = reactive({
    firstName: "",
    lastName: ""
});
</script>