(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('accountController', AccountController);

    AccountController.$inject = ['$scope'];

    function AccountController(
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