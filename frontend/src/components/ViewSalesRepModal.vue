<script setup>
import { reactive } from "vue";

const props = defineProps({
    salesrep: {
        type: Object,
        required: true
    }
});

const localSalesRep = reactive({
    ...props.salesrep
});

const emit = defineEmits(["close", "update"])

function close(){
    emit("close");
}

function update(){
    emit("update", localSalesRep);
    emit("close");
}

</script>

<template>
    <div class="modal-backdrop" @click.self="close">
        <div class="modal-content">
            <h1>Viewing Sales Rep</h1>

            <form class="form">
                <div class="form-group">
                    <label>ID</label>
                    <input type="text" v-model="localSalesRep.id" disabled>
                </div>

                <div class="form-group">
                    <label>First Name</label>
                    <input type="text" v-model="localSalesRep.firstName"/>
                </div>

                <div class="form-group">
                    <label>Last Name</label>
                    <input type="text" v-model="localSalesRep.lastName"/>
                </div>
            </form>

            <div class="actions">
                    <button class="modal-btn" @click="close">Close</button>
                    <button class="modal-btn modal-btn-primary" @click="update">Save Changes</button>
            </div>
        </div>
    </div>
</template>

<style>
.modal-backdrop {
    position: fixed;
    inset: 0;
    background-color: rgba(0,0,0,0.5);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 9999;
    padding: 5%;
}

.modal-content{
    background: white;
    padding: 25px;
    border-radius: 10px;
    width: 400px;
    box-shadow: 0 4px 20px rgba(0,0,0,0.2);
}

.form{
    margin-top: 15px;
}

.form-group {
  margin-bottom: 12px;
  display: flex;
  flex-direction: column;
}

.form-group label {
  font-weight: 600;
  margin-bottom: 4px;
}

.form-group input {
  padding: 8px 10px;
  border: 1px solid #ccc;
  border-radius: 6px;
  font-size: 14px;
}

.actions {
  display: flex;
  justify-content: flex-end;
  gap: 10px;
  margin-top: 20px;
}

.modal-btn {
  padding: 8px 14px;
  border-radius: 6px;
  border: none;
  cursor: pointer;
  background: #ddd;
}

.modal-btn-primary {
  background: #007bff;
  color: white;
}
</style>