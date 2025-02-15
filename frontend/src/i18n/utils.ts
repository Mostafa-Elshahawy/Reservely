import {i18n} from '@/i18n/config'
import {ensurePrefix} from '@/lib/utils'
import {match as matchLocale} from '@formatjs/intl-localematcher'
import Negotiator from 'negotiator'

import {NextRequest, NextResponse} from 'next/server'

export const isUrlMissingLocale = (url:string)=>{
    return i18n.locales.every(
        locale => !(url.startsWith(`/${locale}/`) || url === `/${locale}`)
    )
}

export const getLocalizedUrl=(url:string, languageCode:string):string=>{
    if(!url || !languageCode)
        throw new Error("URL or language code cannot be empty")

    return isUrlMissingLocale(url) ? `/${languageCode}${ensurePrefix(url, '/')}` : url
}

export const getLocale = async (request:NextRequest):Promise<string>=>{
    const urlLocale = i18n.locales.find(locale =>
        request.nextUrl.pathname.startsWith(`/${locale}`)
    )
    if(urlLocale) return urlLocale

    const negotiatorHeaders: Record<string, string> = {}

    request.headers.forEach((value, key) => (negotiatorHeaders[key] = value))

    const locales: string[] = [...i18n.locales]

    const languages = new Negotiator({headers: negotiatorHeaders}).languages(
        locales
      )
    
    const locale = matchLocale(languages, locales, i18n.defaultLocale)

 return locale
}

export const localizedRedirect = (
    url: string,
    locale: string | undefined,
    request:NextRequest
)=>{
    let _url = url
    const isLocaleMissing = isUrlMissingLocale(url)
    if(isLocaleMissing){
        _url = getLocalizedUrl(_url, locale ?? i18n.defaultLocale)
    }
    const _basePath = process.env.BASEPATH ?? ''

    _url = String(ensurePrefix(_url, `${_basePath ?? ''}`))

    const redirectUrl = new URL(_url, request.url).toString()

    return NextResponse.redirect(redirectUrl)
}