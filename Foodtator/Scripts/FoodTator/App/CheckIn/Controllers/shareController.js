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
        vm.startRP = null;
        vm.startXP = null;
        vm.countToRP = null;
        vm.countToXP = null;

        init();

        function init() {
            console.log("ShareController loaded");
            console.log("event is ", vm.event);
            vm.user = JSON.parse($("#modelData").html());

            console.log("user is ", vm.user);

            if (vm.event == "selected") {
                vm.countToRP = vm.user.redeemPoints;
                vm.countToXP = vm.user.rankingPoints;
                vm.startRP = vm.countToRP - 5;
                vm.startXP = vm.countToXP - 5;

                vm.$timeout(function () {
                    vm.showSelectedMsg = true;
                   
                }, 1000);
            } else {
                // since the user is not updated so need to do this calculation.
                // simple refresh will show 10 more points than the db.
               
                vm.countToRP = vm.user.redeemPoints + 10;
                vm.countToXP = vm.user.rankingPoints + 10;
                vm.startRP = vm.countToRP - 10;
                vm.startXP = vm.countToXP - 10;

                vm.$timeout(function () {               
                    vm.showCameraBtn = true;
                }, 1000);
            }
    
        }


    }
})();