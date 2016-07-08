(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('couponController', CouponController);

    CouponController.$inject = ['$scope'];

    function CouponController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;

        /****  Variables ***/



        /****  Functions ***/

        init();

        function init() {
            console.log("CouponController loaded");


        }


    }
})();