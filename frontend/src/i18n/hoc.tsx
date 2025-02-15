import {Dictionary, getDictionary} from '.'
import {i18n} from '@/i18n/config'
import { DictionaryProvider } from '@/i18n/context'

export default function withPageDictionary<P extends {
    dictionary:Dictionary
    params: Promise<any>
    searchParams:Promise<any>
}>(Component:React.ComponentType<P>){
    return async function WithDictionary(props: Omit<P, 'dictionary'>){
        const dictionary = await getDictionary(
            (await props.params)?.lang || i18n.defaultLocale
        )

        return (
            <DictionaryProvider dictionary={dictionary}>
                <Component {...(props as P)} dictionary={dictionary}/>
            </DictionaryProvider>
        )
    }
}

export function withLayoutDictionary<P extends {
    dictionary:Dictionary 
    params:Promise<any> 
    children:Promise<any>
}>(Component:React.ComponentType<P>){
    return async function withDictionary(props:Omit<P, 'dictionary'>){
        const dictionary = await getDictionary( 
            (await props.params)?.lang || i18n.defaultLocale
        )

        return (
            <DictionaryProvider dictionary={dictionary}>
                <Component {...(props as P)} dictionary={dictionary}/>
            </DictionaryProvider>
        )
    }
}
