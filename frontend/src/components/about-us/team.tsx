'use client'

import { useDictionary } from '@/i18n/context'
import { Linkedin, Twitter, Mail } from 'lucide-react'

export default function TeamSection() {
  const dictionary = useDictionary()

  const teamMembers = [
    {
      name: 'Sarah Johnson',
      position: dictionary.aboutPage.team.members.ceo,
      image: 'https://images.unsplash.com/photo-1494790108755-2616b612b786?w=300&h=300&fit=crop',
      bio: dictionary.aboutPage.team.bios.sarah
    },
    {
      name: 'Michael Chen',
      position: dictionary.aboutPage.team.members.cto,
      image: 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=300&h=300&fit=crop',
      bio: dictionary.aboutPage.team.bios.michael
    },
    {
      name: 'Emma Rodriguez',
      position: dictionary.aboutPage.team.members.operations,
      image: 'https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=300&h=300&fit=crop',
      bio: dictionary.aboutPage.team.bios.emma
    },
    {
      name: 'David Thompson',
      position: dictionary.aboutPage.team.members.marketing,
      image: 'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=300&h=300&fit=crop',
      bio: dictionary.aboutPage.team.bios.david
    }
  ]

  return (
    <section className="py-20 bg-gray-50">
      <div className="max-w-6xl mx-auto px-4">
        <div className="text-center mb-16">
          <h2 className="text-4xl font-bold text-gray-900 mb-4">
            {dictionary.aboutPage.team.title}
          </h2>
          <p className="text-xl text-gray-600">
            {dictionary.aboutPage.team.subtitle}
          </p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
          {teamMembers.map((member, index) => (
            <div key={index} className="bg-white rounded-xl shadow-lg overflow-hidden hover:shadow-2xl transition-all duration-300 transform hover:scale-105">
              <img 
                src={member.image} 
                alt={member.name}
                className="w-full h-64 object-cover"
              />
              <div className="p-6">
                <h3 className="text-xl font-semibold text-gray-900 mb-1">
                  {member.name}
                </h3>
                <p className="text-blue-600 font-medium mb-3">
                  {member.position}
                </p>
                <p className="text-gray-600 text-sm mb-4">
                  {member.bio}
                </p>
                <div className="flex space-x-3">
                  <button className="text-gray-400 hover:text-blue-600 transition-colors duration-300">
                    <Linkedin className="w-5 h-5" />
                  </button>
                  <button className="text-gray-400 hover:text-blue-600 transition-colors duration-300">
                    <Twitter className="w-5 h-5" />
                  </button>
                  <button className="text-gray-400 hover:text-blue-600 transition-colors duration-300">
                    <Mail className="w-5 h-5" />
                  </button>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  )
}