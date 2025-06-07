'use client'

import { useDictionary } from '@/i18n/context'
import { Menu, X, Plane, Phone, Mail } from 'lucide-react'
import { useState } from 'react'

export default function NavigationBar() {
  const dictionary = useDictionary()
  const [isMenuOpen, setIsMenuOpen] = useState(false)

  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen)
  }

  return (
    <nav className="bg-white shadow-lg sticky top-0 z-50">
      <div className="max-w-6xl mx-auto px-4">
        <div className="flex justify-between items-center py-4">
          {/* Logo */}
          <div className="flex items-center">
            <Plane className="w-8 h-8 text-blue-600 mr-2" />
            <span className="text-2xl font-bold text-gray-900">Reservely</span>
          </div>

          {/* Desktop Navigation */}
          <div className="hidden md:flex items-center space-x-8">
            <a href="/" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
              {dictionary.navigation.home}
            </a>
            <a href="/destinations" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
              {dictionary.navigation.destinations}
            </a>
            <a href="/about" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
              {dictionary.navigation.about}
            </a>
            <a href="/contact" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
              {dictionary.navigation.contact}
            </a>
            <div className="flex items-center space-x-4">
              <div className="flex items-center text-gray-600">
                <Phone className="w-4 h-4 mr-1" />
                <span className="text-sm">+1 (555) 123-4567</span>
              </div>
              <button className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition-colors duration-300">
                {dictionary.navigation.bookNow}
              </button>
            </div>
          </div>

          {/* Mobile Menu Button */}
          <div className="md:hidden">
            <button onClick={toggleMenu} className="text-gray-700 hover:text-blue-600">
              {isMenuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
            </button>
          </div>
        </div>

        {/* Mobile Navigation */}
        {isMenuOpen && (
          <div className="md:hidden py-4 border-t border-gray-200">
            <div className="flex flex-col space-y-4">
              <a href="/" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
                {dictionary.navigation.home}
              </a>
              <a href="/destinations" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
                {dictionary.navigation.destinations}
              </a>
              <a href="/about" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
                {dictionary.navigation.about}
              </a>
              <a href="/contact" className="text-gray-700 hover:text-blue-600 transition-colors duration-300 font-medium">
                {dictionary.navigation.contact}
              </a>
              <div className="flex items-center text-gray-600 pt-2">
                <Phone className="w-4 h-4 mr-1" />
                <span className="text-sm">+1 (555) 123-4567</span>
              </div>
              <button className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition-colors duration-300 w-full">
                {dictionary.navigation.bookNow}
              </button>
            </div>
          </div>
        )}
      </div>
    </nav>
  )
}