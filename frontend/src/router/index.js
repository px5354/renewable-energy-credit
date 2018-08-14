import Vue from 'vue';
import Router from 'vue-router';
import Main from '@/views/Main';
import Producer from '@/views/Producer';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'mainview',
      component: Main,
    },
    {
      path: '/producer',
      name: 'producerview',
      component: Producer,
    },
  ],
});
