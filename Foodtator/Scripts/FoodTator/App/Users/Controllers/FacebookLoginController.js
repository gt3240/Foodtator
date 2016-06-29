(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('facebookLoginController', FacebookLoginController);

    FacebookLoginController.$inject = ['$scope', '$fbService', '$userService', '$uibModal'];

    function FacebookLoginController(
         $scope
        , $fbService
        , $userService
        , $uibModal) {

        var vm = this;

        vm.$scope = $scope;
        vm.$fbService = $fbService;
        vm.$userService = $userService;
        vm.$uibModal = $uibModal;

        vm.fblogin = _fblogin;
        vm.statusChangeCallback = _statusChangeCallback;
        vm.fbUserInfoLoaded = _fbUserInfoLoaded;
        vm.externalAuthResult = _externalAuthResult;
        vm.mergeAccounts = _mergeAccounts;
        vm.openModal = _openModal;
        vm.ajaxErr = _ajaxErr;

        vm.payload = null;
        vm.loading = false;
        vm.registerBtnText = "Facebook";

        init();

        function init() {
            console.log("fb connecting");
            vm.$fbService.init();
        }

        function _fblogin() {
            vm.$fbService.checkLoginStatus(vm.statusChangeCallback);
            vm.loading = true;
            vm.registerBtnText = "Loading...";
        }

        function _statusChangeCallback(response) {
            console.log('statusChangeCallback');
            console.log(response);

            if (response.status === 'connected') {
                // Logged into your app and Facebook.
                vm.$fbService.getUserInfo(vm.fbUserInfoLoaded);

            } else if (response.status === 'not_authorized') {
                // The person is logged into Facebook, but not your app.
                document.getElementById('status').innerHTML = 'Please log ' +
                  'into this app.';

            } else {
                // The person is not logged into Facebook, so we're not sure if
                // they are logged into this app or not.
                document.getElementById('status').innerHTML = 'Please log ' +
                  'into Facebook.';
            }
        };

        function _fbUserInfoLoaded(payload) {
            vm.payload = payload;
            console.log("payload", payload);
            vm.$userService.checkExternalAuthEmail(payload, vm.externalAuthResult, vm.ajaxErr);
           
        };

        function _externalAuthResult(data) {
            console.log("external auth data", data)
            if (data.Item.Id) {
                console.log("logged in", data.Item.Id);
                //window.location.href = '/user/profile/' + data.item.Id;
            } else {
                console.log("dup user alert");
                vm.payload.userId = data.item;
                vm.openModal();
            }
        };

        function _openModal() {
            var item = "modal";
            var modalInstance = vm.$uibModal.open({
                animation: true,
                templateUrl: 'modalContent.html',
                controller: 'modalController as mc',
                resolve: {
                    items: function () {
                        return item;
                    }
                }
            });

            modalInstance.result.then(function (msg) {

                if (msg == 'merge') {
                    vm.mergeAccounts();
                }

            }, function () {
                console.log('Modal dismissed at: ' + new Date());
            });
        }

        function _mergeAccounts() {
            console.log("merging accounts", vm.payload);
            vm.$publicService.externalAuthInsert(vm.payload, vm.externalAuthResult, vm.ajaxErr);
        };

        function _ajaxErr() {
            console.log("ajax error!");
        };

    }
})();

// modal controller
(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('modalController', ModalController);

    ModalController.$inject = ['$scope','$uibModalInstance', 'items']

    function ModalController(
        $scope
        , $uibModalInstance
        , items) {

        var vm = this;

        vm.$scope = $scope;
        vm.$uibModalInstance = $uibModalInstance;

        vm.ok = function () {
            vm.$uibModalInstance.close("merge");
        };

        vm.cancel = function () {
            vm.$uibModalInstance.dismiss('cancel');
        };
    }
})();
