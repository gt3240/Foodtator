(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('locationManageController', LocationManageController);

    LocationManageController.$inject = ['$scope', '$routeParams'];

    function LocationManageController(
          $scope
         ,$routeParams
        ) {

        var vm = this;
        vm.$scope = $scope;
        vm.$routeParams = $routeParams;

        /****  Variables ***/
        vm.pageTitle = null;
        vm.pageEvent = vm.$routeParams.event
        vm.newLocation = null;
        /****  Functions ***/
        vm.createLocation = _createLocation;

        init();

        function init() {
            console.log("LocationManageController loaded");
            if (vm.pageEvent == "new") {
                console.log("This is new");
                vm.pageTitle = "New Location"
            } else {
                console.log("This is an update");
                vm.pageTitle = "Update Location"
            }

        }

        function _createLocation() {
            if (vm.newLocation.id) {
                vm.$bizService.updateLocation(vm.newLocation, vm.createdSuccess, vm.createdError);
            } else {
                vm.$bizService.CreateLocation(vm.newLocation, vm.createdSuccess, vm.createdError);
            }

        }


    }
})();