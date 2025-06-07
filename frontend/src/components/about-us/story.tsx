'use client'

import { useDictionary } from '@/i18n/context'
import { Heart, Shield, Star } from 'lucide-react'

export default function AboutStory() {
  const dictionary = useDictionary()

  const values = [
    {
      icon: Heart,
      title: dictionary.aboutPage.story.values.passion.title,
      description: dictionary.aboutPage.story.values.passion.description
    },
    {
      icon: Shield,
      title: dictionary.aboutPage.story.values.trust.title,
      description: dictionary.aboutPage.story.values.trust.description
    },
    {
      icon: Star,
      title: dictionary.aboutPage.story.values.excellence.title,
      description: dictionary.aboutPage.story.values.excellence.description
    }
  ]

  return (
    <section className="py-20 bg-white">
      <div className="max-w-6xl mx-auto px-4">
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 items-center">
          <div>
            <h2 className="text-4xl font-bold text-gray-900 mb-6">
              {dictionary.aboutPage.story.title}
            </h2>
            <p className="text-lg text-gray-600 mb-6">
              {dictionary.aboutPage.story.description1}
            </p>
            <p className="text-lg text-gray-600 mb-8">
              {dictionary.aboutPage.story.description2}
            </p>
            
            <div className="space-y-6">
              {values.map((value, index) => (
                <div key={index} className="flex items-start">
                  <div className="bg-blue-100 rounded-lg p-3 mr-4">
                    <value.icon className="w-6 h-6 text-blue-600" />
                  </div>
                  <div>
                    <h3 className="text-xl font-semibold text-gray-900 mb-2">
                      {value.title}
                    </h3>
                    <p className="text-gray-600">
                      {value.description}
                    </p>
                  </div>
                </div>
              ))}
            </div>
          </div>
          
          <div className="relative">
            <img 
              src="https://images.unsplash.com/photo-1551836022-deb4988cc6c0?w=600&h=400&fit=crop" 
              alt="Travel team"
              className="rounded-xl shadow-2xl"
            />
            <div className="absolute -bottom-6 -left-6 bg-blue-600 text-white p-6 rounded-xl">
              <h4 className="text-2xl font-bold">2009</h4>
              <p className="text-blue-100">{dictionary.aboutPage.story.founded}</p>
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}