<template>
    <div :dir="$i18n.locale === 'ar' ? 'rtl' : 'ltr'">
        <NuxtLayout>
            <NuxtPage />
        </NuxtLayout>
    </div>
</template>
