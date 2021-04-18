<template>
  <v-app>
    <v-main>
      <div id="app">
        <Sentences />
      </div>
    </v-main>
  </v-app>
</template>

<script>
import Sentences from './components/Sentences.vue';

export default {
  name: 'App',

  components: {
    Sentences,
  },

  data: () => ({
    //
  }),
};
</script>
