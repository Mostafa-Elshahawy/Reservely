import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'


interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){
    return (
        <></>
    )
}

export default withPageDictionary(Page)