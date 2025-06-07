'use client'

import { useDictionary } from '@/i18n/context'
import { Plane, Search } from 'lucide-react'

export default function Hero() {
  const dictionary = useDictionary()
  
  return (
    <section className="relative min-h-screen bg-gradient-to-br from-blue-900 via-blue-800 to-indigo-900 flex items-center justify-center overflow-hidden">
      {/* Background Elements */}
      <div className="absolute inset-0 bg-black/20"></div>
      <div className="absolute top-20 left-10 w-72 h-72 bg-white/10 rounded-full blur-3xl"></div>
      <div className="absolute bottom-20 right-10 w-96 h-96 bg-blue-300/20 rounded-full blur-3xl"></div>
      
      {/* Content */}
      <div className="relative z-10 text-center text-white px-4 max-w-6xl mx-auto">
        <div className="mb-8 flex justify-center">
          <div className="bg-white/20 p-4 rounded-full backdrop-blur-sm">
            <Plane className="w-16 h-16 text-white" />
          </div>
        </div>
        
        <h1 className="text-5xl md:text-7xl font-bold mb-6 bg-gradient-to-r from-white to-blue-200 bg-clip-text text-transparent">
          {dictionary.landingPage.hero.title}
        </h1>
        
        <p className="text-xl md:text-2xl mb-8 text-blue-100 max-w-3xl mx-auto leading-relaxed">
          {dictionary.landingPage.hero.subtitle}
        </p>
        
        <div className="flex flex-col sm:flex-row gap-4 justify-center items-center">
          <button className="bg-white text-blue-900 px-8 py-4 rounded-full font-semibold text-lg hover:bg-blue-50 transition-all duration-300 transform hover:scale-105 shadow-xl">
            <Search className="inline w-5 h-5 mr-2" />
            {dictionary.landingPage.hero.searchButton}
          </button>
          
          <button className="border-2 border-white text-white px-8 py-4 rounded-full font-semibold text-lg hover:bg-white hover:text-blue-900 transition-all duration-300 transform hover:scale-105">
            {dictionary.landingPage.hero.learnMore}
          </button>
        </div>
      </div>
      
      {/* Floating Elements */}
      <div className="absolute top-1/4 left-1/4 animate-bounce">
        <div className="w-4 h-4 bg-white/30 rounded-full"></div>
      </div>
      <div className="absolute top-1/3 right-1/3 animate-pulse">
        <div className="w-6 h-6 bg-blue-300/40 rounded-full"></div>
      </div>
    </section>
  )
}