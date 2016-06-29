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

        $.extend(svc, $baseService);

        function _test() {
            console.log("service working");
        };

        function _getLeads(leads) {
            $http.get("http://localhost:1337/api/lead/list").success(leads).error(function (err) {
                console.log(err);
            });
        };

        function _register(data, onSucess, onErr) {
            $http.post("/api/user/register/", data).success(onSucess).error(onErr);
        };

        function _login(data, onSucess, onErr) {
            $http.post("/api/user/login/", data).success(onSucess).error(onErr);
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

        return svc;
    };


    
})();