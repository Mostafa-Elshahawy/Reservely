import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import Sidebar from '@/components/dashboard/sidebar'
import DataTable from '@/components/dashboard/data-table'
import { columns, Reservation } from '@/components/dashboard/columns/reservations-columns'
import { getReservations } from '@/data/actions/reservationActions'
import { useQuery } from '@/hooks/useQuery'

interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){

    const {data:reservationsData, isLoading:reservationsLoading, error:reservationsError} = useQuery({
        queryKey: 'reservations',
        queryFn: getReservations
    })

    return (
       <>
       <section className='flex items-center'>
        <aside>
            <Sidebar />
        </aside>
        <div>
            <DataTable columns={columns} data={reservationsData as Reservation[]} />
        </div>
        </section>
       </>
    )
}

export default withPageDictionary(Page)