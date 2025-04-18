import { clsx, type ClassValue } from "clsx"
import { twMerge } from "tailwind-merge"

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs))
}

export const ensurePrefix = (str:string, prefix:string)=>{
  str.startsWith(prefix) ? str : `${prefix}${str}`
}
export const withoutSuffix = (str:string, suffix:string)=>{
  str.endsWith(suffix) ? str.slice(0, -suffix.length) : str
}
export const withoutPrefix = (str:string, prefix:string)=>{
  str.startsWith(prefix) ? str.slice(prefix.length) : str
}