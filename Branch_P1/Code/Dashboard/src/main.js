// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import {DatePicker,Select,Option,Button,Popover,Tooltip} from 'element-ui';
import './css/theme/index.css'
import App from './App'
import router from './router'
import 'babel-polyfill'

Vue.config.productionTip = false
Vue.use(DatePicker)
Vue.use(Select)
Vue.use(Option)
Vue.use(Button)
Vue.use(Popover)
Vue.use(Tooltip)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
