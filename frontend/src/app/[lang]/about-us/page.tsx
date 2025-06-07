import {Dictionary} from '@/i18n'
import withPageDictionary from '@/i18n/hoc'
import NavigationBar from '@/components/core/navigation-bar'
import AboutHero from '@/components/about-us/hero'
import AboutStory from '@/components/about-us/story'
import TeamSection from '@/components/about-us/team'

interface Props {
    dictionary:Dictionary
}

function Page({dictionary}:Props){
    return (
        <div className="bg-white min-h-screen">
            <NavigationBar />
            <AboutHero />
            <AboutStory />
            <TeamSection />
        </div>
    )
}

export default withPageDictionary(Page)