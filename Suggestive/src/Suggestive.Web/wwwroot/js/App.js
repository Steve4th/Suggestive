(function () {
    "use strict";

    angular.module("suggestive", ["controls"]);

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

    angular.module("controls", [])
            .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            templateUrl: "/waitCursor.html"
        };
    }
})();