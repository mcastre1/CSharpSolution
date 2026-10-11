<template>
  <div class="modal-backdrop" @click.self="close">
    <div class="modal-content">
      <h2>Create Product</h2>

      <form class="form">
        <div class="form-group">
          <label>Name</label>
          <input type="text" v-model="newProduct.name" required/>
        </div>

        <div class="form-group">
          <label>Price</label>
          <input type="text" v-model="newProduct.price" required/>
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
import { reactive} from "vue";

const emit = defineEmits(["close", "create"]);

const newProduct = reactive({
  name: "",
  price: "",
})

const errors = reactive({
  name: "",
  price: "",
});

function close() {
    emit("close");
}

function create() {
    if (!validate()) {
      console.log("Validation failed. Product not created.");  
      return;
    }
    emit("create", newProduct);
    emit("close");
}

function validate() {
  let valid = true;

  // First Name
  if (!newProduct.name.trim()) {
    errors.name = "Name is required";
    valid = false;
  } else if (newProduct.name.length > 30) {
    errors.firstName = "Name must be under 30 characters";
    valid = false;
  } else {
    errors.name = "";
  }
  return valid;
}

</script>

<style>
.modal-backdrop {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 9999;
  padding: 5%;
}

.modal-content {
  background: white;
  padding: 25px;
  border-radius: 10px;
  width: 400px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
}

.form {
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
