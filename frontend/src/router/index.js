import Vue from 'vue';
import Router from 'vue-router';
import Main from '@/views/Main';
import Producer from '@/views/Producer';
import ProducerDetail from '@/views/ProducerDetail';
import Broker from '@/views/Broker';
import Client from '@/views/Client';

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
      name: 'producer',
      component: Producer,
    },
    {
      path: '/producer/:assetId',
      name: 'producerdetail',
      component: ProducerDetail,
    },
    {
      path: '/broker',
      name: 'broker',
      component: Broker,
    },
    {
      path: '/client',
      name: 'client',
      component: Client,
    },
  ],
});
