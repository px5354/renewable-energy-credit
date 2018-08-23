import Vue from 'vue';
import Router from 'vue-router';
import Home from '@/views/Home';
import Login from '@/views/Login';
import Producer from '@/views/Producer';
import ProducerDetail from '@/views/ProducerDetail';
import Broker from '@/views/Broker';
import Client from '@/views/Client';
import store from '@/store'

Vue.use(Router);

const ifNotAuthenticated = (to, from, next) => {
  if (!store.getters.isAuthenticated) {
    next()
    return
  }
  next('/')
}

const ifAuthenticated = (to, from, next) => {
  if (store.getters.isAuthenticated) {
    next()
    return
  }
  next('/login')
}

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      redirect: '/client',
    },
    {
      path: '/login',
      name: 'login',
      component: Login,
      beforeEnter: ifNotAuthenticated,
    },
    {
      path: '/producer',
      name: 'producer',
      component: Producer,
      beforeEnter: ifAuthenticated,
    },
    {
      path: '/producer/:assetId',
      name: 'producerdetail',
      component: ProducerDetail,
      beforeEnter: ifAuthenticated,
    },
    {
      path: '/broker',
      name: 'broker',
      component: Broker,
      beforeEnter: ifAuthenticated,
    },
    {
      path: '/client',
      name: 'client',
      component: Client,
      beforeEnter: ifAuthenticated,
    },
  ],
});
