import {Locale, i18n} from '@/i18n/config'
import type {Metadata} from 'next'
import {Almarai, Plus_Jakarta_Sans} from 'next/font/google'
import '@/app/globals.css'

const font = Plus_Jakarta_Sans({
  subsets: ['latin'],
  display: 'swap'
})

const arabicFont = Almarai({
  subsets: ['arabic'],
  weight: ['300', '400', '700', '800'],
  display: 'swap'
})

export const metadata: Metadata = {
  title: '',
  description:'',
}

interface Props {
  children: React.ReactNode
  params: Promise<{lang: Locale}>
}

export default async function RootLayout({children, params}: Readonly<Props>) {
  const {lang} = await params
  const isArabic = lang === 'ar'
  const direction = i18n.langDirection[lang]
  const fontClassName = isArabic ? arabicFont.className : font.className

  return (
    <html lang={lang} dir={direction} suppressHydrationWarning>
      <body className={fontClassName}>
        {children}
      </body>
    </html>
  )
}
