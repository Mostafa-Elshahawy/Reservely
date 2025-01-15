<script setup lang="ts">
    import { useI18n } from 'vue-i18n';
    import {ref} from "vue";


    const {t, setLocale} = useI18n();
    const isMobileOpen = ref(false);
    const navLinks = [
        {name:'home', path:'/'},
        {name:'flights', path:'flights'},
        {name:'signIn', path:'signin'},
        {name:'signUp', path:'signup'},
    ];
</script>
<template>
    <header class="bg-white">
        <div class="container mx-auto px-4 flex justify-between items-center h-16">
            <!-- Logo -->
            <div class="flex items-center">
                <img src="/logo.png" alt="logo" class="h-10 w-auto" />
            </div>

            <!-- Desktop -->
            <nav class="hidden md:flex space-x-8">
                <NuxtLink v-for="link in navLinks" :key="link.name" :to="link.path" class="text-gray-700 hover:text-primary transition">
                    {{ t(`navbar.${link.name}`) }}
                </NuxtLink>
            </nav>

            <!-- Mobile Menu Button -->
            <button @click="isMobileOpen = !isMobileOpen" class="md:hidden text-gray-700 focus:outline-none">
                <Icon name="mdi:menu" />
            </button>

            <!-- Mobile -->
            <div v-if="isMobileOpen" class="md:hidden bg-white shadow-md px-4 py-2">
                <nav class="space-y-2">
                    <NuxtLink v-for="link in navLinks" :key="link.name" :to="link.path" class="text-gray-700 hover:text-primary transition">
                        {{ t(`navbar.${link.name}`) }}
                    </NuxtLink>
                </nav>
            </div>
        </div>
    </header>
</template>