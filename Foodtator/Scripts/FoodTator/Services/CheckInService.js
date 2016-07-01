(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('$checkInService', CheckInServiceFactory);

    CheckInServiceFactory.$inject = ['$http', '$baseService'];

    function CheckInServiceFactory($http, $baseService) {
        var svc = this;
  
        svc = $baseService.merge(true, {}, svc, $baseService);

        svc.getSelected = _getSelected;
        svc.checkIn = _checkIn;

        function _getSelected(onSuccess, onError) {
            $http.get("/api/CheckIn/Selected").success(onSuccess).error(onError);
        };

        function _checkIn(id, onSuccess, onError) {
            console.log("check in payload is", id);
            $http.put("/api/CheckIn/checkIn/?id=" + id).success(onSuccess).error(onError);
        }

        return svc;
    };



})();