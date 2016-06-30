(function () {
    "use strict";

    angular.module(APPNAME)
        .factory('$googleMapService', GoogleMapServiceFactory);

    GoogleMapServiceFactory.$inject = ['$baseService', '$tkj'];

    function GoogleMapServiceFactory($baseService, $tkj) {

        var svc = this;
        svc = $baseService.merge(true, {}, svc, $baseService);

        svc.initMap = _initMap;

        function _initMap(lat, lon, mapCallback) {
            var origin = { lat: lat, lng: lon };
            var destination = { lat: 33.957056, lng: -117.594153 };

            var service = new google.maps.DistanceMatrixService();
            service.getDistanceMatrix(
              {
                  origins: [origin],
                  destinations: [destination],
                  travelMode: google.maps.TravelMode.DRIVING,
              }, mapCallback);
        }

        return svc;
    }
})();