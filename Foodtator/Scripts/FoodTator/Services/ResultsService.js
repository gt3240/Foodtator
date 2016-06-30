(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('$resultsService', resultsServiceFactory);

    resultsServiceFactory.$inject = ['$http', '$baseService'];

    function resultsServiceFactory($http, $baseService) {
        var svc = this;

    

        $.extend(svc, $baseService);

        function _register(data, onSuccess, onErr) {
            $http.post("/api/user/register/", data).success(onSuccess).error(onErr);
        };

        function _login(data, onSuccess, onErr) {
            $http.post("/api/user/login/", data).success(onSuccess).error(onErr);
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