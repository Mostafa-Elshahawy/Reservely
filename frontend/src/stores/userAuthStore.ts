import { create } from 'zustand'
import { persist } from 'zustand/middleware'

interface User {
    id:string
    name:string 
    email:string 
    isAdmin:boolean 
    token?:string
}