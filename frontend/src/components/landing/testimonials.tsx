'use client'

import { useDictionary } from '@/i18n/context'
import { Star, Quote } from 'lucide-react'

export default function Testimonials() {
  const dictionary  = useDictionary()
  
  return (
    <section className="py-20 bg-blue-900 text-white">
      <div className="max-w-6xl mx-auto px-4">
        <div className="text-center mb-16">
          <h2 className="text-4xl font-bold mb-4">
            {dictionary.landingPage.testimonials.title}
          </h2>
          <p className="text-xl text-blue-200">
            {dictionary.landingPage.testimonials.subtitle}
          </p>
        </div>
        
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          {[1, 2, 3].map((index) => (
            <div key={index} className="bg-white/10 backdrop-blur-sm rounded-xl p-8 hover:bg-white/20 transition-all duration-300">
              <div className="flex items-center mb-4">
                {[1, 2, 3, 4, 5].map((star) => (
                  <Star key={star} className="w-5 h-5 text-yellow-400 fill-current" />
                ))}
              </div>
              <Quote className="w-8 h-8 text-blue-300 mb-4" />
              <p className="text-blue-100 mb-6 leading-relaxed">
                {(dictionary.landingPage.testimonials[`testimonial${index}` as keyof typeof dictionary.landingPage.testimonials] as { content: string; name: string; location: string }).content}
              </p>
              <div className="flex items-center">
                <div className="w-12 h-12 bg-blue-600 rounded-full flex items-center justify-center text-white font-semibold mr-4">
                  {(dictionary.landingPage.testimonials[`testimonial${index}` as keyof typeof dictionary.landingPage.testimonials] as { content: string; name: string; location: string }).name.charAt(0)}
                </div>
                <div>
                  <p className="font-semibold text-white">
                    {(dictionary.landingPage.testimonials[`testimonial${index}` as keyof typeof dictionary.landingPage.testimonials] as { content: string; name: string; location: string }).name}
                  </p>
                  <p className="text-blue-300 text-sm">
                    {(dictionary.landingPage.testimonials[`testimonial${index}` as keyof typeof dictionary.landingPage.testimonials] as { content: string; name: string; location: string }).location}
                  </p>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  )
}