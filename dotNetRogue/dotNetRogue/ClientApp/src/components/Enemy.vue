using dotNetRogue.Logic.Models;
<template>
    <h1>Enemy types:</h1>
    <table class='table table-striped' aria-labelledby="tableLabel" v-if="enemyTypes">
        <thead>
            <tr>
                <th>Name</th>
                <th>Health</th>
                <th>Defense</th>
                <th>Speed</th>
                <th>Gold on kill</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="enemy of enemyTypes" v-bind:key="enemy.name">
                <td>{{ enemy.name }}</td>
                <td>{{enemy.health}}</td>
                <td>{{enemy.defense}}</td>
                <td>{{enemy.speed}}</td>
                <td>{{enemy.goldOnKill}}</td>
            </tr>
        </tbody>
    </table>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "Game",
        data() {
            return {
                enemyTypes: []
            }
        },
        methods: {
            getAll() {
                axios.get('/enemy')
                    .then((response) => {
                        this.enemyTypes = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },

        mounted() {
            this.getAll()
        }
    }
</script>