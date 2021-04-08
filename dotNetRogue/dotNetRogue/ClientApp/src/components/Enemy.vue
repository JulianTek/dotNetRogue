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
    <button class="btn btn-info" @click="addEnemyOverlay()">Add new enemy</button>
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
                        <span aria-hidden="true" @click="hideEnemyOverlay">&times;</span>
                    </button>
                </div>
                <form class="modal-body">
                    <input type="text" name="name" v-model="this.name" class="form-control form-control-lg" placeholder="Name" />
                    <input type="number" name="health" v-model="this.health" class="form-control form-control-lg" placeholder="Heatlh" />
                    <input type="number" name="attack" v-model="this.attack" class="form-control form-control-lg" placeholder="Attack" />
                    <input type="number" name="defense" v-model="this.defense" class="form-control form-control-lg" placeholder="Defense" />
                    <input type="number" name="speed" v-model="this.speed" class="form-control form-control-lg" placeholder="Speed" />
                    <input type="number" name="goldOnKill" v-model="goldOnKill" class="form-control form-control-lg" placeholder="Gold on kill" />
                </form>
                <div class="form-group">
                    <button class="btn btn-info btn-block btn-lg" @click="addEnemy">Add enemy type</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "Enemy",
        data() {
            return {
                enemyTypes: [],
                showOverlay: false,
                name: null,
                health: null,
                attack: null,
                defense: null,
                speed: null,
                goldOnKill: null
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
            },
            addEnemyOverlay() {
                this.showOverlay = true;
            },
            hideEnemyOverlay() {
                this.showOverlay = false;
            },
            addEnemy() {
                var enemy = {
                    name: this.name,
                    health: this.health,
                    attack: this.attack,
                    defense: this.defense,
                    speed: this.speed,
                    goldOnKill: this.goldOnKill
                }
                console.log(enemy);
                axios.post('/enemy', this.enemy).then((response) => {
                    console.log(response);
                })
                    .catch(function (error) {
                        alert(error);
                    });
                this.enemyTypes.push(enemy);
                this.showOverlay = false;   
            },
        },
        mounted() {
            this.getAll()
        }
    }
</script>