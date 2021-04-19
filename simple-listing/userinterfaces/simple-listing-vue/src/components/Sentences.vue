<template>
<div>
    <Message v-if="loading" severity="warn" :life="5000" :sticky="false">Loading</Message>

    <div>
        <DataTable :value="data" stripedRows responsiveLayout="scroll">
            <Column field="id" header="ID"></Column>
            <Column field="sentence" header="Sentence"></Column>
        </DataTable>
    </div>
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
            return fetch('http://localhost:8100/api/sentence/fetchall', {
                    method: 'get',
                    headers: {
                        'content-type': 'application/json'
                    }
                })
                .then(res => {
                    // a non-200 response code
                    if (!res.ok) {
                        // create error instance with HTTP status text
                        this.error = res.json();
                        throw this.error;
                    }

                    return res.json();
                })
                .then(json => {
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
