(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('shareController', ShareController);

    ShareController.$inject = ['$scope', '$timeout', '$routeParams'];

    function ShareController(
         $scope
        ,$timeout
        ,$routeParams
        ) {

        var vm = this;

        vm.$scope = $scope;
        vm.$timeout = $timeout;
        vm.$routeParams = $routeParams;

        vm.user = null;
        vm.showCameraBtn = false;
        vm.showSelectedMsg = false;
        vm.event = vm.$routeParams.event;

        init();

        function init() {
            console.log("ShareController loaded");
            console.log("event is ", vm.event);
            vm.user = JSON.parse($("#modelData").html());
            console.log("user is ", vm.user);

            if (vm.event == "selected") {
                vm.$timeout(function () {
                    vm.showSelectedMsg = true;
                }, 1000);
            } else {
                vm.$timeout(function () {
                    vm.showCameraBtn = true;
                }, 1000);
            }
    
        }


    }
})();