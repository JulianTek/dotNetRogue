using System;
using dotNetRogue.Logic.Models;
<template>
    <div style="background-image: url('https://i.redd.it/6axfm8uck3oy.png'); height: 100vh;">
        <img src="../assets//skeleton.png" style="width: 150px; height: 400px;" v-if="enemy != null" />

        <div style="background-color: dimgray; color: white; border: 5px solid black; height: 100px; margin-left: 10px; margin-right: 10px;" v-if="enemy != null">
            <p strong v-if="enemy != null">You are attacked by a {{ enemy.name }}</p>
            <p strong aria-live="polite"> {{ gameMessage }}</p>
            <p strong aria-live="polite" v-if="showGoldMsg" style="color: white; margin-bottom: 0px;">Gained {{ enemy.goldOnKill }} gold</p>
            <p v-if="weapon != null">You have a {{ weapon.name }}</p>
        </div>
        <div v-if="enemy != null" style="background-color: black; margin-left: 10px; margin-right: 10px;">
            <div style="float: left;">
                <img src="../assets/life.png" style="height: 50px; width: 50px; float: left; margin-left: 13px; margin-bottom: -5px;" /> <p style="color: red; margin-left: 10px; margin-bottom: auto;">{{ playerHealth }}/100</p>
            </div>
            <div style="margin: auto;">
                <img src="../assets/gold.png" style="height: 40px; width: 40px" /> <p style="color: gold">{{ playerGold }}</p>
            </div>
        </div>
        <div v-if="showButtons">
            <button v-if="weapon != null && enemy != null && canAttack" class="btn btn-danger" @click="attack">Attack!</button>
            <button v-if="!canAttack" class="btn btn-success" @click="block(enemyAttack())">Block!</button>
            <button v-if="!canAttack" class="btn btn-success" @click="dodge(enemyAttack())">Dodge!</button>
        </div>
        <!--Overlay of loot dialog-->
        <div id="overlay" v-if="lootOverlay">
            <div class="modal-dialogue">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">You have found a new weapon!</h5>
                        <button type="button" class="close">
                            <span aria-hidden="true" @click="lootOverlay = false">&times;</span>
                        </button>
                    </div>
                    <form class="modal-body">
                        <p>You have found a {{ newWeapon.name }}</p>
                        <p>Will you accept?</p>
                    </form>
                    <div class="form-group">
                        <button class="btn btn-info " @click="acceptWeapon">Accept weapon</button>
                        <button class="btn btn-danger" @click="lootOverlay = false">Decline</button>
                    </div>
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
                playerHealth: 100,
                canAttack: null,
                showButtons: false,
                showGoldMsg: false,
                weapon: null,
                newWeapon: null,
                enemy: null,
                lootOverlay: false,
                playerGold: 0,
                gameMessage: "",
                image: null,
            }
        },
        methods: {
            async attack() {
                var dmg = Math.floor(Math.random() * this.weapon.stats["Attack"]) + Math.round(this.weapon.stats["Attack"] / 2);
                this.enemy.health = this.enemy.health - dmg;
                if (this.enemy.health <= 0) {
                    this.gameMessage = this.gameMessage = "Dealt " + dmg + " damage and killed " + this.enemy.name + "!";
                    this.playerGold = this.playerGold + this.enemy.goldOnKill;
                    this.enemy = null;
                    this.showGoldMsg = true;
                    if (Math.floor(Math.random() * 100) + 1 <= 10) {
                        await this.generateLoot();
                    }
                    this.enemy = this.getEnemy();
                    this.getAttackOrder();
                }
                else {
                    this.gameMessage = "Dealt " + dmg + " damage";
                    this.canAttack = false;
                    this.showGoldMsg = false;
                }
            },
            block(enemyDmg) {
                var dmg = Math.round((enemyDmg * (this.weapon.stats["Defense"] / 100)));
                this.playerHealth = this.playerHealth - dmg;
                this.gameMessage = "Enemy dealt " + dmg + " damage!"
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
            async generateLoot() {
                await axios.get('/weapongenerator')
                    .then((response) => {
                        this.newWeapon = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
                this.lootOverlay = true;
                console.log(this.newWeapon)
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
                        this.image = this.enemy.imageUrl;
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
            },
            acceptWeapon() {
                this.weapon = this.newWeapon;
                this.newWeapon = null;
                this.lootOverlay = false;
            }

        },
        async mounted() {
            await this.getWeapon();
            await this.getEnemy();
            this.getAttackOrder();
        }
    }
</script>
