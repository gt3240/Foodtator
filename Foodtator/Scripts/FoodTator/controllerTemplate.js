(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('tempController', TempController);

    TempController.$inject = ['$scope'];

    function TempController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;

        /****  Variables ***/



        /****  Functions ***/

        init();

        function init() {
            console.log("TempController loaded");



        }


    }
})();