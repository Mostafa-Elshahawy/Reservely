'use client'

import { useDictionary } from '@/i18n/context'
import { Shield, Clock, CreditCard, Headphones, Star, Globe } from 'lucide-react'

export default function Features() {
  const dictionary = useDictionary()
  
  const features = [
    {
      icon: Shield,
      key: 'secure'
    },
    {
      icon: Clock,
      key: 'fast'
    },
    {
      icon: CreditCard,
      key: 'payment'
    },
    {
      icon: Headphones,
      key: 'support'
    },
    {
      icon: Star,
      key: 'quality'
    },
    {
      icon: Globe,
      key: 'global'
    }
  ]
  
  return (
    <section className="py-20 bg-white">
      <div className="max-w-6xl mx-auto px-4">
        <div className="text-center mb-16">
          <h2 className="text-4xl font-bold text-gray-900 mb-4">
            {dictionary.landingPage.features.title}
          </h2>
          <p className="text-xl text-gray-600 max-w-2xl mx-auto">
            {dictionary.landingPage.features.subtitle}
          </p>
        </div>
        
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {features.map((feature, index) => {
            const Icon = feature.icon
            return (
              <div key={index} className="text-center p-8 rounded-xl bg-gradient-to-br from-blue-50 to-indigo-50 hover:from-blue-100 hover:to-indigo-100 transition-all duration-300 transform hover:scale-105 hover:shadow-lg">
                <div className="bg-blue-600 w-16 h-16 rounded-full flex items-center justify-center mx-auto mb-6">
                  <Icon className="w-8 h-8 text-white" />
                </div>
                <h3 className="text-xl font-semibold text-gray-900 mb-4">
                  {(dictionary.landingPage.features[feature.key as keyof typeof dictionary.landingPage.features] as { title: string; description: string }).title}
                </h3>
                <p className="text-gray-600 leading-relaxed">
                  {(dictionary.landingPage.features[feature.key as keyof typeof dictionary.landingPage.features] as { title: string; description: string }).description}
                </p>
              </div>
            )
          })}
        </div>
      </div>
    </section>
  )
}