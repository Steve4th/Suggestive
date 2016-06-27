(function () {
    "use strict";

//App startup/bootstraoping
    angular.module("suggestive", ["controls", "ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "suggestionController",
                controllerAs: "vm",
                templateUrl: "/app-views/suggestive.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        });

//Suggestive.Controllers.Suggestive
    angular.module("suggestive")
        .controller("suggestionController", suggestionController)

    function suggestionController($http) {

        var vm = this;

        vm.suggestions = [];

        vm.newSuggestion = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        vm.addSuggestion = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            vm.saveSuggestion();

            vm.newSuggestion = {};
            vm.isBusy = false;
        }

        $http.get("/api/suggestions")
            .then(function (response) {
                angular.copy(response.data, vm.suggestions)
            },
            function (error) {
                vm.errorMessage = "Problem getting suggestions: " + error.status + " - " + error.statusText;
            })
        .finally(function () {
            vm.isBusy = false;
        });

        vm.saveSuggestion = function () {
            $http.post("/api/suggestions/", vm.newSuggestion)
                .then(function (response) {
                    vm.suggestions.push(response.data);
                }, function (error) {
                    vm.errorMessage = "Failed to save suggestion: " + error.status + " - " + error.statusText;
                });
        }
    }

// Suggestive.Controls.WaitCursor
    angular.module("controls", [])
            .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            scope: {
                show: "=displayWhen"
            },
            restrict: "E",
            templateUrl: "/app-views/waitCursor.html"
        };
    }
})();