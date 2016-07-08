(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('dashboardController', DashboardController);

    DashboardController.$inject = ['$scope'];

    function DashboardController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;
        vm.test = "test me";
        /****  Variables ***/



        /****  Functions ***/

        init();

        function init() {
            console.log("Dashboard controller loaded");
            

        }


    }
})();