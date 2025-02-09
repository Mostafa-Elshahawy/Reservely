import {useState,useEffect} from 'react' 

interface QueryOptions<T> {
    queryKey:string 
    queryFn: ()=>Promise<T> 
    enabled? : boolean 
    staleTime? : number
}

const cache = new Map<string, {data:any; timestamp:number}>()

export const useQuery = <T>({queryKey, queryFn, enabled = true, staleTime= 5000}:QueryOptions<T>)=>{
    const [data, setData] = useState<T | null>(null)
    const [isLoading, setIsLoading] = useState(enabled)
    const [error, setError] = useState<Error | null>(null)

    useEffect(()=>{
        if(!enabled) return 

        const fetchData = async ()=>{
            setIsLoading(true) 

            try{
                const cachedData = cache.get(queryKey)
                if(cachedData && Date.now() - cachedData.timestamp < staleTime){
                    setData(cachedData.data)
                    setIsLoading(false)
                    return
                }
                const result = await queryFn()
                setData(result)
                cache.set(queryKey,{data:result,timestamp:Date.now()})
            }catch(err){
                setError(err as Error)
            }finally{
                setIsLoading(false)
            }
        }

        fetchData()
    },[queryKey, queryFn, enabled, staleTime])

    return { data, isLoading, error }
}