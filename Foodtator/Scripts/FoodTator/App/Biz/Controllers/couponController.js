(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('couponController', CouponController);

    CouponController.$inject = ['$scope','$bizService'];

    function CouponController(
           $scope
         , $bizService
        ) {

        var vm = this;
      
      
        /****  Variables ***/
        vm.Coupon = null;

        vm.$bizService = $bizService;
        vm.$scope = $scope;


        //vm.notify = vm.$bizService.getNotifier($scope);

        /****  Functions ***/
        vm.populateCoupon = _populateCoupon;
        vm.couponError = _couponError;



        render();

        function render() {
            console.log("CouponController loaded");
            vm.$bizService.GetCoupon(vm.populateCoupon, vm.couponError);

        }

        function _populateCoupon(data) {
                vm.Coupon = data.items;
            console.log("DATA.items",data.items)
        }

        function _couponError() {
            console.log("error");
        }

    }
})();