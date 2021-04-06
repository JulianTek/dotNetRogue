using dotNetRogue.Logic.Models;
<style type="text/css">
    #overlay {
        position: fixed;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background: rgba(0,0,0, 0.5);
    }
</style>
<template>
    <h1>Enemy types:</h1>
    <table class='table table-striped' aria-labelledby="tableLabel" v-if="enemyTypes">
        <thead>
            <tr>
                <th>Name</th>
                <th>Attack</th>
                <th>Health</th>
                <th>Defense</th>
                <th>Speed</th>
                <th>Gold on kill</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="enemy of enemyTypes" v-bind:key="enemy.name">
                <td>{{ enemy.name }}</td>
                <td>{{ enemy.health }}</td>
                <td>{{ enemy.attack }}</td>
                <td>{{ enemy.defense }}</td>
                <td>{{ enemy.speed }}</td>
                <td>{{ enemy.goldOnKill }}</td>
            </tr>
        </tbody>
    </table>

    <!--Adding enemy type-->
    <div id="overlay" v-if="showOverlay">
        <div class="modal-dialogue">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add new enemy type</h5>
                    <button type="button" class="close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <input type="text" name="name" class="form-control form-control-lg" placeholder="Name" />
                    <input type="text" name="health" class="form-control form-control-lg" placeholder="Heatlh" />
                    <input type="text" name="attack" class="form-control form-control-lg" placeholder="Attack" />
                    <input type="text" name="defense" class="form-control form-control-lg" placeholder="Defense" />
                    <input type="text" name="speed" class="form-control form-control-lg" placeholder="Speed" />
                    <input type="text" name="goldOnKill" class="form-control form-control-lg" placeholder="Gold on kill" />
                </div>
                <div class="form-group">
                    <button class="btn btn-info btn-block btn-lg">>Add enemy type</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "Game",
        data() {
            return {
                enemyTypes: [],
                showOverlay:
                    false,
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