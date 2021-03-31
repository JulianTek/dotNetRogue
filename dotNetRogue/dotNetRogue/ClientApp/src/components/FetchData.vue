<template>
    <h1 id="tableLabel">Weapon data</h1>

    <p>This component demonstrates fetching data from the server.</p>

    <p v-if="!weapons"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="weapons">
        <thead>
            <tr>
                <th>Name</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="weapon of weapons" v-bind:key="weapon.name">
                <td>{{ weapon.name }}</td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "FetchData",
        data() {
            return {
                weapons: []
            }
        },
        methods: {
            getWeatherForecasts() {
                axios.get('/weapon')
                    .then((response) => {
                        this.weapons = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getWeatherForecasts();
        }
    }
</script>