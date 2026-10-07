import axios from 'axios';

const API = "https://localhost:7152/api";

export function getAllProducts(){
    var res = axios.get(`${API}/products`);
    return res.data;
}