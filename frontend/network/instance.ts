import axios from 'axios';

const baseURL = process.env.NUXT_PUBLIC_API_BASE_URL;

const axiosInstance = axios.create({
    baseURL,
    timeout: 5000,
    headers:{
        'Content-Type': 'application/json',
        Accept:'application/json',
    }
})

export default axiosInstance;