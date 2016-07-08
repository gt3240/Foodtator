(function () {
    "use strict";
    console.log("biz config loaded");
    angular.module(APPNAME)
        .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

            $routeProvider.when('/dashboard', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/dashboard.html',
                controller: 'dashboardController',
                controllerAs: 'dc'
            }).when('/coupon', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/coupon.html',
                controller: 'couponController',
                controllerAs: 'cc'
            }).when('/coupon/:event', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/couponManage.html',
                controller: 'couponManageController',
                controllerAs: 'cmc'
            });

            $locationProvider.html5Mode(false);

        }]);
    console.log("biz config executed");

})();