(function () {
    "use strict";

    angular.module(APPNAME)
        .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

            $routeProvider.when('/selectionLoaded', {
                templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/selectionLoaded.html',
                controller: 'selectionLoadedController',
                controllerAs: 'slc'
            }).when('/rate', {
                templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/rate.html',
                controller: 'rateController',
                controllerAs: 'rc'
            }).when('/myPoints', {
                templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/myPoints.html',
                controller: 'myPointsController',
                controllerAs: 'mpc'
            });

            $locationProvider.html5Mode(false);

        }]);

})();