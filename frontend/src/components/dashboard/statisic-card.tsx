
interface Props {
    text :string 
    value:number 
    variant:'primary' | 'secondary'
}

export default function StatisticCard({text, value, variant}:Props){
    return (
        <div className={`flex flex-col  items-center justify-center p-3 rounded-xl shadow-sm text-white 
        ${variant === 'primary' ?'bg-gradient-to-t from-primary/75 to-primary':'bg-gradient-to-t from-secondary/75 to-secondary'}`}>
            <p className='text-lg'>{text}</p>
            <p className='text-3xl font-bold tex'>{value}</p>
        </div>
    )
}