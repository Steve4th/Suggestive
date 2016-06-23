(function () {
    "use strict";

    angular.module("suggestive", []);

    angular.module("suggestive")
        .controller("suggestionController", suggestionController)

    function suggestionController($http) {

        var vm = this;

        vm.suggestions = [];

        vm.newSuggestion = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        vm.addSuggestion = function () {
            vm.suggestions.push({
                title: vm.newSuggestion.title,
                createdOn: new Date(),
                description: ""
            });
            vm.newSuggestion = {};
        }

        $http.get("/api/suggestions")
            .then(function (response) {
                //success
                angular.copy(response.data, vm.suggestions)
            },
            function (error) {
                //failure
                vm.errorMessage = "Problem getting suggestions: " + error.status + " - " + error.statusText;
            })
        .finally(function () {
            vm.isBusy = false;
        });
    }
})();