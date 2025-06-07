'use client'
import { useDictionary } from '@/i18n/context'
import { MapPin, Calendar, Users, ArrowRight } from 'lucide-react'

export default function SearchForm() {
  const dictionary = useDictionary()
  
  return (
    <section className="py-20 bg-gray-50">
      <div className="max-w-6xl mx-auto px-4">
        <div className="text-center mb-12">
          <h2 className="text-4xl font-bold text-gray-900 mb-4">
            {dictionary.landingPage.searchForm.title}
          </h2>
          <p className="text-xl text-gray-600">
            {dictionary.landingPage.searchForm.subtitle}
          </p>
        </div>
        
        <div className="bg-white rounded-2xl shadow-2xl p-8 max-w-4xl mx-auto">
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
            <div className="space-y-2">
              <label className="text-sm font-semibold text-gray-700 flex items-center">
                <MapPin className="w-4 h-4 mr-2 text-blue-600" />
                {dictionary.landingPage.searchForm.from}
              </label>
              <input 
                type="text" 
                placeholder={dictionary.landingPage.searchForm.fromPlaceholder}
                className="w-full p-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              />
            </div>
            
            <div className="space-y-2">
              <label className="text-sm font-semibold text-gray-700 flex items-center">
                <MapPin className="w-4 h-4 mr-2 text-blue-600" />
                {dictionary.landingPage.searchForm.to}
              </label>
              <input 
                type="text" 
                placeholder={dictionary.landingPage.searchForm.toPlaceholder}
                className="w-full p-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              />
            </div>
            
            <div className="space-y-2">
              <label className="text-sm font-semibold text-gray-700 flex items-center">
                <Calendar className="w-4 h-4 mr-2 text-blue-600" />
                {dictionary.landingPage.searchForm.departure}
              </label>
              <input 
                type="date" 
                className="w-full p-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              />
            </div>
            
            <div className="space-y-2">
              <label className="text-sm font-semibold text-gray-700 flex items-center">
                <Users className="w-4 h-4 mr-2 text-blue-600" />
                {dictionary.landingPage.searchForm.passengers}
              </label>
              <select className="w-full p-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                <option>1 {dictionary.landingPage.searchForm.passenger}</option>
                <option>2 {dictionary.landingPage.searchForm.passengers}</option>
                <option>3 {dictionary.landingPage.searchForm.passengers}</option>
                <option>4+ {dictionary.landingPage.searchForm.passengers}</option>
              </select>
            </div>
          </div>
          
          <button className="w-full bg-gradient-to-r from-blue-600 to-indigo-600 text-white py-4 rounded-lg font-semibold text-lg hover:from-blue-700 hover:to-indigo-700 transition-all duration-300 transform hover:scale-[1.02] shadow-lg">
            {dictionary.landingPage.searchForm.searchButton}
            <ArrowRight className="inline w-5 h-5 ml-2" />
          </button>
        </div>
      </div>
    </section>
  )
}