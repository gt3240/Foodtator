(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('profileController', ProfileController);

    ProfileController.$inject = ['$scope'];

    function ProfileController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;

        /****  Variables ***/



        /****  Functions ***/

        init();

        function init() {
            console.log("ProfileController loaded");


        }


    }
})();