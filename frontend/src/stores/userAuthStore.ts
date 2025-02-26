import { create } from 'zustand'
import { persist } from 'zustand/middleware'

interface User {
    id:string
    name:string 
    email:string 
    isAdmin:boolean 
    token?:string
}

interface AuthState {
    user: User | null 
    isAuthenticated: boolean 
    login: (user:User)=>void 
    logout: ()=>void
}

const useAuthStore = create<AuthState>()(
    persist(
        (set) => ({
            user: null,
            isAuthenticated: false,
            login: (user: User) => set({ user, isAuthenticated: true }),
            logout: () => set({ user: null, isAuthenticated: false }),
        }),
        { name: 'auth-storage' }
    )
)