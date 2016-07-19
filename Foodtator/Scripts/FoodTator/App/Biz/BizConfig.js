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
            }).when('/location', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/location.html',
                controller: 'locationController',
                controllerAs: 'lc'
            }).when('/location/:event', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/locationManage.html',
                controller: 'locationManageController',
                controllerAs: 'lmc'
            }).when('/account', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/account.html',
                controller: 'accountController',
                controllerAs: 'ac'
            }).when('/account', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/account.html',
                controller: 'accountController',
                controllerAs: 'ac'
            }).when('/account/avatar', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/accountAvatar.html',
                controller: 'accountAvatarController',
                controllerAs: 'aac'
            }).when('/account/email', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/accountEmail.html',
                controller: 'accountEmailController',
                controllerAs: 'aec'
            }).when('/account/password', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/accountPassword.html',
                controller: 'accountPasswordController',
                controllerAs: 'ac'
            }).when('/profile/', {
                templateUrl: '/Scripts/FoodTator/App/Biz/Templates/profile.html',
                controller: 'profileController',
                controllerAs: 'pc'
            });

            $locationProvider.html5Mode(false);

        }]);
    console.log("biz config executed");

})();