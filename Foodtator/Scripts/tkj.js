var tkj = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}

};

tkj.moduleOptions = {
    APPNAME: "FoodtatorApp"
        , extraModuleDependencies: []
        , runners: []
        , page: tkj.page//we need this object here for later use
}


tkj.layout.startUp = function () {

    console.debug(tkj.APPNAME + " started");

    //this does a null check on tkj.page.startUp
    if (tkj.page.startUp) {
        console.debug(tkj.APPNAME + " started");
        tkj.page.startUp();
    }

};
tkj.APPNAME = "FoodtatorApp";//legacy




$(document).ready(tkj.layout.startUp);