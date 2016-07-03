(function () {
    "use strict";

    angular.module(APPNAME)
    .controller('publicController', PublicController);

    PublicController.$inject = ['$scope', '$publicService'];

    function PublicController(
        $scope
        ,$publicService
        ) {

        var vm = this;
        vm.public = null;

        vm.$scope = $scope;
        vm.$publicService = $publicService;

        vm.logOff = _logOff;
        vm.logOffSuccess = _logOffSuccess;
        vm.logOffErr = _logOffErr;

        init();

        function init() {
            console.log("public controller loaded");
        }

        function _logOff(){
            console.log("log off clicked");
            vm.$publicService.logOut(vm.logOffSuccess, vm.logOffErr);
        }

        function _logOffSuccess() {
            console.log("log off succss");
            window.location.href = '/';
        }

        function _logOffErr() {
            console.log("log off error");
        }

    }

})();