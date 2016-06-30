(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('selectionLoadedController', SelectionLoadedController);

    SelectionLoadedController.$inject = ['$scope', '$googleMapService'];

    function SelectionLoadedController(
         $scope
        , $googleMapService
        ) {

        var vm = this;

        vm.$scope = $scope;
        vm.$googleMapService = $googleMapService;

        vm.checkInClicked = _checkInClicked;
        vm.mapCallback = _mapCallback;
        vm.rateClicked = _rateClicked;

        vm.showRateBtn = false;

        init();

        function init() {
            console.log("SelectionLoadedController loaded");
        }

        function _checkInClicked() {
            console.log("check in clicked");
            if (navigator.geolocation) {

                navigator.geolocation.getCurrentPosition(function (position) {
                    console.log('pos is ', position.coords);
                    vm.$googleMapService.initMap(position.coords.latitude, position.coords.longitude, vm.mapCallback);
                });
            }
        }

        function _mapCallback(response, status) {
            
            if (status !== google.maps.DistanceMatrixStatus.OK) {
                alert('Error was: ' + status);
            } else {
                
                var originList = response.originAddresses;
                var destinationList = response.destinationAddresses;
                var outputDiv = document.getElementById('output');

                for (var i = 0; i < originList.length; i++) {
                    var results = response.rows[i].elements;

                    for (var j = 0; j < results.length; j++) {
                        outputDiv.innerHTML += originList[i] + ' to ' + destinationList[j] +
                            ': ' + results[j].distance.text + ' in ' +
                            results[j].duration.text + '<br>';
                    }
                }
                console.log("calling back");
               
                vm.$scope.$apply(function(){
                    vm.showRateBtn = true;
                });
            }
        }

        function _rateClicked() {
            window.location.replace('/checkin#/rate');
        }




    }
})();