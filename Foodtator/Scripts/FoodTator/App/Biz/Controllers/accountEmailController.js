(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('accountEmailController', AccountEmailController);

    AccountEmailController.$inject = ['$scope'];

    function AccountEmailController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;

        /****  Variables ***/



        /****  Functions ***/

        init();

        function init() {
            console.log("AccountController loaded");


        }


    }
})();