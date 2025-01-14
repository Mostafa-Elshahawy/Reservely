// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-11-01',
  devtools: { enabled: true },
  css: ['~/assets/css/main.css'],
  components:{
    dirs:[
      '~/components',
    ]
  },
  postcss:{
    plugins:{
      tailwindcss: {},
      autoprefixer:{},
    },
  },

  modules: [
    '@nuxtjs/i18n',
    '@pinia/nuxt',
    'radix-vue/nuxt',
    '@nuxt/icon'
  ],
  i18n:{
    locales: [
      {code:'en',file:'en.json',dir:'ltr',name:'english'}, 
      {code:'ar', file:'ar.json',dir:'rtl',name:'العربية'}
    ],
    lazy:true,
    langDir:'locales',
    defaultLocale: 'en',
    strategy:'prefix',
    detectBrowserLanguage:{
      useCookie:true,
      cookieKey:'i18n_redirected',
    }
  }
})