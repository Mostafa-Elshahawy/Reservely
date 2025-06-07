import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import Sidebar from '@/components/dashboard/sidebar'
import FlightsTable from '@/components/dashboard/tables/flights-table'

interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){
    
    return (
       <>
       <section className='flex items-center'>
        <aside>
            <Sidebar />
        </aside>
        <div>
            <FlightsTable />
        </div>
        </section>
       </>
    )
}

export default withPageDictionary(Page)
