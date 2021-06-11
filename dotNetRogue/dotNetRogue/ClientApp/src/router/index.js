import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Game from "@/components/Game.vue";
import Enemy from "@/components/Enemy.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Game",
        name: "Game",
        component: Game,
    },
    {
        path: "/Enemy",
        name: "Enemy",
        component: Enemy,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;