import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import Sidebar from '@/components/dashboard/sidebar'
import DataTable from '@/components/dashboard/data-table'
import { columns, User } from '@/components/dashboard/columns/users-columns'
import { getUsers } from '@/data/actions/userActions'
import { useQuery } from '@/hooks/useQuery'

interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){

    const {data:usersData, isLoading:usersLoading, error:usersError} = useQuery({
        queryKey: 'users',
        queryFn: getUsers
    })

    return (
       <>
       <section className='flex items-center'>
        <aside>
            <Sidebar />
        </aside>
        <div>
            <DataTable columns={columns} data={usersData as User[]} />
        </div>
        </section>
       </>
    )
}

export default withPageDictionary(Page)