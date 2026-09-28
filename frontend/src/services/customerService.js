import axios from "axios";

const API = "https://localhost:7152/api";

export async function getAllCustomers() {
    var res = await axios.get(`${API}/customers`);
    return res.data;
}

export async function getCustomer(id) {
    var res = await axios.get(`${API}/customers/${id}`);
    return res.data;
}

export async function updateCustomer(id, customer){
    
    var payload = {
        firstName : customer.firstName,
        lastName : customer.lastName,
        email : customer.email,
        phoneNumber : customer.phoneNumber,
    };

    var res = await axios.put(`${API}/customers/${id}`, payload);
    return res;
}