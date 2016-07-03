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

        function _logOut(Onsuccess, onErr) {
            $http.post("/api/user/LogOut/").success(Onsuccess).error(onErr);
        };

        return svc;
    };
})();
