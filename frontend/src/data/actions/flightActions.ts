'use server'
import {api} from '@/lib/ApiInstance'

export const getFlights = async ()=>{
    const flights = await api.get("/flights")
    return flights
}

export const getFlight = async (id:string)=>{
    const flight = await api.get(`/flights/${id}`)
    return flight
}

export const createFlight = async (flight:any)=>{
    const newFlight = await api.post("/flights",flight)
    return newFlight
}

export const updateFlight = async (id:string,flight:any)=>{
    const updatedFlight = await api.put(`/flights/${id}`,flight)
    return updatedFlight
}

export const deleteFlight = async (id:string)=>{
    const deletedFlight = await api.delete(`/flights/${id}`)
    return deletedFlight
}

