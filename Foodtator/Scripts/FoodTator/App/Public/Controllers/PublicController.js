(function () {
    "use strict";

    angular.module(APPNAME)
    .controller('publicController', PublicController);

    PublicController.$inject = ['$scope','$publicService'];

    function PublicController(
        $scope,
        $baseController,
        $publicService
        ) {

        
        var vm = this; 
        vm.public = null;

        vm.$publicService = $publicService;
        vm.$scope = $scope;

        
        vm.logOut = _logOut;
        vm.logIn = _logIn;
        vm.register = _register;
        vm.logOutSuccess = _logOutSuccess;
        vm.logOutError = _logOutError;

        // simulate inheritance
        $baseController.merge(vm, $baseController);

        function _logOut() {
           
            vm.$publicService.logOut(vm.logOutSuccess,vm.logOutError);
        }

        function _logOutSuccess() {
            console.log("Logged out success");
            window.location.href = '/';
          
        }

        function _logIn() {
            window.location.href = '/user/logIn/';
        }

        function _register() {
            window.location.href = '/user/register/';
        }

        function _logOutError() {
            console.log("Log Out Error");
        }

    }

})();