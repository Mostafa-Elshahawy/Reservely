'use client'
import DataTable from '@/components/dashboard/data-table'
import { columns, Flight } from '@/components/dashboard/columns/flights-columns'
import { getFlights } from '@/data/actions/flightActions'
import { useQuery } from '@/hooks/useQuery'

export default function FlightsTable(){
    const getFligtsAll = async ()=>{
        try {
            const response = await fetch('https://localhost:7211/api/flight/all?pageNumber=1&pageSize=10')
            const data = await response.json()
            return data
        }catch (error) {
            console.log(error)
        }
    }
    const {data:flightsData, isLoading:flightsLoading, error:flightsError} = useQuery({
        queryKey: 'flights',
        queryFn: getFligtsAll
    })
    console.log(flightsData)
    return (
        <div>
            {/* <DataTable columns={columns} data={flightsData as Flight[]} /> */}
        </div>
    )
}