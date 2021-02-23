const { default: VueRouter } = require("vue-router");
const { default: Vue } = require("vue");
const { default: Home } = require("../views/Home.vue");
const { default: Employee } = require("../views/dictionary/employee/EmployeeList.vue");

Vue.use(VueRouter);
const routes = [
  { path: "/", name: "Home", component: Home },
  { path: "/dictionary/employee", name: "Employee", component: Employee },
];
const router = new VueRouter({
  mode: "history",
  base: process.env.BABEL_ENV,
  routes,
});
export default router;
