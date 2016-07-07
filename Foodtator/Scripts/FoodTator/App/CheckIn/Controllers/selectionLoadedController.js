(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('selectionLoadedController', SelectionLoadedController);

    SelectionLoadedController.$inject = ['$scope', '$googleMapService', '$checkInService'];

    function SelectionLoadedController(
         $scope
        , $googleMapService
        , $checkInService
        ) {

        var vm = this;

        vm.$scope = $scope;
        vm.$googleMapService = $googleMapService;
        vm.$checkInService = $checkInService;

        vm.checkInClicked = _checkInClicked;
        vm.mapCallback = _mapCallback;
        vm.getSelectedSuccess = _getSelectedSuccess;
        vm.getSelectedError = _getSelectedError;
        vm.checkedInSuccess = _checkedInSuccess;
        vm.checkInError = _checkInError;

        vm.checkInResult = false;
        vm.showCheckInBtn = true;
        vm.CHECK_DISTANCE = 100000;
        vm.showNoSelected = false;
        vm.showSelected = false;

        vm.selectedLoc = null;
        vm.checkInResultText = null;

        init();

        function init() {
            console.log("SelectionLoadedController loaded");
            vm.user = JSON.parse($("#modelData").html());
            console.log("user is ", vm.user);
            vm.$checkInService.getSelected(vm.getSelectedSuccess, vm.getSelectedError);
        }

        function _getSelectedSuccess(data) {
            console.log("data is ", data);
            if (data.item.id < 1) {
                vm.showNoSelected = true;
            } else {
                vm.showSelected = true;
                vm.selectedLoc = data.item;
            }
        }

        function _getSelectedError() {
            console.log("error");
        }

        function _checkInClicked() {
            console.log("check in clicked");
            if (navigator.geolocation) {

                navigator.geolocation.getCurrentPosition(function (position) {
                    console.log('pos is ', position.coords);
                    vm.$googleMapService.initMap(position.coords.latitude, position.coords.longitude, vm.selectedLoc.lat, vm.selectedLoc.lon, vm.mapCallback);
                });
            }
        }

        function _mapCallback(response, status) {
            console.log("gmap response is ", response.rows[0].elements[0].distance.value);

            if (status !== google.maps.DistanceMatrixStatus.OK) {
                alert('Error was: ' + status);
            } else {
                var distance = response.rows[0].elements[0].distance.value;
                vm.checkInResult = true;
                vm.$scope.$apply(function () {
                    if (distance > vm.CHECK_DISTANCE) {
                        console.log("too far");
                        vm.checkInResultText = "Sorry, you are too far away =(";
                    } else {

                        vm.$checkInService.checkIn(vm.selectedLoc.id, vm.checkedInSuccess, vm.checkInError);
                    }

                });
            }
        }

        function _checkedInSuccess(data) {
            window.location.replace('/checkin#/share/checkin');
        }

        function _checkInError() {
            console.log("check in error");
        }



    }
})();