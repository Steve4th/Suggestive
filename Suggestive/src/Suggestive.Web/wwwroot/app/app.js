﻿(function () {
    "use strict";

//App startup/bootstraoping
    angular.module("app", ["controls", "ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "suggestionsController",
                controllerAs: "vm",
                templateUrl: "/app/suggestions.html"
            });

            $routeProvider.when("/editor/:suggestionId", {
                controller: "suggestionEditorController",
                controllerAs: "vm",
                templateUrl: "/app/suggestionEditor.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        });
})();