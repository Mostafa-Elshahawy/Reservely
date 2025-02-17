import {Bar,BarChart} from 'recharts'

import {ChartConfig,ChartContainer} from '@/components/ui/chart'

interface Props {
    config: ChartConfig
    data: any[]

}
export default function DashboardBarChart({config, data}:Props){
    return (
        <ChartContainer config={config} className='min-h-[200px] w-full'>
            <BarChart data={data}>
            </BarChart>
        </ChartContainer>
    )
}