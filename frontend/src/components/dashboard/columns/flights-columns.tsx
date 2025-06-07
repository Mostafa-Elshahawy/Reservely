"use client" 

import {ColumnDef} from '@tanstack/react-table'

export type Flight = {
    id: number
    airline: string
    flightNumber: string
    status: string
    duration: string
    departureLounge: number
    arrivalLounge: number
    departureTime: Date
    arrivalTime: Date
    departureAirport: string
    arrivalAirport: string
    departureCity: string
    departureCountry: string
    arrivalCity: string
    arrivalCountry: string
    flightClasses: {
        classType: number
        totalSeats: number
        availableSeats: number
        price: number
      }[]
}

export const columns:ColumnDef<Flight>[] = [
    {
        accessorKey: 'status',
        header: 'Status',
    },
    {
        accessorKey: 'email',
        header: 'Email',
    },
    {
        accessorKey: 'amount',
        header: 'Amount',
    },
]