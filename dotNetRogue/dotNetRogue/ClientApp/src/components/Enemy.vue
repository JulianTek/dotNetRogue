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
                <th></th>
                <th>Name</th>
                <th>Health</th>
                <th>Attack</th>
                <th>Defense</th>
                <th>Speed</th>
                <th>Gold on kill</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="enemy of enemyTypes" v-bind:key="enemy.name">
                <button @click="editEnemyOverlay(enemy.name, enemy.health, enemy.attack, enemy.defense, enemy.speed, enemy.goldOnKill)">Edit</button>
                <td>{{ enemy.name }}</td>
                <td>{{ enemy.health }}</td>
                <td>{{ enemy.attack }}</td>
                <td>{{ enemy.defense }}</td>
                <td>{{ enemy.speed }}</td>
                <td>{{ enemy.goldOnKill }}</td>
                <button class="btn btn-danger" @click="deleteEnemy(enemy.name)">Delete</button>
            </tr>
        </tbody>
    </table>

    <!--Adding enemy type-->
    <div id="overlay" v-if="showAddOverlay">
        <div class="modal-dialogue">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add new enemy type</h5>
                    <button type="button" class="close">
                        <span aria-hidden="true" @click="hideAddEnemyOverlay">&times;</span>
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

    <!--Editing data type-->
    <div id="overlay" v-if="showEditOverlay">
        <div class="modal-dialogue">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edit enemy type</h5>
                    <button type="button" class="close">
                        <span aria-hidden="true" @click="hideEditEnemyOverlay">&times;</span>
                    </button>
                </div>
                <form class="modal-body">
                    <input type="text" name="name" v-model="this.name" class="form-control form-control-lg" disabled placeholder="Name" />
                    <input type="number" name="health" v-model="this.health" class="form-control form-control-lg" placeholder="Heatlh" />
                    <input type="number" name="attack" v-model="this.attack" class="form-control form-control-lg" placeholder="Attack" />
                    <input type="number" name="defense" v-model="this.defense" class="form-control form-control-lg" placeholder="Defense" />
                    <input type="number" name="speed" v-model="this.speed" class="form-control form-control-lg" placeholder="Speed" />
                    <input type="number" name="goldOnKill" v-model="goldOnKill" class="form-control form-control-lg" placeholder="Gold on kill" />
                </form>
                <div class="form-group">
                    <button class="btn btn-info btn-block btn-lg" @click="updateEnemy">Update enemy type</button>
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
                showAddOverlay: false,
                showEditOverlay: false,
                name: "",
                health: 0,
                attack: 0,
                defense: 0,
                speed: 0,
                goldOnKill: 0
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
                this.showAddOverlay = true;
            },
            editEnemyOverlay(name, health, attack, defense, speed, goldOnKill) {
                this.name = name;
                this.health = health;
                this.attack = attack;
                this.defense = defense;
                this.speed = speed;
                this.goldOnKill = goldOnKill;
                this.showEditOverlay = true;
            },
            hideAddEnemyOverlay() {
                this.showAddOverlay = false;
            },
            hideEditEnemyOverlay() {
                this.showEditOverlay = false;
            },
            async addEnemy() {
                await axios.post('/enemy', { name: this.name, health: this.health, attack: this.attack, defense: this.defense, speed: this.speed, goldOnKill: this.goldOnKill }).then((response) => {
                    console.log(response);
                })
                    .catch(function (error) {
                        alert(error.message);
                    });
                this.enemyTypes.push({ name: this.name, health: this.health, attack: this.attack, defense: this.defense, speed: this.speed, goldOnKill: this.goldOnKill });
                this.showAddOverlay = false;
            },
            async updateEnemy() {
                await axios.put('/enemy', { name: this.name, health: this.health, attack: this.attack, defense: this.defense, speed: this.speed, goldOnKill: this.goldOnKill }).then((response) => {
                    console.log(response);
                })
                    .catch(function (error) {
                        alert(error.message);
                    });
                this.updateArray(this.name);
                this.showEditOverlay = false;
            },
            updateArray(name) {
                for (var i = 0; i < this.enemyTypes.length; i++) {
                    if (this.enemyTypes[i].name == name) {
                        this.enemyTypes[i].health = this.health;
                        this.enemyTypes[i].attack = this.attack;
                        this.enemyTypes[i].defense = this.defense;
                        this.enemyTypes[i].speed = this.speed;
                        this.enemyTypes[i].goldOnKill = this.goldOnKill;
                        break;
                    }
                }
            },
            async deleteEnemy(name) {
                await axios.delete('/enemy/' + name).then((response) => {
                    console.log(response);
                })
                    .catch(function (error) {
                        alert(error.message);
                    });
                this.deleteFromArray(name);
            },
            deleteFromArray(name) {
                for (var i = 0; i < this.enemyTypes.length; i++) {
                    if (this.enemyTypes[i].name == name) {
                        this.enemyTypes.splice(i, 1);
                    }
                }
            }
        },
        mounted() {
            this.getAll()
        }
    }
</script>