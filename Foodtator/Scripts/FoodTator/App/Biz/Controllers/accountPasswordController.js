(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('accountPasswordController', AccountPasswordController);

    AccountPasswordController.$inject = ['$scope'];

    function AccountPasswordController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;

        /****  Variables ***/



        /****  Functions ***/

        init();

        function init() {
            console.log("AccountPasswordController loaded");


        }


    }
})();