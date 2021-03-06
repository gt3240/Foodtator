﻿(function (moduleOptions) {
    "use strict";

    //  https://github.com/johnpapa/angular-styleguide#moduleOptionss
    var defaultDependencies = [
        'ui.bootstrap'
        ,'ngRoute'
        ,'ngAnimate'
        , '720kb.fx'
        //, 'countTo'
        //,'toastr'
    ];

    var arrOfDep = getModuleDependencies(moduleOptions, defaultDependencies);
    //console.log('array of dependencies', arrOfDep);

    var app = angular.module(moduleOptions.APPNAME, arrOfDep);
    //console.log("model", app);
    app.value('$tkj', moduleOptions.page);

    if (moduleOptions) {
        processModuleOptions(moduleOptions, app);
    }


    function getModuleDependencies(opts, defaults) {
        if (opts && opts.extraModuleDependencies) {
            var newItems = defaults.concat(opts.extraModuleDependencies);
            return newItems;
        }
        return defaults;
    }

    function processModuleOptions(opts, clientApp) {
        if (!opts) {
            return;
        }

        if (opts.runners) {
            for (var i = 0; i < opts.runners.length; i++) {
                var runner = opts.runners[i];
                clientApp.run(runner);
            }
        }


    }

})(tkj.moduleOptions);