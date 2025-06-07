'use client'

import { useDictionary } from '@/i18n/context'
import { Plane, Facebook, Twitter, Instagram, Mail, Phone } from 'lucide-react'

export default function Footer() {
  const dictionary = useDictionary()
  
  return (
    <footer className="bg-gray-900 text-white py-16">
      <div className="max-w-6xl mx-auto px-4">
        <div className="grid grid-cols-1 md:grid-cols-4 gap-8 mb-8">
          <div className="space-y-4">
            <div className="flex items-center">
              <Plane className="w-8 h-8 text-blue-400 mr-3" />
              <h3 className="text-2xl font-bold">Reservely</h3>
            </div>
            <p className="text-gray-400 leading-relaxed">
              {dictionary.landingPage.footer.description}
            </p>
            <div className="flex space-x-4">
              <Facebook className="w-6 h-6 text-gray-400 hover:text-blue-400 cursor-pointer transition-colors" />
              <Twitter className="w-6 h-6 text-gray-400 hover:text-blue-400 cursor-pointer transition-colors" />
              <Instagram className="w-6 h-6 text-gray-400 hover:text-blue-400 cursor-pointer transition-colors" />
            </div>
          </div>
          
          <div>
            <h4 className="text-lg font-semibold mb-4">{dictionary.landingPage.footer.quickLinks}</h4>
            <ul className="space-y-2 text-gray-400">
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.about}</a></li>
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.destinations}</a></li>
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.deals}</a></li>
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.contact}</a></li>
            </ul>
          </div>
          
          <div>
            <h4 className="text-lg font-semibold mb-4">{dictionary.landingPage.footer.support}</h4>
            <ul className="space-y-2 text-gray-400">
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.help}</a></li>
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.cancellation}</a></li>
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.refund}</a></li>
              <li><a href="#" className="hover:text-white transition-colors">{dictionary.landingPage.footer.terms}</a></li>
            </ul>
          </div>
          
          <div>
            <h4 className="text-lg font-semibold mb-4">{dictionary.landingPage.footer.contactUs}</h4>
            <div className="space-y-3 text-gray-400">
              <div className="flex items-center">
                <Mail className="w-5 h-5 mr-3" />
                <span>support@reservely.com</span>
              </div>
              <div className="flex items-center">
                <Phone className="w-5 h-5 mr-3" />
                <span>+1 (555) 123-4567</span>
              </div>
            </div>
          </div>
        </div>
        
        <div className="border-t border-gray-800 pt-8 text-center text-gray-400">
          <p>&copy; 2025 Reservely. {dictionary.landingPage.footer.rights}</p>
        </div>
      </div>
    </footer>
  )
}