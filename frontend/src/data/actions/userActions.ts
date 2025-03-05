'use server'
import {api} from '@/lib/ApiInstance'

export const getUsers = async ()=>{
    const users = await api.get("/users")
    return users
}

export const getUser = async (id:string)=>{
    const user = await api.get(`/users/${id}`)
    return user
}

export const createUser = async (user:any)=>{
    const newUser = await api.post("/users",user)
    return newUser
}

export const updateUser = async (id:string,user:any)=>{
    const updatedUser = await api.put(`/users/${id}`,user)
    return updatedUser
}

export const deleteUser = async (id:string)=>{
    const deletedUser = await api.delete(`/users/${id}`)
    return deletedUser
}

