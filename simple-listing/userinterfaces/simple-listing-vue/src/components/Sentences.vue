<template>
<div>
    <h1>Sentences</h1>

    <p v-if="loading">
        Loading
    </p>

    <ul v-if="!loading && data && data.length">
        <li v-for="post of data" :key="post.id">
            <p><strong>{{ post.title }}</strong><small>{{ post.id }}</small></p>
            <p>{{ post.body }}</p>
        </li>
    </ul>

</div>
</template>

<script>
export default {
    name: 'Sentences',
    data() {
        return {
            loading: false,
            error: false
        }
    },
    computed: {

    },
    methods: {
        fetchData() {
            this.loading = true;
            console.log("fetchData");

            // I prefer to use fetch
            // you can use use axios as an alternative
            return fetch('http://jsonplaceholder.typicode.com/posts', {
                    method: 'get',
                    headers: {
                        'content-type': 'application/json'
                    }
                })
                .then(res => {
                    // a non-200 response code
                    console.log("fetchData: error");
                    if (!res.ok) {
                        // create error instance with HTTP status text
                        this.error = res.json();
                        throw this.error;
                    }

                    return res.json();
                })
                .then(json => {
                    console.log("fetchData: response data");
                    console.log(json);

                    // set the response data
                    this.data = json;
                })
                .catch(err => {
                    this.error = err;
                    // In case a custom JSON error response was provided
                    if (err.json) {
                        return err.json.then(json => {
                            // set the JSON response message
                            this.error = json.message;
                        });
                    }
                })
                .then(() => {
                    this.loading = false;
                });
        }

    },
    mounted() {
        this.fetchData();
    },
}
</script>
