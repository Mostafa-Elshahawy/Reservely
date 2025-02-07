import {getLocale, isUrlMissingLocale, localizedRedirect} from '@/i18n/utils'
import type {NextRequest} from 'next/server'
import {NextResponse} from 'next/server'

export default async function middleware(request: NextRequest) {
  const locale = await getLocale(request)

  const pathname = request.nextUrl.pathname

  return isUrlMissingLocale(pathname)
    ? localizedRedirect(pathname, locale, request)
    : NextResponse.next()
}

export const config = {
  matcher: [
    '/((?!api|_next/static|_next/image|favicon.ico|.+?/hook-examples|.+?/menu-examples|images|next.svg|vercel.svg).*)'
  ]
}
