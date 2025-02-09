import {useState} from 'react' 

interface MutaitonOptions<T, B>{
    mutationFn: (data: B) => Promise<T>
    onSuccess?: (data: T) => void
    onError?: (error: Error) => void
}

export const useMutaiton = <T ,B>({mutationFn,onSuccess,onError}:MutaitonOptions<T,B>)=>{
    const [isLoading, setIsLoading] = useState(false)
    const [error, setError] = useState<Error | null>(null)
    const [data, setData] = useState<T | null>(null)

    const mutate = async (input: B)=>{
        setIsLoading(true)
        setError(null)

        try{
            const result = await mutationFn(input)
            setData(result)
            if(onSuccess) onSuccess(result)
        }catch(err){
            setError(err as Error)
            if(onError) onError(err as Error)
        }finally{
            setIsLoading(false)
        }
    }
    return {mutate, data, isLoading, error }
}