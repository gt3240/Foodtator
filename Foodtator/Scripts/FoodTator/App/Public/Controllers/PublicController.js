//**Public Controller Factory**

(function () {
    "use strict";

    angular.module(APPNAME)
    .controller('publicController'/*name*/, PublicController/*definition*/);

    PublicController.$inject = ['$scope', '$baseController', '$publicService', '$window'];

    function PublicController(
        $scope,
        $baseController,
        $publicService,
        $window) {

        //controllerAs with vm syntax - john papa style
        var vm = this; //this points to a new {}
        vm.public = null;

        vm.$publicService = $publicService;
        vm.$scope = $scope;

        // **HOIST HERE**bindable members (functions) always go up top 
        vm.logOut = _logOut;
        vm.logIn = _logIn;
        vm.register = _register;

        // simulate inheritance
        $baseController.merge(vm, $baseController);

        // wrapper for small dependency on $scope
        vm.notify = vm.$publicService.getNotifier($scope);

        //this is like the sabio.startUp function

        function _logOut() {
            vm.$publicService.logOut(_logOutSuccess);
        }

        function _logOutSuccess() {
            vm.$alertService.success("You have been logged out");
            $window.location.href = '/public/logIn/';
        }

        function _logIn() {
            $window.location.href = '/user/logIn/';
        }

        function _register() {
            $window.location.href = '/user/register/';
        }

    }

})();