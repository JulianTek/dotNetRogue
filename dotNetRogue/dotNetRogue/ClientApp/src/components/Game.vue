<template>
    <h1>dotNetRogue</h1>

    <p v-if="enemy != null">{{enemy.name}} attacks you!</p>

    <p aria-live="polite" v-if="enemy != null">Current enemy health: <strong>{{ enemy.health }}</strong></p>
    <p>Your health is: <strong>{{playerHealth}}</strong></p>
    <p v-if="weapon != null">You have a {{weapon.name}}</p>
    <button v-if="weapon != null && enemy != null && canAttack" class="btn btn-primary" @click="attack">Attack!</button>
    <button v-if="!canAttack" class="btn btn-primary" @click="block(enemyAttack())">Block!</button>
    <button v-if="!canAttack" class="btn btn-primary" @click="dodge(enemyAttack())">Dodge!</button>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Game",
        data() {
            return {
                playerHealth: 100,
                canAttack: true,
                weapon: null,
                enemy: null,
            }
        },
        methods: {
            attack() {
                var dmg = Math.floor(Math.random() * this.weapon.stats["Attack"]) + Math.round(this.weapon.stats["Attack"] / 2);
                this.enemy.health = this.enemy.health - dmg;
                this.canAttack = false;
            },
            block(enemyDmg) {
                this.playerHealth = this.playerHealth - Math.round((enemyDmg * (this.weapon.stats["Defense"] / 100)));
                this.canAttack = true;
            },
            dodge(enemyDmg) {
                var newDodgeChance = this.weapon.stats["Dodge"] + Math.floor(Math.random() * 10) + 1;
                var nr = Math.floor(Math.random() * 100) + 1;
                if (nr < newDodgeChance) {
                    // Dodge is succesful
                }
                else {
                    this.playerHealth = this.playerHealth - enemyDmg;
                }
                this.canAttack = true;
            },
            enemyAttack() {
                var dmg = Math.floor(Math.random() * this.enemy.attack) + Math.round(this.enemy.attack / 2);
                return dmg;
            },
            getWeapon() {
                axios.get('/weapongenerator')
                    .then((response) => {
                        this.weapon = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            getEnemy() {
                axios.get('/enemygenerator')
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