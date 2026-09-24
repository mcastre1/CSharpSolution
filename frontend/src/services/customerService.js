import axios from "axios";

const API = "https://localhost:7152/api";

export async function getAllCustomers() {
    var res = await axios.get(`${API}/customers`);
    return res.data;
}

export async function getCustomer(id) {
    var res = await axios.get(`${API}/customers/${id}`);
    return res.data
}