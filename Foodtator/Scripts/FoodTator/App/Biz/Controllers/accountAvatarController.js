(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('accountAvatarController', AccountAvatarController);

    AccountAvatarController.$inject = ['$scope'];

    function AccountAvatarController(
         $scope
        ) {

        var vm = this;
        vm.$scope = $scope;

        /****  Variables ***/
        vm.dropzone = null;
        vm.dzConfig = {
            autoProcessQueue: true,
            uploadMultiple: false,
            parallelUploads: 1,
            maxFiles: 1,
            maxFileSize: 5,
            url: "/api/photouploader/UploadWithData"
        };


        /****  Functions ***/
        // Dropzone event handler functions
        vm.dzAddedFile = _dzAddedFile;
        vm.dzError = _dzError;
        vm.dzOnSending = _dzOnSending;
        vm.dzOnSuccess = _dzOnSuccess;
        vm.onUpdateImage = _onUpdateImage;

        init();

        function init() {
            console.log("accountAvatarController loaded");
        }

        // DROPZONE
        function _dzAddedFile(file, response) {
            console.log("dzAddedFile works");
        };

        function _dzError(file, errorMessage) {
            console.log(errorMessage);
        };

        function _dzOnSending(file, xhr, formData) {
            //console.log("photo sent to database");
            formData.append("Title", $('#Title').val());
            formData.append("Description", $('#Description').val());
            formData.append("MediaType", 2);
        };

        function _dzOnSuccess(file, response) {
            console.log("mediaId is " + response.item);
            vm.mediaId = response.item;
            vm.onUpdateImage(vm.mediaId);
            vm.dropzone.removeFile(file);
        };

        function _onUpdateImage(id) {
            console.log("media id is ", id);
        }


    }
})();