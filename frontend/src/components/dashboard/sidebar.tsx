'use client'
import {useState, useEffect} from 'react'
import { useRouter } from 'next/navigation'
import { useDictionary } from '@/i18n/context'
import { Moon, Sun, Languages, Menu, Plane, Users, TicketsPlane } from 'lucide-react'
import { useTheme } from 'next-themes'
import {Button} from '@/components/ui/button'

type NavLink = {
    icon:React.ReactNode 
    text:string 
    href:string 
}

export default function Sidebar(){
    const [isExpanded, setIsExpanded] = useState(false)
    const dictionary = useDictionary()
    const router = useRouter()
    const { setTheme , theme} = useTheme()
    const toggleTheme = ()=>{
        setTheme(theme === 'dark' ? 'light' : 'dark')
    }

    const toggleLanguage = ()=>{
        console.log('toggle language')
    }

    return (
        <nav
            className={`h-screen flex flex-col border-r transtion-all duration-300 bg-indigo-200 dark:bg-indigo-950 text-indigo-800 dark:text-white ${isExpanded ? 'w-64':'w-20'}`}
        >
            <div className='flex-1'>
                <div className='flex items-center p-4'>
                    <button 
                    onClick={()=>setIsExpanded(!isExpanded)}
                    className='hover:bg-gray-100 dark:hover:bg-indigo-800 p-2 rounded-lg'>
                        {isExpanded ? <Menu size={24} className='rotate-90 transition-all duration-300'/>: <Menu size={24} className='transition-all duration-300'/>}
                    </button>
                    {isExpanded && (
                        <h1 className='text-xl font-bold mx-4'>
                            {dictionary.sidebar.dashboard}
                        </h1>
                    )}
                </div>
                <ul className="flex flex-col space-y-2 p-4 border-5">
                    <Button
                        onClick={()=>router.push('/admin/dashboard/flights')}
                        className='flex items-center hover:bg-gray-100 dark:hover:bg-indigo-800 p-2 rounded-lg bg-indigo-800 dark:bg-gray-100 text-white hover:text-indigo-800 dark:text-indigo-800 dark:hover:text-gray-100'
                    >
                    {isExpanded ? 
                        <>  
                            <Plane size={24} />
                            {dictionary.sidebar.flights}
                        </>
                     : <>
                        <Plane size={24} />
                        </>  }
                    </Button>
                    <Button className='flex items-center hover:bg-gray-100 dark:hover:bg-indigo-800 p-2 rounded-lg bg-indigo-800 dark:bg-gray-100 text-white hover:text-indigo-800 dark:text-indigo-800 dark:hover:text-gray-100'>{ isExpanded ? 
                        <>
                            <TicketsPlane size={24}/>
                            {dictionary.sidebar.reservations}
                        </>
                        :
                        <>
                            <TicketsPlane size={24}/>
                        </>}</Button>
                    <Button className='flex items-center hover:bg-gray-100 dark:hover:bg-indigo-800 p-2 rounded-lg bg-indigo-800 dark:bg-gray-100 text-white hover:text-indigo-800 dark:text-indigo-800 dark:hover:text-gray-100'>
                        { isExpanded ? 
                        <>
                            <Users size={24}/>
                            {dictionary.sidebar.users}
                        </> 
                        : 
                        <>
                            <Users size={24}/>
                        </>}
                    </Button> 
                </ul>
                <div className='p-4 border-5'>
                    <div className='flex flex-col space-y-4'>
                        <Button onClick={toggleTheme} className='flex items-center hover:bg-gray-100 dark:hover:bg-indigo-800 p-2 rounded-lg bg-indigo-800 dark:bg-gray-100 text-white hover:text-indigo-800 dark:text-indigo-800 dark:hover:text-gray-100'>
                            {theme === 'dark' ? <Sun size={6} /> : <Moon size={6} />}
                        </Button>
                        <Button onClick={toggleLanguage} className='flex items-center hover:bg-gray-100 dark:hover:bg-indigo-800 p-2 rounded-lg bg-indigo-800 dark:bg-gray-100 text-white hover:text-indigo-800 dark:text-indigo-800 dark:hover:text-gray-100'>
                                <Languages size={6} />
                        </Button>
                    </div>
                </div>
            </div>
        </nav>
    )
}