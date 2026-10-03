import axios from "axios";

const API = "https://localhost:7152/api"

export async function getAllSalesReps() {
    var res = await axios.get(`${API}/salesrep`);
    return res.data;
}