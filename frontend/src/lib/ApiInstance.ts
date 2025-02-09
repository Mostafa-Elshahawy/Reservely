export class ApiInstance {
    private baseUrl: string
    private defaultHeaders: HeadersInit 
    private retries: number 

    constructor(baseUrl:string,defaultHeaders?:HeadersInit,retries:number=3){
        this.baseUrl = baseUrl 
        this.defaultHeaders = defaultHeaders || {"Content-Type":"application/json"}
        this.retries = retries
    }

    private async request<T>(endpoint:string, options:RequestInit,retriesLeft:number):Promise<T>{
        const url = `${this.baseUrl}${endpoint}`

        try{
            const response = await fetch(url,{
                ...options,
                headers:{...this.defaultHeaders,...options.headers},
            })
            if(!response.ok){
                const errorText = await response.text() 
                throw new Error(`Request failed with status ${response.status}: ${errorText}`)
            }
            return (await response.json() as T)
        }catch(error){
            if(retriesLeft > 0){
                return this.request<T>(endpoint,options,retriesLeft-1)
            }
            throw error
        }
    }

    async get<T>(endpoint:string,headers?:HeadersInit):Promise<T>{
        return  this.request<T>(endpoint,{method:"GET",headers},this.retries)
    }

    async post<T, B>(endpoint:string,body:B,headers?:HeadersInit):Promise<T>{
        return this.request<T>(endpoint,{method:"POST",body:JSON.stringify(body),headers},this.retries)
    }

    async put<T, B>(endpoint:string,body:B,headers?:HeadersInit):Promise<T>{
        return this.request<T>(endpoint,{method:"PUT",body:JSON.stringify(body),headers},this.retries)
    }

    async delete<T>(endpoint:string,headers?:HeadersInit):Promise<T>{
        return this.request<T>(endpoint,{method:"DELETE",headers},this.retries)
    }

    async patch<T, B>(endpoint:string,body:B,headers?:HeadersInit):Promise<T>{
        return this.request<T>(endpoint,{method:"PATCH",body:JSON.stringify(body),headers},this.retries)
    }
}

export const api = new ApiInstance("http://localhost:3000/api")