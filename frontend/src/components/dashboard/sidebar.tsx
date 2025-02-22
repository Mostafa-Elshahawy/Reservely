'use client'
import {useState, useEffect} from 'react'
import Link from 'next/link' 
import { useDictionary } from '@/i18n/context'

type NavLink = {
    icon:React.ReactNode 
    text:string 
    href:string 
}

export default function Sidebar(){
    const [isExpanded, setIsExpanded] = useState(false)
    const dictionary = useDictionary()
    const toggleTheme = ()=>{
        console.log('toggle theme')
    }

    return (
        <nav
            className={`h-screen flex flex-col border-r transtion-all duration-300 bg-gray-200 dark:bg-gray-800 text-black dark:text-white ${isExpanded ? 'w-64':'w-20'}`}
        >
            <div className='flex-1'>
                <div className='flex items-center p-4'>
                    <button 
                    onClick={()=>setIsExpanded(!isExpanded)}
                    className='hover:bg-gray-100 dark:hover:bg-gray-700 p-2 rouned-lg'>
                        {isExpanded ? '<':'>'}
                    </button>
                    {isExpanded && (
                        <h1 className='text-xl font-bold mx-4'>
                            {dictionary.sidebar.dashboard}
                        </h1>
                    )}
                </div>
                <ul className="space-y-2 px-2">
                    
                </ul>
                <div className='p-4 border-5'>
                    <div className='flex flex-col space-y-4'>
                        <button onClick={toggleTheme} className='flex items-center hover:bg-gray-100 dark:hover:bg-gray-700 p-2 rounded-lg'>
                            theme
                        </button>
                        <div className='flex items-center'>
                            <span className='text-xl'>
                                locale
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    )
}