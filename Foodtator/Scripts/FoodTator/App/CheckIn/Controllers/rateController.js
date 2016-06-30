(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('rateController', RateController);

    RateController.$inject = ['$scope'];

    function RateController(
         $scope
        ) {

        var vm = this;

        vm.$scope = $scope;

        init();

        function init() {
            console.log("RateController loaded");
        }


    }
})();