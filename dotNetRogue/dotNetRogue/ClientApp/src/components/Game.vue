<template>
    <h1>dotNetRogue</h1>

    <p v-if="enemy != null">{{enemy.name}} attacks you!</p>

    <p aria-live="polite" v-if="enemy != null">Current enemy health: <strong>{{ enemy.health }}</strong></p>
    <p v-if="weapon != null">You have a {{weapon.name}}</p>
    <button v-if="weapon != null && enemy != null" class="btn btn-primary" @click="attack">Attack!</button>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Counter",
        data() {
            return {
                weapon: null,
                enemy: null,
            }
        },
        methods: {
            attack() {
                var dmg = Math.floor(Math.random() * this.weapon.stats["Attack"]) + 1;
                this.enemy.health = this.enemy.health - dmg;
            },
            getWeapon() {
                axios.get('/weapon')
                    .then((response) => {
                        this.weapon = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            getEnemy() {
                axios.get('/enemy')
                    .then((response) => {
                        this.enemy = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
        },
        mounted() {
            this.getWeapon();
            this.getEnemy();
        }
    }
</script>