<template>
  <div class="modal-backdrop" @click.self="close">
    <div class="modal-content">
      <h2>{{ title }}</h2>

      <slot></slot>

      <button @click="close">Close</button>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  title: {
    type: String,
    default: ''
  }
})

const emit = defineEmits(['close'])

function close() {
  emit('close')
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
  padding: 10%;
}

.modal-content {
  background: white;
  padding: 20px;
  border-radius: 8px;
  min-width: 300px;
}
</style>