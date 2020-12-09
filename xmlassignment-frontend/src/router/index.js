import Vue from 'vue'
import Router from 'vue-router'

import HelloWorld from '@/components/HelloWorld'
import Home from '@/components/Home'

import LoginComponent from '@/components/login'
import FlightComponent from '@/components/flight'
import HotelComponent from '@/components/hotel'

Vue.use(Router)

export default new Router({
  routes: [
    // {
    //   path: '/',
    //   name: 'HelloWorld',
    //   component: HelloWorld
    // },
    {
      path: '/',
      redirect: {
        name: "login"
      }
    },
    {
      path: '/home',
      name: 'Home',
      component: Home
    },
    {
      path: '/login',
      name: "login",
      component: LoginComponent
    },
    {
      path: "/flight",
      name: "flight",
      component: FlightComponent
    },
    {
      path: "/hotel",
      name: "hotel",
      component: HotelComponent
    }
  ]
})
