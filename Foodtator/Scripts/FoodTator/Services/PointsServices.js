(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('$pointsService', PointsServiceFactory);

    PointsServiceFactory.$inject = ['$http', '$baseService'];

    function PointsServiceFactory($http, $baseService) {
        var svc = this;

        $.extend(svc, $baseService);

        svc.locationDismissed = _locationDismissed;

        function _locationDismissed() {
            $http.post("/api/CheckIn/dismiss").success(function () {
                console.log("points subtracted");
            }).error(function () {
                console.log("points subtract error");

            });
        };

        return svc;
    };



})();