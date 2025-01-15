export enum UserRole {
    GUEST = 'guest',
    USER = 'user',
    ADMIN = 'admin'
}

export interface User {
    id:number
    name:string
    email:string 
    role:UserRole
}