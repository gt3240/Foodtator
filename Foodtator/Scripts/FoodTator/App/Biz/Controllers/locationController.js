(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('locationController', LocationController);

    LocationController.$inject = ['$scope'];

    function LocationController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;

        /****  Variables ***/



        /****  Functions ***/

        init();

        function init() {
            console.log("LocationController loaded");


        }


    }
})();