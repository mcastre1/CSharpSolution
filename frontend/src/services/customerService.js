import axios from "axios";

const API = "https://localhost:7152/api";

export async function getAllCustomers() {
    console.log("Hello");
    return axios.get(`${API}/customers`);
}

export async function getCustomer(id) {
    return axios.get(`${API}/customers/${id}`)
}