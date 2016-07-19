(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('$bizService', BizServiceFactory);

    BizServiceFactory.$inject = ['$http', '$baseService'];

    function BizServiceFactory($http, $baseService) {
        var svc = this;
  
        svc = $baseService.merge(true, {}, svc, $baseService);

        svc.createCoupon = _createCoupon;
        svc.updateCoupon = _updateCoupon;
        svc.GetCoupon = _GetCoupon;
        svc.GetCouponById = _GetCouponById;
        svc.DeleteCoupon = _DeleteCoupon;
        function _createCoupon(payload,onSuccess, onError) {
            $http.post("/api/Biz/CreateCoupon",payload).success(onSuccess).error(onError);
        };

        function _updateCoupon(payload,onSuccess, onError) {
          
            $http.put("/api/Biz/UpdateCoupon", payload).success(onSuccess).error(onError);
        }

        function _GetCoupon(onSuccess, onError) {

            $http.get("/api/Biz/GetCoupon").success(onSuccess).error(onError);
        } 
        function _GetCouponById(data,onSuccess, onError) {

            $http.get("/api/Biz/"+ data).success(onSuccess).error(onError);
        }
        function _DeleteCoupon(Id, onSuccess, onError) {

            $http.delete("/api/Biz/" + Id).success(onSuccess).error(onError);
        }




      
        return svc;
    };



})();