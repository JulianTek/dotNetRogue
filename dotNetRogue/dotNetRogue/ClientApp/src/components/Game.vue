using System;
using dotNetRogue.Logic.Models;
<template>
    <h1>dotNetRogue</h1>
    <p v-if="enemy != null">You are attacked by a {{enemy.name}}</p>
    <p>Your health is: <strong>{{playerHealth}}</strong></p>

    <p v-if="weapon != null">You have a {{weapon.name}}</p>
    <div v-if="showButtons">
        <button v-if="weapon != null && enemy != null && canAttack" class="btn btn-primary" @click="attack">Attack!</button>
        <button v-if="!canAttack" class="btn btn-primary" @click="block(enemyAttack())">Block!</button>
        <button v-if="!canAttack" class="btn btn-primary" @click="dodge(enemyAttack())">Dodge!</button>
    </div>
    <p aria-live="polite"> {{ gameMessage }}</p>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Game",
        data() {
            return {
                playerHealth: 100,
                canAttack: null,
                showButtons: false,
                weapon: null,
                enemy: null,
                gameMessage: "",
            }
        },
        methods: {
            attack() {
                var dmg = Math.floor(Math.random() * this.weapon.stats["Attack"]) + Math.round(this.weapon.stats["Attack"] / 2);
                this.enemy.health = this.enemy.health - dmg;
                if (this.enemy.health <= 0) {
                    this.gameMessage = this.gameMessage = "Dealt " + dmg + " damage and killed " + this.enemy.name + "!";
                    this.enemy = this.getEnemy();
                    this.getAttackOrder();
                }
                else {
                    this.gameMessage = "Dealt " + dmg + " damage";
                    this.canAttack = false;
                }

            },
            block(enemyDmg) {
                this.playerHealth = this.playerHealth - Math.round((enemyDmg * (this.weapon.stats["Defense"] / 100)));
                this.canAttack = true;
            },
            dodge(enemyDmg) {
                var newDodgeChance = this.weapon.stats["Dodge"] + Math.floor(Math.random() * 10) + 1;
                var nr = Math.floor(Math.random() * 100) + 1;
                if (nr < newDodgeChance) {
                    this.gameMessage = "Dodge successful!";
                }
                else {
                    this.playerHealth = this.playerHealth - enemyDmg;
                    this.gameMessage = "Dodge failed! Enemy dealt " + enemyDmg + " damage!";
                }
                this.canAttack = true;
            },
            enemyAttack() {
                var dmg = Math.floor(Math.random() * this.enemy.attack) + Math.round(this.enemy.attack / 2);
                return dmg;
            },
            async getWeapon() {
                await axios.get('/weapongenerator')
                    .then((response) => {
                        this.weapon = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            async getEnemy() {
                await axios.get('/enemygenerator')
                    .then((response) => {
                        this.enemy = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            getAttackOrder() {
                if (this.enemy.speed > this.weapon.stats["Speed"]) {
                    this.canAttack = false;
                }
                else {
                    this.canAttack = true;
                }
                this.showButtons = true;
            }

        },
        async mounted() {
            await this.getWeapon();
            await this.getEnemy();
            this.getAttackOrder();
        }
    }
</script>