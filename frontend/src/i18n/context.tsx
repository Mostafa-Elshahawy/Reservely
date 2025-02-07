'use client' 

import {ReactNode, createContext, useContext} from 'react'
import { Dictionary } from '.'

const DictionaryContext = createContext<Dictionary>({})

export const useDictionary = ()=> {
    const dictionary = useContext(DictionaryContext) 

    if(!dictionary){
        throw new Error ('useDictionary must be used within a DictionaryProvider')
    }

    return dictionary
}

export const DictionaryProvider:React.FC<{
    dictionary:Dictionary
    children:ReactNode
}> = ({dictionary,children})=>{
    return (
        <DictionaryContext.Provider value={dictionary}>
            {children}
        </DictionaryContext.Provider>
    )
}

export default DictionaryContext

