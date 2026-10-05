import axios from "axios";

const API = "https://localhost:7152/api"

export async function getAllSalesReps() {
    var res = await axios.get(`${API}/salesrep`);
    return res.data;
}

export async function getSalesRep(id){
    var res = await axios.get(`${API}/salesrep/${id}`)
    return res.data
}

export async function createSalesRep(salesRep){
    var payload = {
        firstName: salesRep.firstName,
        lastName: salesRep.lastName
    };

    var res = await axios.post(`${API}/salesrep`, payload);

    return res;
}

export async function deleteSalesRep(id){
    var res = await axios.delete(`${API}/salesrep/${id}`)
    return res;
}