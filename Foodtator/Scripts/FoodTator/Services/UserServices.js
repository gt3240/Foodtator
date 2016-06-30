(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('$userService', userServiceFactory);

    userServiceFactory.$inject = ['$http', '$baseService'];

    function userServiceFactory($http, $baseService) {
        var svc = this;

        svc.test = _test;
        svc.getLeads = _getLeads;
        svc.register = _register;
        svc.login = _login;
        svc.checkExternalAuthEmail = _checkExternalAuthEmail;
        svc.externalAuthInsert = _externalAuthInsert;

        $.extend(svc, $baseService);

        function _test() {
            console.log("service working");
        };

        function _getLeads(leads) {
            $http.get("http://localhost:1337/api/lead/list").success(leads).error(function (err) {
                console.log(err);
            });
        };

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