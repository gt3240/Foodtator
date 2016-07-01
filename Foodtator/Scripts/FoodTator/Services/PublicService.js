//**Public service factory**
(function () {//IIFE Boiler Plate
    "use strict";
 
    angular.module(APPNAME)
    .factory('$publicService', publicServiceFactory);

    //Identify dependencies for injection. $sabio is a reference to sabio.page object located in scripts
    publicServiceFactory.$inject = ['$http', '$baseService'];
    function publicServiceFactory($http, $baseService) {

        var svc = this;
        svc.logOut = _logOut;

        $.extend(svc, $baseService);

        function _register(data, onSuccess, onErr) {
            $http.post("/api/user/register/", data).success(onSuccess).error(onErr);
        };

        function _login(data, onSuccess, onErr) {
            $http.post("/api/user/login/", data).success(onSuccess).error(onErr);
        };

        function _logOut(Onsuccess) {
            $http.post("/api/user/LogOut/").success(Onsuccess).error(onErr);
        };

       

        function _checkExternalAuthEmail(payload, onSuccess, onError) {
            $.ajax({
                type: 'GET',
                dataType: "json",
                url: '/api/user/ExternalAuth/' + payload,
                data: payload,
                success: onSuccess,
                error: onError
            });
        }

        function _externalAuthInsert(payload, onSuccess, onError) {
            $http.post("/api/user/ExternalAuth/", payload).success(onSuccess).error(onError);
        }

        return svc;
    };
})();
