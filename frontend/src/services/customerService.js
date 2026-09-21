import axios from "axios";

const API = "https://localhost:5001/api";

export async function getAllCustomers() {
    return axios.get(`${API}/customers`);
}

export async function getCustomer(id) {
    return axios.get(`${API}/customers/${id}`)
}