(window.webpackJsonp=window.webpackJsonp||[]).push([[5],{497:function(t,e,i){var n=i(147),s=i(556);"string"==typeof(s=s.__esModule?s.default:s)&&(s=[[t.i,s,""]]);var a={insert:"head",singleton:!1};n(s,a);t.exports=s.locals||{}},498:function(t,e,i){var n=i(147),s=i(558);"string"==typeof(s=s.__esModule?s.default:s)&&(s=[[t.i,s,""]]);var a={insert:"head",singleton:!1};n(s,a);t.exports=s.locals||{}},555:function(t,e,i){"use strict";var n=i(497);i.n(n).a},556:function(t,e,i){(e=i(487)(!1)).push([t.i,".container[data-v-2b840375] {\n  min-width: 1200px;\n  width: 100%;\n  height: 100%;\n  background: #D7E0EE;\n  font-size: 0.4rem;\n  overflow: auto;\n}\n.container .content[data-v-2b840375] {\n  padding: 0.3rem;\n  width: 100%;\n  height: 100%;\n  /*height: calc(100% - 1.6rem);*/\n}\n.container .content .top[data-v-2b840375] {\n  width: 100%;\n  height: 55%;\n  display: flex;\n}\n.container .content .top .left[data-v-2b840375] {\n  width: 55%;\n}\n.container .content .top .right[data-v-2b840375] {\n  width: 45%;\n}\n.container .content .top .box[data-v-2b840375] {\n  background: #fff;\n  margin: 0.15rem;\n  border-radius: 0.16rem;\n}\n.container .content .top .box1[data-v-2b840375] {\n  display: flex;\n  flex-direction: column;\n}\n.container .content .top .box2[data-v-2b840375] {\n  position: relative;\n  padding: 0 0.8rem;\n}\n.container .content .bottom[data-v-2b840375] {\n  width: 100%;\n}\n.container .content .bottom .bottom-box[data-v-2b840375] {\n  background: #FFF;\n  margin: 0.15rem;\n  border-radius: 0.16rem;\n  padding: 0.2rem 0.5rem;\n}\n",""]),t.exports=e},557:function(t,e,i){"use strict";var n=i(498);i.n(n).a},558:function(t,e,i){},570:function(t,e,i){"use strict";i.r(e);var n=i(486),s=i(488),a=i(489),o=i(207),r=i(485),c={components:{EventList:s.a,KpiList:a.a},data:function(){return{dispatchingRequestList:[],approvingDispatchList:[],approvingUserhList:[],date:localStorage.getItem("date")?new Date(localStorage.getItem("date")):new Date}},created:function(){this.getCurrUserVue(),this.getSource()},props:["masterDate"],watch:{masterDate:function(t){this.date=t||this.date}},methods:{refreshAll:function(){this.$refs.kpi.init()},GoToUserList:function(t){window.location.href=r.a+"/User/UserList?status="+t},GoToDispatch:function(t){window.location.href=r.a+"/Dispatch/DispatchList?status="+t},GoToDispatchDetail:function(t,e){window.location.href=r.a+"/Dispatch/DispatchResponse?dispatchID="+t+"&requestType="+e},GoToRequest:function(t){window.location.href=r.a+"/Request/RequestList?status="+t},GoToRequestDetail:function(t,e){window.location.href=r.a+"/Request/RequestDispatch?id="+t+"&actionName=RequestList&requestType="+e},parseAndFormatJsonDate:function(t){return Object(o.a)(t)},getCurrUserVue:function(){roleID<0?window.location.href=r.a+"/Home/Login":1==roleID||(2==roleID?this.$router.push("indexA"):this.$router.push("indexU"))},getSource:function(){var t=this;Object(n.f)({currentPage:1,status:98,requestType:0,isRecall:!1,department:-1,urgency:0,source:0,overDue:!1,filterField:"",filterText:"",field:"init",direction:!1}).then(function(e){t.dispatchingRequestList=e.Data.slice(0,5)}),Object(n.e)({currentPage:1,status:3,urgency:0,type:0,filterField:"",filterText:"",sortField:"init",sortDirection:!1}).then(function(e){t.approvingDispatchList=e.Data.slice(0,5)}),Object(n.d)({currentPage:1,status:-1,roleId:-1,verifyStatusID:2,filterField:"",filterText:"",field:"u.CreatedDate",direction:!1}).then(function(e){t.approvingUserhList=e.Data.slice(0,5)})}}},l=(i(555),i(557),i(148)),d=Object(l.a)(c,function(){var t=this,e=t.$createElement,i=t._self._c||e;return i("div",{staticClass:"indexSA container"},[i("div",{staticClass:"content"},[i("div",{staticClass:"top"},[i("div",{staticClass:"left box box1"},[i("EventList")],1),t._v(" "),i("div",{staticClass:"right box box2"},[i("KpiList",{ref:"kpi",attrs:{masterDate:t.date}})],1)]),t._v(" "),i("div",{staticClass:"bottom"},[i("div",{staticClass:" bottom-box "},[i("p",{staticStyle:{"font-size":"20px","font-weight":"bold"}},[i("span",{staticClass:"iconfont icon-baoxiu"}),t._v(" 待派工\n\t\t\t\t\t"),i("a",{staticClass:"linkFile",staticStyle:{float:"right","font-size":"14px","font-weight":"normal"},attrs:{href:"#"},on:{click:function(e){return t.GoToRequest(98)}}},[t._v("更多...")])]),t._v(" "),i("table",{staticClass:"table ",attrs:{cellspacing:"0",cellpadding:"5"}},[t._m(0),t._v(" "),i("tbody",[t._l(t.dispatchingRequestList,function(e,n){return i("tr",{key:n},[i("td",[i("a",{staticClass:"linkFile cursor",attrs:{href:"#"},on:{click:function(i){return t.GoToRequestDetail(e.ID,e.RequestType.ID)}}},[t._v("\n\t\t\t\t\t\t\t\t\t"+t._s(e.OID)+"\n\t\t\t\t\t\t\t\t")])]),t._v(" "),i("td",[t._v(t._s(e.EquipmentOID))]),t._v(" "),i("td",[t._v(t._s(e.EquipmentName))]),t._v(" "),i("td",[t._v(t._s(null==e.Equipments||0==e.Equipments.length?"":e.Equipments[0].Department.Name))]),t._v(" "),i("td",[t._v(t._s(e.RequestUser.Name))]),t._v(" "),i("td",[t._v(t._s(t.parseAndFormatJsonDate(e.RequestDate)))]),t._v(" "),i("td",[t._v(t._s(e.Source.Name))]),t._v(" "),i("td",[t._v(t._s(e.RequestType.Name))]),t._v(" "),i("td",[t._v(t._s(e.Status.Name))])])}),t._v(" "),0==t.dispatchingRequestList.length?i("tr",[i("td",{staticStyle:{"text-align":"center"},attrs:{colspan:"11"}},[t._v("暂无数据")])]):t._e()],2)])]),t._v(" "),i("div",{staticClass:" bottom-box "},[i("p",{staticStyle:{"font-size":"20px","font-weight":"bold"}},[i("span",{staticClass:"iconfont icon-gongdanliebiao"}),t._v(" 待审批\n\t\t\t\t\t"),i("a",{staticClass:"linkFile",staticStyle:{float:"right","font-size":"14px","font-weight":"normal"},attrs:{href:"#"},on:{click:function(e){return t.GoToDispatch(3)}}},[t._v("更多...")])]),t._v(" "),i("table",{staticClass:"table ",attrs:{cellspacing:"0",cellpadding:"5"}},[t._m(1),t._v(" "),i("tbody",[0==t.approvingDispatchList.length?i("tr",[i("td",{attrs:{colspan:"10",align:"center"}},[t._v("暂无数据")])]):t._e(),t._v(" "),t._l(t.approvingDispatchList,function(e,n){return i("tr",{key:n},[i("td",[i("a",{staticClass:"linkFile cursor",attrs:{href:"#"},on:{click:function(i){return t.GoToDispatchDetail(e.ID,e.RequestType.ID)}}},[t._v(t._s(e.OID))])]),t._v(" "),i("td",[t._v(t._s(e.Request.OID))]),t._v(" "),i("td",[t._v(t._s(e.Request.EquipmentOID))]),t._v(" "),i("td",[t._v(t._s(e.Request.EquipmentName))]),t._v(" "),i("td",[t._v(t._s(e.RequestType.Name))]),t._v(" "),i("td",[t._v(t._s(e.Urgency.Name))]),t._v(" "),i("td",[t._v(t._s(t.parseAndFormatJsonDate(e.ScheduleDate)))]),t._v(" "),i("td",[t._v(t._s(e.Status.Name))])])})],2)])]),t._v(" "),i("div",{staticClass:" bottom-box "},[i("p",{staticStyle:{"font-size":"20px","font-weight":"bold"}},[i("span",{staticClass:"iconfont icon-yonghuguanli"}),t._v(" 待审批用户\n\t\t\t\t\t"),i("a",{staticClass:"linkFile",staticStyle:{float:"right","font-size":"14px","font-weight":"normal"},attrs:{href:"#"},on:{click:function(e){return t.GoToUserList(2)}}},[t._v("更多...")])]),t._v(" "),i("table",{staticClass:"table",attrs:{cellspacing:"0",cellpadding:"5"}},[t._m(2),t._v(" "),i("tbody",{staticClass:"tbody"},[t._l(t.approvingUserhList,function(e,n){return i("tr",{key:n},[i("td",[t._v(t._s(e.LoginID))]),t._v(" "),i("td",[t._v(t._s(e.Role.Name))]),t._v(" "),i("td",[t._v(t._s(e.Name))]),t._v(" "),i("td",[t._v(t._s(e.Mobile))]),t._v(" "),i("td",[t._v(t._s(e.Email))]),t._v(" "),i("td",[t._v(t._s(e.Address))]),t._v(" "),i("td",{staticClass:"tdListCenter"},[t._v(t._s(t.parseAndFormatJsonDate(e.CreatedDate)))])])}),t._v(" "),0==t.approvingUserhList.length?i("tr",[i("td",{staticStyle:{"text-align":"center"},attrs:{colspan:"11"}},[t._v("暂无数据")])]):t._e()],2)])])])])])},[function(){var t=this,e=t.$createElement,i=t._self._c||e;return i("thead",{staticClass:"thead-light"},[i("tr",[i("th",{staticStyle:{"min-width":"150px"}},[t._v("请求编号")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("设备系统编号")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("设备名称")]),t._v(" "),i("th",{staticStyle:{"min-width":"100px"}},[t._v("科室")]),t._v(" "),i("th",{staticStyle:{"min-width":"100px"}},[t._v("请求人")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("请求日期")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("请求来源")]),t._v(" "),i("th",{staticStyle:{"min-width":"80px"}},[t._v("类型")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("状态")])])])},function(){var t=this,e=t.$createElement,i=t._self._c||e;return i("thead",{staticClass:"thead-light"},[i("tr",[i("th",{staticStyle:{"min-width":"150px"}},[t._v("派工单编号")]),t._v(" "),i("th",{staticStyle:{"min-width":"120px"}},[t._v("请求编号")]),t._v(" "),i("th",{staticStyle:{"min-width":"120px"}},[t._v("设备系统编号")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("设备名称")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("派工类型")]),t._v(" "),i("th",{staticStyle:{"min-width":"120px"}},[t._v("紧急程度")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("派工日期")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("状态")])])])},function(){var t=this,e=t.$createElement,i=t._self._c||e;return i("thead",{staticClass:"thead-light"},[i("tr",[i("th",{staticStyle:{"min-width":"150px"}},[t._v("账号")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("角色")]),t._v(" "),i("th",{staticStyle:{"min-width":"100px"}},[t._v("姓名")]),t._v(" "),i("th",{staticStyle:{"min-width":"120px"}},[t._v("电话")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("邮箱")]),t._v(" "),i("th",{staticStyle:{"min-width":"150px"}},[t._v("地址")]),t._v(" "),i("th",{staticClass:"tdListCenter",staticStyle:{"min-width":"100px"}},[t._v("添加日期")])])])}],!1,null,"2b840375",null);e.default=d.exports}}]);