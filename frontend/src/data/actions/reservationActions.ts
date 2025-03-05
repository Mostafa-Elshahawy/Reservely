'use server'
import {api} from '@/lib/ApiInstance'

export const getReservations = async ()=>{
    const reservations = await api.get("/reservations")
    return reservations
}

export const getreservation = async (id:string)=>{
    const reservation = await api.get(`/reservations/${id}`)
    return reservation
}

export const createreservation = async (reservation:any)=>{
    const newReservation = await api.post("/reservations",reservation)
    return newReservation
}

export const updatereservation = async (id:string,reservation:any)=>{
    const updatedReservation = await api.put(`/reservations/${id}`,reservation)
    return updatedReservation
}

export const deletereservation = async (id:string)=>{
    const deletedReservation = await api.delete(`/reservations/${id}`)
    return deletedReservation
}

