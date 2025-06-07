'use client'

import { useDictionary } from '@/i18n/context'
import { MapPin, Plane } from 'lucide-react'

export default function PopularDestinations() {
  const dictionary  = useDictionary()
  
  const destinations = [
    {
      name: 'Paris',
      image: 'https://images.unsplash.com/photo-1502602898536-47ad22581b52?w=500&h=300&fit=crop',
      price: '$599'
    },
    {
      name: 'Tokyo',
      image: 'https://images.unsplash.com/photo-1540959733332-eab4deabeeaf?w=500&h=300&fit=crop',
      price: '$899'
    },
    {
      name: 'New York',
      image: 'https://images.unsplash.com/photo-1496442226666-8d4d0e62e6e9?w=500&h=300&fit=crop',
      price: '$449'
    },
    {
      name: 'Dubai',
      image: 'https://images.unsplash.com/photo-1512453979798-5ea266f8880c?w=500&h=300&fit=crop',
      price: '$699'
    },
    {
      name: 'London',
      image: 'https://images.unsplash.com/photo-1513635269975-59663e0ac1ad?w=500&h=300&fit=crop',
      price: '$529'
    },
    {
      name: 'Barcelona',
      image: 'https://images.unsplash.com/photo-1539037116277-4db20889f2d4?w=500&h=300&fit=crop',
      price: '$399'
    }
  ]
  
  return (
    <section className="py-20 bg-gray-50">
      <div className="max-w-6xl mx-auto px-4">
        <div className="text-center mb-16">
          <h2 className="text-4xl font-bold text-gray-900 mb-4">
            {dictionary.landingPage.destinations.title}
          </h2>
          <p className="text-xl text-gray-600">
            {dictionary.landingPage.destinations.subtitle}
          </p>
        </div>
        
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {destinations.map((destination, index) => (
            <div key={index} className="bg-white rounded-xl overflow-hidden shadow-lg hover:shadow-2xl transition-all duration-300 transform hover:scale-105 cursor-pointer">
              <div className="relative">
                <img 
                  src={destination.image} 
                  alt={destination.name}
                  className="w-full h-48 object-cover"
                />
                <div className="absolute top-4 right-4 bg-white px-3 py-1 rounded-full text-sm font-semibold text-blue-600">
                  {destination.price}
                </div>
              </div>
              <div className="p-6">
                <h3 className="text-xl font-semibold text-gray-900 mb-2 flex items-center">
                  <MapPin className="w-5 h-5 text-blue-600 mr-2" />
                  {destination.name}
                </h3>
                <p className="text-gray-600 mb-4">
                  {dictionary.landingPage.destinations.from} {destination.price}
                </p>
                <button className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition-colors duration-300 flex items-center justify-center">
                  <Plane className="w-4 h-4 mr-2" />
                  {dictionary.landingPage.destinations.bookNow}
                </button>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  )
}