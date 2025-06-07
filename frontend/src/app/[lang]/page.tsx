import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import Hero from '@/components/landing/hero'
import SearchForm from '@/components/landing/search-form'
import Features from '@/components/landing/features'
import PopularDestinations from '@/components/landing/popular-destinations'
import Testimonials from '@/components/landing/testimonials'
import Footer from '@/components/landing/footer'
interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){
    return (
        <>
            <Hero />
            <SearchForm />
            <Features />
            <PopularDestinations />
            <Testimonials />
            <Footer />
        </>
    )
}

export default withPageDictionary(Page)