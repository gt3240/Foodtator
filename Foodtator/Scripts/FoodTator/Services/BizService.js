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

        function _createCoupon(payload,onSuccess, onError) {
            $http.post("/api/Biz/CreateCoupon",payload).success(onSuccess).error(onError);
        };

        function _updateCoupon(onSuccess, onError) {
          
            $http.put("/api/Biz/CreateCoupon").success(onSuccess).error(onError);
        }

        function _GetCoupon(id, onSuccess, onError) {

            $http.get("/api/Biz/GetCoupon" + id).success(onSuccess).error(onError);
        }

        function _DeleteCoupon(id, onSuccess, onError) {

            $http.get("/api/Biz/DeleteCoupon").success(onSuccess).error(onError);
        }

      
        return svc;
    };



})();