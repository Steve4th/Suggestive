(function() {
    angular.module("app")
        .controller("Suggestions", Suggestions);

    function Suggestions($http, dataService) {

        var vm = this;
        vm.suggestions = [];
        vm.newSuggestion = {};
        vm.errorMessage = "";
        vm.isBusy = true;
        vm.saveSuggestion = saveSuggestion;
        vm.addSuggestion = addSuggestion; 

        activate();

        function activate() {
            vm.isBusy = true;
            vm.suggestions = getSuggestions();
            vm.isBusy = false;
        }
        
        function getSuggestions() {
            dataService.getAllSuggestions()
                .then(function(response) {
                    vm.suggestions = response.data || [];
                }, 
                function (error) {
                    vm.errorMessage = "Problem getting suggestions: " + error.status + " - " + error.statusText;
                });
        }

        function addSuggestion() {
            vm.isBusy = true;
            vm.errorMessage = "";

            vm.saveSuggestion();

            vm.newSuggestion = {};
            vm.isBusy = false;
        }

        function saveSuggestion() {
            dataService.addSuggestion(vm.newSuggestion)
                .then(function (response) {
                    vm.suggestions.push(response.data);
                }, function (error) {
                    vm.errorMessage = "Failed to save suggestion: " + error.status + " - " + error.statusText;
                });
        }
    }
})();