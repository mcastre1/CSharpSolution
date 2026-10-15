import axios from 'axios';

const API = "https://localhost:7152/api";

export async function getAllProducts(){
    var res = await axios.get(`${API}/products`);
    return res.data;
}

export async function createProcut(product){
    var payload = {
        'name':product.name,
        'price': parseFloat(product.price)
    }
    var res = await axios.post(`${API}/products`, payload);
    return res;
}

export async function deleteProduct(id){
    var res = await axios.delete(`${API}/products/${id}`);
    return res;
}

export async function putProduct(product){
    var newProduct = {
        'name':product.name,
        'price':product.price
    }
    var res = await axios.put(`${API}/products/${product.id}`, product);

    return res;
}