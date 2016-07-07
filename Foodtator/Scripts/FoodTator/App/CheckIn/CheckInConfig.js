(function () {
    "use strict";

    angular.module(APPNAME)
        .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

            $routeProvider.when('/selectionLoaded', {
                templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/selectionLoaded.html',
                controller: 'selectionLoadedController',
                controllerAs: 'slc'
            }).when('/share/:event', {
                templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/share.html',
                controller: 'shareController',
                controllerAs: 'sc'
            }).when('/myPoints', {
                templateUrl: '/Scripts/FoodTator/App/CheckIn/Templates/myPoints.html',
                controller: 'myPointsController',
                controllerAs: 'mpc'
            });

            $locationProvider.html5Mode(false);

        }]);

})();