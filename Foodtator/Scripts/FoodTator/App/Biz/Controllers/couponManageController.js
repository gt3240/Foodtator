(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('couponManageController', CouponManageController);

    CouponManageController.$inject = ['$scope', '$routeParams','$bizService'];

    function CouponManageController(
          $scope
         ,$routeParams
         ,$bizService
         
        ) {

        var vm = this;
        vm.$scope = $scope;
        vm.$routeParams = $routeParams;
        vm.$bizService = $bizService;

        /****  Variables ***/
        vm.pageTitle = null;
        vm.pageEvent = vm.$routeParams.event
        vm.newCoupon = null;
        /****  Functions ***/
        vm.createCoupon = _createCoupon;
        vm.createdSuccess = _createdSuccess;
        vm.createdError = _createdError;

        init();

        function init() {
            console.log("CouponManageController loaded");
            if (vm.pageEvent == "new") {
                console.log("This is new");
                vm.pageTitle = "New Coupon"
            } else {
                console.log("This is an update");
                vm.pageTitle = "Update Coupon"
            }

        }

        function _createCoupon() {
            vm.$bizService.createCoupon(vm.newCoupon,vm.createdSuccess, vm.createdError);
        }

        function _createdSuccess() {
            console.log("Coupon Created");
        }
        
        function _createdError() {
            console.log("coupon error");
        }
    }
})();