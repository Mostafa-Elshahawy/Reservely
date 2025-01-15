<script setup lang="ts">
import { useI18n } from 'vue-i18n';
const {t, setLocale} = useI18n();
</script>
<template>
    <div class="bg-gray-200 m-12">
        <!-- <h1>{{ t('welcome') }}</h1>
        <h2>{{ t('home.title') }}</h2>
        <p>{{ t('home.description') }}</p> -->
        
        <button @click="setLocale('en')" class="p-2 m-1 rounded bg-gray-500">English</button>
        <button @click="setLocale('ar')" class="p-2 m-1 rounded bg-gray-500">العربية</button>
    </div>
</template>