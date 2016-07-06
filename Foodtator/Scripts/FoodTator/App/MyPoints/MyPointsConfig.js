(function () {
    "use strict";

    angular.module(APPNAME)
        .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

            $routeProvider.when('/overview', {
                templateUrl: '/Scripts/FoodTator/App/MyPoints/Templates/myPoints.html',
                controller: 'myPointsController',
                controllerAs: 'mpc'
            //}).when('/rate', {
            //    templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/rate.html',
            //    controller: 'rateController',
            //    controllerAs: 'rc'
            //}).when('/myPoints', {
            //    templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/myPoints.html',
            //    controller: 'myPointsController',
            //    controllerAs: 'mpc'
            });

            $locationProvider.html5Mode(false);

        }]);

})();