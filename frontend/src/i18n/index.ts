import 'server-only'

import type {Locale} from '@/i18n/config'

const dictionaries = {
    en: () => import('@/i18n/dictionaries/en.json').then((module) => module.default),
    ar: () => import('@/i18n/dictionaries/ar.json').then((module) => module.default),
}

export const getDictionary = async (locale: Locale) => dictionaries[locale]()

export type Dictionary = Awaited<ReturnType<typeof getDictionary>>