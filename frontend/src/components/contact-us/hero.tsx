'use client'

import { useDictionary } from '@/i18n/context'
import { Phone, Mail, MapPin, Clock } from 'lucide-react'

export default function ContactHero() {
  const dictionary = useDictionary()

  const contactInfo = [
    {
      icon: Phone,
      title: dictionary.contactPage.hero.info.phone.title,
      details: ['+1 (555) 123-4567', '+1 (555) 123-4568'],
      description: dictionary.contactPage.hero.info.phone.description
    },
    {
      icon: Mail,
      title: dictionary.contactPage.hero.info.email.title,
      details: ['info@reservely.com', 'support@reservely.com'],
      description: dictionary.contactPage.hero.info.email.description
    },
    {
      icon: MapPin,
      title: dictionary.contactPage.hero.info.address.title,
      details: ['123 Travel Street', 'New York, NY 10001'],
      description: dictionary.contactPage.hero.info.address.description
    },
    {
      icon: Clock,
      title: dictionary.contactPage.hero.info.hours.title,
      details: ['Mon - Fri: 9:00 AM - 6:00 PM', 'Sat - Sun: 10:00 AM - 4:00 PM'],
      description: dictionary.contactPage.hero.info.hours.description
    }
  ]

  return (
    <section className="py-20 bg-gradient-to-r from-blue-600 to-blue-800 text-white">
      <div className="max-w-6xl mx-auto px-4">
        <div className="text-center mb-16">
          <h1 className="text-5xl font-bold mb-6">
            {dictionary.contactPage.hero.title}
          </h1>
          <p className="text-xl max-w-3xl mx-auto">
            {dictionary.contactPage.hero.subtitle}
          </p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
          {contactInfo.map((info, index) => (
            <div key={index} className="text-center">
              <div className="bg-white bg-opacity-20 rounded-full w-16 h-16 flex items-center justify-center mx-auto mb-4">
                <info.icon className="w-8 h-8" />
              </div>
              <h3 className="text-xl font-bold mb-3">{info.title}</h3>
              <div className="space-y-1 mb-3">
                {info.details.map((detail, detailIndex) => (
                  <p key={detailIndex} className="text-blue-100 font-medium">
                    {detail}
                  </p>
                ))}
              </div>
              <p className="text-blue-100 text-sm">{info.description}</p>
            </div>
          ))}
        </div>
      </div>
    </section>
  )
}