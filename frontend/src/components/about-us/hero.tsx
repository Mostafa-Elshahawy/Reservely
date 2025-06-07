'use client'

import { useDictionary } from '@/i18n/context'
import { Globe, Users, Award, MapPin } from 'lucide-react'

export default function AboutHero() {
  const dictionary = useDictionary()

  return (
    <section className="relative py-20 bg-gradient-to-r from-blue-600 to-blue-800 text-white">
      <div 
        className="absolute inset-0 bg-cover bg-center opacity-20"
        style={{
          backgroundImage: 'url(https://images.unsplash.com/photo-1488646953014-85cb44e25828?w=1920&h=1080&fit=crop)'
        }}
      ></div>
      <div className="relative max-w-6xl mx-auto px-4">
        <div className="text-center mb-16">
          <h1 className="text-5xl font-bold mb-6">
            {dictionary.aboutPage.hero.title}
          </h1>
          <p className="text-xl max-w-3xl mx-auto">
            {dictionary.aboutPage.hero.subtitle}
          </p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          <div className="text-center">
            <div className="bg-white bg-opacity-20 rounded-full w-16 h-16 flex items-center justify-center mx-auto mb-4">
              <Globe className="w-8 h-8" />
            </div>
            <h3 className="text-2xl font-bold mb-2">150+</h3>
            <p className="text-blue-100">{dictionary.aboutPage.hero.destinations}</p>
          </div>
          
          <div className="text-center">
            <div className="bg-white bg-opacity-20 rounded-full w-16 h-16 flex items-center justify-center mx-auto mb-4">
              <Users className="w-8 h-8" />
            </div>
            <h3 className="text-2xl font-bold mb-2">50K+</h3>
            <p className="text-blue-100">{dictionary.aboutPage.hero.customers}</p>
          </div>
          
          <div className="text-center">
            <div className="bg-white bg-opacity-20 rounded-full w-16 h-16 flex items-center justify-center mx-auto mb-4">
              <Award className="w-8 h-8" />
            </div>
            <h3 className="text-2xl font-bold mb-2">15</h3>
            <p className="text-blue-100">{dictionary.aboutPage.hero.experience}</p>
          </div>
        </div>
      </div>
    </section>
  )
}