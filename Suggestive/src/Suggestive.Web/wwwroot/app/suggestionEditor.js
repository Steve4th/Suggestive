angular.module("app")
    .controller("SuggestionEditor", SuggestionEditor);

function SuggestionEditor($routeParams, $http) {
    var vm = this;

    vm.errorMessage = "";
    vm.statusMessage = "";
    vm.isBusy = true;
    vm.suggestionId = $routeParams.suggestionId;
    vm.suggestion = {};
    
    vm.getSuggestion = function () {
        $http.get("/api/suggestions/" + vm.suggestionId)
            .then(function(response) {
                angular.copy(response.data, vm.suggestion)
            }, 
            function(error) {
                vm.errorMessage = "Problem getting suggestion: " + error.status + " - " + error.statusText;
            })
            .finally(function() {
                vm.isBusy = false;
            });
    }
    vm.getSuggestion();

    vm.updateSuggestion = function () {
        $http.put("/api/suggestions/"  + vm.suggestionId, vm.suggestion)
            .then(function (response) {
                vm.statusMessage = "Suggestion updated successfully";
            }, function (error) {
                vm.errorMessage = "Failed to save suggestion: " + error.status + " - " + error.statusText;
            });
    }
}