import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import NavigationBar from '@/components/core/navigation-bar'
import ContactHero from '@/components/contact-us/hero'
import ContactForm from '@/components/contact-us/contact-form'

interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){
    return (
        <div className="bg-white min-h-screen">
            <NavigationBar />
            <ContactHero />
            <ContactForm />
        </div>
    )
}

export default withPageDictionary(Page)