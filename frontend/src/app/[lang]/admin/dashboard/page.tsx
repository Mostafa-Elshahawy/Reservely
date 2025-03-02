import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import DashboardBarChart from '@/components/dashboard/dashboard-barchart'
import Sidebar from '@/components/dashboard/sidebar'
import StatisticCard from '@/components/dashboard/statisic-card'

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
            <div className='flex justify-between'>
                <StatisticCard 
                    text={dictionary.dashboard.total_users}
                    value={100}         
                    variant='primary' 
                />
            </div>
        </div>
        </section>
       </>
    )
}

export default withPageDictionary(Page)