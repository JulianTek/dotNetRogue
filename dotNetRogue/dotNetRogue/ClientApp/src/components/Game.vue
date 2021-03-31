<template>
    <h1>dotNetRogue</h1>

    <p>An enemy attacks you!</p>

    <p aria-live="polite">Current enemy health: <strong>{{ enemyHealth }}</strong></p>
    <p v-if="weapon != null">You have a {{weapon.name}}</p>
    <button v-if="weapon != null" class="btn btn-primary" @click="attack">Attack!</button>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Counter",
        data() {
            return {
                enemyHealth: 100,
                weapon: null,
            }
        },
        methods: {
            attack() {
                var dmg = Math.floor(Math.random() * this.weapon.stats["Attack"]) + 1;
                this.enemyHealth = this.enemyHealth - dmg;
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
        },
        mounted() {
            this.getWeapon();
        }
    }
</script>