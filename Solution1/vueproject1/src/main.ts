import { createApp } from "vue";
import App from "./App.vue";
// import "./registerServiceWorker";
//import router from "./router";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import store from './store'
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css';
  

const app = createApp(App);
app.config.globalProperties.$store = store;
app.use(store).component('VueDatePicker', VueDatePicker).mount('#app');

// createApp(App)
//     /* .use(store).use(router)*/
//     .provide("$store", store)
//     .use(store)
//     .component('VueDatePicker', VueDatePicker)
//     .mount("#app");
