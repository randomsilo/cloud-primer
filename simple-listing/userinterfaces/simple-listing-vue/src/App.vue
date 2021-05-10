<template>
<div class="content-section">
    <Panel header="Simple Listing Vue">
        Simple data access from a .net webapi connected to postgres.
    </Panel>
    <div class="card">
        <Sentences />
    </div>
</div>
</template>

<script>
import Sentences from './components/Sentences.vue';

export default {
    name: 'App',

    components: {
        Sentences,
    },

    data() {
        return {
            
        }
    }
};
</script>
