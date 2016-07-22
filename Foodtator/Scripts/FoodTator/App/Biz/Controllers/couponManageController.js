(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('couponManageController', CouponManageController);

    CouponManageController.$inject = ['$scope', '$routeParams', '$bizService'];

    function CouponManageController(
          $scope
         , $routeParams
         , $bizService
        ) {

        var vm = this;

        vm.$routeParams = $routeParams;
        vm.$bizService = $bizService;

        /****  Variables ***/
        vm.pageTitle = null;
        vm.pageEvent = vm.$routeParams.event;
        vm.newCoupon = null;

        vm.$scope = $scope;
        /****  Functions ***/
        vm.createCoupon = _createCoupon;
        vm.createdSuccess = _createdSuccess;
        vm.createdError = _createdError;
        vm.populateCouponForm = _populateCouponForm;
        vm.deleteCoupon = _deleteCoupon;
        vm.deletedSuccess = _deletedSuccess;

        vm.notify = vm.$bizService.getNotifier($scope);

        init();

        function init() {

            console.log("CouponManageController loaded");
            if (vm.pageEvent == "new") {
                console.log("This is new");
                vm.pageTitle = "New Coupon"
            } else {
                console.log("This is an update");
                vm.pageTitle = "Update Coupon"

                vm.$bizService.GetCouponById(vm.pageEvent, vm.populateCouponForm, vm.createdError);
            }

        }

        function _createCoupon() {
            if (vm.newCoupon.id) {
                vm.$bizService.updateCoupon(vm.newCoupon, vm.createdSuccess, vm.createdError);
            } else {
                vm.$bizService.createCoupon(vm.newCoupon, vm.createdSuccess, vm.createdError);
            }

        }

        function _createdSuccess() {
            console.log("Coupon Created");
        }

        function _createdError() {
            console.log("coupon error");
        }

        function _populateCouponForm(data) {
            $scope.$applyAsync(function () {
                vm.newCoupon = data.item;
            });

        }
        function _deleteCoupon(Id){
            vm.$bizService.DeleteCoupon(Id, vm.deletedSuccess, vm.createdError);
        }
        function _deletedSuccess() {
            console.log("Deleted");
            window.location = '/biz/Index#/coupon';
        
        }

    }
})();