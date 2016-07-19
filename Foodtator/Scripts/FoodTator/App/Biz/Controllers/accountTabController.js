(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('accountTabController', AccountTabController);

    AccountTabController.$inject = ['$scope','$route', '$routeParams'];

    function AccountTabController(
          $scope
        , $route
        , $routeParams) {

        var vm = this;

        vm.$scope = $scope;
        vm.$route = $route;
        vm.$routeParams = $routeParams;
        vm.setUpCurrentRequest = _setUpCurrentRequest;
        vm.tabClass = _tabClass;
        vm.setSelectedTab = _setSelectedTab;

        vm.currentRequestLabel = "Current Request:";

        vm.tabs = [
            { link: '#/account/avatar/', label: 'Avatar', controller: ['accountAvatarController'] },
            { link: '#/account/email/', label: 'Change Email', controller: ['accountEmailController'] },
            { link: '#/account/password/', label: 'Set Password', controller: ['accountPasswordController'] },

        ];
        vm.setUpCurrentRequest(vm);

        vm.selectedTab = vm.tabs[0];

        //loop through each tab
        for (var x = 0; x < vm.tabs.length; x++) {
            //  check the controller property of each tab to see if it matches the current reaquest
            if (vm.tabs[x].controller && vm.tabs[x].controller.indexOf(vm.currentRequest.$$route.controller) > -1) {
                //  if it matches: set that tab as selected (override line 36) note of indeOF 
                vm.selectedTab = vm.tabs[x];
                break;
            }
        }

        function _tabClass(tab) {
            if (vm.selectedTab == tab) {
                return "active";
            } else {
                return "";
            }
        }

        function _setSelectedTab(tab) {
            console.log("set selected tab", tab);
            vm.selectedTab = tab;
        }

        function _setUpCurrentRequest(viewModel) {
            viewModel.currentRequest = { originalPath: "/", isTop: true };

            if (viewModel.$route.current) {
                viewModel.currentRequest = viewModel.$route.current;
                viewModel.currentRequest.locals = {};
                viewModel.currentRequest.isTop = false;
            }
        }
    }
})();