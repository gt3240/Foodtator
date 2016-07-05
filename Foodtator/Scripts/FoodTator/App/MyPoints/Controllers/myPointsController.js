(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('myPointsController', MyPointsController);

    MyPointsController.$inject = ['$scope'];

    function MyPointsController(
         $scope
        ) {

        var vm = this;

        vm.$scope = $scope;
        vm.user = null;

        init();

        function init() {
            console.log("MyPointsController loaded");

            vm.user = JSON.parse($("#modelData").html());
            console.log("user is ", vm.user);
        }


    }
})();