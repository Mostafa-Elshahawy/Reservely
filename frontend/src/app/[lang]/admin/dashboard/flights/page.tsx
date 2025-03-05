import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import Sidebar from '@/components/dashboard/sidebar'
import DataTable from '@/components/dashboard/data-table'
import { columns, Flight } from '@/components/dashboard/columns/flights-columns'
import { getFlights } from '@/data/actions/flightActions'
import { useQuery } from '@/hooks/useQuery'

interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){
    const {data:flightsData, isLoading:flightsLoading, error:flightsError} = useQuery({
        queryKey: 'flights',
        queryFn: getFlights
    })
    return (
       <>
       <section className='flex items-center'>
        <aside>
            <Sidebar />
        </aside>
        <div>
            <DataTable columns={columns} data={flightsData as Flight[]} />
        </div>
        </section>
       </>
    )
}
