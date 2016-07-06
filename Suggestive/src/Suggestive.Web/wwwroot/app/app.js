"use strict";
(function () {
    angular.module("app", ["controls", "ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "Suggestions",
                controllerAs: "vm",
                templateUrl: "/app/suggestions.html"
            });

            $routeProvider.when("/editor/:suggestionId", {
                controller: "SuggestionEditor",
                controllerAs: "vm",
                templateUrl: "/app/suggestionEditor.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        });
})();