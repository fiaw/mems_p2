(window.webpackJsonp=window.webpackJsonp||[]).push([[4],{499:function(t,n,e){var i=e(147),s=e(560);"string"==typeof(s=s.__esModule?s.default:s)&&(s=[[t.i,s,""]]);var a={insert:"head",singleton:!1};i(s,a);t.exports=s.locals||{}},500:function(t,n,e){var i=e(147),s=e(562);"string"==typeof(s=s.__esModule?s.default:s)&&(s=[[t.i,s,""]]);var a={insert:"head",singleton:!1};i(s,a);t.exports=s.locals||{}},559:function(t,n,e){"use strict";var i=e(499);e.n(i).a},560:function(t,n,e){(n=e(487)(!1)).push([t.i,".container[data-v-78f4bcc0] {\n  min-width: 1200px;\n  width: 100%;\n  height: 100%;\n  background: #D7E0EE;\n  font-size: 0.4rem;\n  overflow: auto;\n}\n.container .content[data-v-78f4bcc0] {\n  padding: 0.3rem;\n  width: 100%;\n  height: 100%;\n  /*height: calc(100% - 1.6rem);*/\n}\n.container .content .top[data-v-78f4bcc0] {\n  width: 100%;\n  height: 55%;\n  display: flex;\n}\n.container .content .top .left[data-v-78f4bcc0] {\n  width: 55%;\n}\n.container .content .top .right[data-v-78f4bcc0] {\n  width: 45%;\n}\n.container .content .top .box[data-v-78f4bcc0] {\n  background: #fff;\n  margin: 0.15rem;\n  border-radius: 0.16rem;\n}\n.container .content .top .box1[data-v-78f4bcc0] {\n  display: flex;\n  flex-direction: column;\n}\n.container .content .top .box2[data-v-78f4bcc0] {\n  position: relative;\n  padding: 0 0.8rem;\n}\n.container .content .bottom[data-v-78f4bcc0] {\n  width: 100%;\n}\n.container .content .bottom .bottom-box[data-v-78f4bcc0] {\n  background: #FFF;\n  margin: 0.15rem;\n  border-radius: 0.16rem;\n  padding: 0.2rem 0.5rem;\n}\n",""]),t.exports=n},561:function(t,n,e){"use strict";var i=e(500);e.n(i).a},562:function(t,n,e){},571:function(t,n,e){"use strict";e.r(n);var i=e(486),s=e(488),a=e(489),c=e(207),o=e(485),r={components:{EventList:s.a,KpiList:a.a},data:function(){return{responseingDispatchList:[],uploadingDispatchList:[]}},created:function(){this.getCurrUserVue(),this.getSource()},methods:{refreshAll:function(){this.$refs.kpi.init()},GoToDispatch:function(t){window.location.href=o.a+"/Dispatch/DispatchList?status="+t},GoToDispatchDetail:function(t,n){window.location.href=o.a+"/Dispatch/DispatchResponse?dispatchID="+t+"&requestType="+n},parseAndFormatJsonDate:function(t){return Object(c.a)(t)},getCurrUserVue:function(){roleID<0?window.location.href=o.a+"/Home/Login":1==roleID?this.$router.push("indexSA"):2==roleID||this.$router.push("indexU")},getSource:function(){var t=this;Object(i.e)({currentPage:1,status:1,urgency:0,type:0,filterField:"",filterText:"",sortField:"init",sortDirection:!1,self:!0}).then(function(n){t.responseingDispatchList=n.Data.slice(0,5)}),Object(i.e)({currentPage:1,status:2,urgency:0,type:0,filterField:"",filterText:"",sortField:"init",sortDirection:!1,self:!0}).then(function(n){t.uploadingDispatchList=n.Data.slice(0,5)})}}},l=(e(559),e(561),e(148)),d=Object(l.a)(r,function(){var t=this,n=t.$createElement,e=t._self._c||n;return e("div",{staticClass:"indexA container"},[e("div",{staticClass:"content"},[e("div",{staticClass:"top"},[e("div",{staticClass:"left box box1"},[e("EventList")],1),t._v(" "),e("div",{staticClass:"right box box2"},[e("KpiList",{ref:"kpi"})],1)]),t._v(" "),e("div",{staticClass:"bottom"},[e("div",{staticClass:" bottom-box "},[e("p",{staticStyle:{"font-size":"20px","font-weight":"bold"}},[e("span",{staticClass:"iconfont icon-gongdanliebiao"}),t._v(" 待响应\n\t\t\t\t\t"),e("a",{staticClass:"linkFile",staticStyle:{float:"right","font-size":"14px","font-weight":"normal"},attrs:{href:"#"},on:{click:function(n){return t.GoToDispatch(1)}}},[t._v("更多...")])]),t._v(" "),e("table",{staticClass:"table ",staticStyle:{"font-size":"14px"},attrs:{cellspacing:"0",cellpadding:"5"}},[t._m(0),t._v(" "),e("tbody",[0==t.responseingDispatchList.length?e("tr",[e("td",{attrs:{colspan:"10",align:"center"}},[t._v("暂无数据")])]):t._e(),t._v(" "),t._l(t.responseingDispatchList,function(n,i){return e("tr",{key:i},[e("td",[e("a",{staticClass:"linkFile cursor",attrs:{href:"#"},on:{click:function(e){return t.GoToDispatchDetail(n.ID,n.RequestType.ID)}}},[t._v(t._s(n.OID))])]),t._v(" "),e("td",[t._v(t._s(n.Request.OID))]),t._v(" "),e("td",[t._v(t._s(n.Request.EquipmentOID))]),t._v(" "),e("td",[t._v(t._s(n.Request.EquipmentName))]),t._v(" "),e("td",[t._v(t._s(n.RequestType.Name))]),t._v(" "),e("td",[t._v(t._s(n.Urgency.Name))]),t._v(" "),e("td",[t._v(t._s(t.parseAndFormatJsonDate(n.ScheduleDate)))]),t._v(" "),e("td",[t._v(t._s(n.Status.Name))])])})],2)])]),t._v(" "),e("div",{staticClass:" bottom-box "},[e("p",{staticStyle:{"font-size":"20px","font-weight":"bold"}},[e("span",{staticClass:"iconfont icon-gongdanliebiao"}),t._v(" 待上传\n\t\t\t\t\t"),e("a",{staticClass:"linkFile",staticStyle:{float:"right","font-size":"14px","font-weight":"normal"},attrs:{href:"#"},on:{click:function(n){return t.GoToDispatch(2)}}},[t._v("更多...")])]),t._v(" "),e("table",{staticClass:"table ",staticStyle:{"font-size":"14px"},attrs:{cellspacing:"0",cellpadding:"5"}},[t._m(1),t._v(" "),e("tbody",[0==t.uploadingDispatchList.length?e("tr",[e("td",{attrs:{colspan:"10",align:"center"}},[t._v("暂无数据")])]):t._e(),t._v(" "),t._l(t.uploadingDispatchList,function(n,i){return e("tr",{key:i},[e("td",[e("a",{staticClass:"linkFile cursor",attrs:{href:"#"},on:{click:function(e){return t.GoToDispatchDetail(n.ID,n.RequestType.ID)}}},[t._v(t._s(n.OID))])]),t._v(" "),e("td",[t._v(t._s(n.Request.OID))]),t._v(" "),e("td",[t._v(t._s(n.Request.EquipmentOID))]),t._v(" "),e("td",[t._v(t._s(n.Request.EquipmentName))]),t._v(" "),e("td",[t._v(t._s(n.RequestType.Name))]),t._v(" "),e("td",[t._v(t._s(n.Urgency.Name))]),t._v(" "),e("td",[t._v(t._s(t.parseAndFormatJsonDate(n.ScheduleDate)))]),t._v(" "),e("td",[t._v(t._s(n.Status.Name))])])})],2)])])])])])},[function(){var t=this,n=t.$createElement,e=t._self._c||n;return e("thead",{staticClass:"thead-light"},[e("tr",[e("th",{staticStyle:{"min-width":"150px"}},[t._v("派工单编号")]),t._v(" "),e("th",{staticStyle:{"min-width":"120px"}},[t._v("请求编号")]),t._v(" "),e("th",{staticStyle:{"min-width":"120px"}},[t._v("设备系统编号")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("设备名称")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("派工类型")]),t._v(" "),e("th",{staticStyle:{"min-width":"100px"}},[t._v("紧急程度")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("派工日期")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("状态")])])])},function(){var t=this,n=t.$createElement,e=t._self._c||n;return e("thead",{staticClass:"thead-light"},[e("tr",[e("th",{staticStyle:{"min-width":"150px"}},[t._v("派工单编号")]),t._v(" "),e("th",{staticStyle:{"min-width":"120px"}},[t._v("请求编号")]),t._v(" "),e("th",{staticStyle:{"min-width":"120px"}},[t._v("设备系统编号")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("设备名称")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("派工类型")]),t._v(" "),e("th",{staticStyle:{"min-width":"100px"}},[t._v("紧急程度")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("派工日期")]),t._v(" "),e("th",{staticStyle:{"min-width":"150px"}},[t._v("状态")])])])}],!1,null,"78f4bcc0",null);n.default=d.exports}}]);