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

        //tkj.page.initMap = function (lat, lon) {
        //    var bounds = new google.maps.LatLngBounds;
        //    var markersArray = [];

            

        //    var destinationIcon = 'https://chart.googleapis.com/chart?' +
        //        'chst=d_map_pin_letter&chld=D|FF0000|000000';
        //    var originIcon = 'https://chart.googleapis.com/chart?' +
        //        'chst=d_map_pin_letter&chld=O|FFFF00|000000';
        //    var map = new google.maps.Map(document.getElementById('map'), {
        //        center: { lat: 55.53, lng: 9.4 },
        //        zoom: 10
        //    });
        //    var geocoder = new google.maps.Geocoder;

        //    var service = new google.maps.DistanceMatrixService;
        //    service.getDistanceMatrix({
        //        origins: [origin],
        //        destinations: [destination],
        //        travelMode: google.maps.TravelMode.DRIVING,
        //        unitSystem: google.maps.UnitSystem.METRIC,
        //        avoidHighways: false,
        //        avoidTolls: false
        //    }, function (response, status) {
        //        if (status !== google.maps.DistanceMatrixStatus.OK) {
        //            alert('Error was: ' + status);
        //        } else {
        //            var originList = response.originAddresses;
        //            var destinationList = response.destinationAddresses;
        //            var outputDiv = document.getElementById('output');
        //            outputDiv.innerHTML = '';
        //            deleteMarkers(markersArray);

        //            var showGeocodedAddressOnMap = function (asDestination) {
        //                var icon = asDestination ? destinationIcon : originIcon;
        //                return function (results, status) {
        //                    if (status === google.maps.GeocoderStatus.OK) {
        //                        map.fitBounds(bounds.extend(results[0].geometry.location));
        //                        markersArray.push(new google.maps.Marker({
        //                            map: map,
        //                            position: results[0].geometry.location,
        //                            icon: icon
        //                        }));
        //                    } else {
        //                        alert('Geocode was not successful due to: ' + status);
        //                    }
        //                };
        //            };

        //            for (var i = 0; i < originList.length; i++) {
        //                var results = response.rows[i].elements;
        //                geocoder.geocode({ 'address': originList[i] },
        //                    showGeocodedAddressOnMap(false));
        //                for (var j = 0; j < results.length; j++) {
        //                    geocoder.geocode({ 'address': destinationList[j] },
        //                        showGeocodedAddressOnMap(true));
        //                    outputDiv.innerHTML += originList[i] + ' to ' + destinationList[j] +
        //                        ': ' + results[j].distance.text + ' in ' +
        //                        results[j].duration.text + '<br>';
        //                }
        //            }
        //        }
        //    });
        //}

      

        return svc;
    }
})();