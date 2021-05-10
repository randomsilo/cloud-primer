<template>
<div>
    <Message v-if="loading" severity="warn" :life="5000" :sticky="false">Loading</Message>
    <Message v-if="adding" severity="warn" :life="5000" :sticky="false">Adding</Message>

    <div>
        <Button type="button" class="p-button-success" label="Add" @click="toggleAddOverlay" />
    </div>
    <div>
        <DataTable :value="data" stripedRows responsiveLayout="scroll">
            <Column field="id" header="ID"></Column>
            <Column field="sentence" header="Sentence"></Column>
        </DataTable>
    </div>
    <div>
        <code>
            sentenceTextbox: {{ sentenceTextbox }}
        </code>
    </div>

    <OverlayPanel ref="AddSentenceOverlay">
        <div class="card">
            <div class="p-fluid p-formgrid p-grid">
                <div class="p-field p-col">
                    <label for="sentenceTextbox">Sentence</label>
                    <InputText id="sentenceTextbox" type="text" v-model="sentenceTextbox" />
                    <Button type="button" class="p-button-success" label="Add" @click="addSentence" />
                </div>
            </div>
        </div>
    </OverlayPanel>
</div>
</template>

<script>
export default {
    name: 'Sentences',
    data() {
        return {
            loading: false,
            adding: false,
            error: false,
            sentenceTextbox: null,
        }
    },
    computed: {

    },
    methods: {
        getSentences() {
            this.loading = true;

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

        , toggleAddOverlay(event) {
            this.$refs.AddSentenceOverlay.toggle(event);
        }

        , addSentence() {
            this.adding = true;

            return fetch('http://localhost:8100/api/sentence/add', {
                    method: 'post',
                    headers: {
                        'content-type': 'application/json'
                    },
                    body: JSON.stringify({ sentence: this.sentenceTextbox })
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
                    console.log(json);
                    this.getSentences();
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
                    this.adding = false;
                    this.toggleAddOverlay();
                    this.sentenceTextbox = '';
                });
        }

    },
    mounted() {
        this.getSentences();
    },
}
</script>
