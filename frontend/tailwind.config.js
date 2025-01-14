/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./components/**/*.{js,vue,ts}",
    "./layouts/**/*.vue",
    "./pages/**/*.vue",
    "./plugins/**/*.{js,ts}",
    "./app.vue",
    "./error.vue",
  ],
  theme: {
    extend: {
      colors:{
        primary1:'#605DEC',
        primary2:'#BCBAF7',
        primary3:'#E9E8FC',
        primaryWhite:'#F6F6FE',
        primaryDark:'1513A0',
      }
    },
  },
  plugins: [],
}

