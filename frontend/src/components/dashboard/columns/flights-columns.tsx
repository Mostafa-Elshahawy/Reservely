"use client" 

import {ColumnDef} from '@tanstack/react-table'

export type Flight = {
    id: string 
    amount: number 
    status: 'pending' | 'processing' | 'success' | 'failed'
    email: string
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