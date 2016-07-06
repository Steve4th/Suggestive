'use strict';
(function () {
    angular.module('app', ['controls', 'ngRoute'])
        .config(["$routeProvider", function ($routeProvider) {
            $routeProvider.when('/', {
                controller: 'Suggestions',
                controllerAs: 'vm',
                templateUrl: '/app/suggestions.html'
            });

            $routeProvider.when('/editor/:suggestionId', {
                controller: 'SuggestionEditor',
                controllerAs: 'vm',
                templateUrl: '/app/suggestionEditor.html'
            });

            $routeProvider.otherwise({ redirectTo: '/' });
        }]);
})();
(function() {
    SuggestionEditor.$inject = ["$routeParams", "$http", "dataService"];
    angular.module('app')
        .controller('SuggestionEditor', SuggestionEditor);

    function SuggestionEditor($routeParams, $http, dataService) {
        var vm = this;

        vm.errorMessage = '';
        vm.statusMessage = '';
        vm.isBusy = true;
        vm.suggestionId = $routeParams.suggestionId;
        vm.suggestion = {};
        
        vm.getSuggestion = function () {
            dataService.getSuggestion(vm.suggestionId)
                .then(function(response) {
                    angular.copy(response.data, vm.suggestion);
                }, 
                function(error) {
                    vm.errorMessage = 'Problem getting suggestion: ' + error.status + ' - ' + error.statusText;
                })
                .finally(function() {
                    vm.isBusy = false;
                });
        };

        vm.getSuggestion();

        vm.updateSuggestion = function () {
            dataService.updateSuggestion(vm.suggestion)
                .then(function (response) {
                    vm.statusMessage = 'Suggestion updated successfully';
                }, function (error) {
                    vm.errorMessage = 'Failed to save suggestion: ' + error.status + ' - ' + error.statusText;
                });
        };
    }
})();
(function() {
    Suggestions.$inject = ["$http", "dataService"];
    angular.module('app')
        .controller('Suggestions', Suggestions);

    function Suggestions($http, dataService) {

        var vm = this;
        vm.suggestions = [];
        vm.newSuggestion = {};
        vm.errorMessage = '';
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
                    vm.errorMessage = 'Problem getting suggestions: ' + error.status + ' - ' + error.statusText;
                });
        }

        function addSuggestion() {
            vm.isBusy = true;
            vm.errorMessage = '';

            vm.saveSuggestion();

            vm.newSuggestion = {};
            vm.isBusy = false;
        }

        function saveSuggestion() {
            dataService.addSuggestion(vm.newSuggestion)
                .then(function (response) {
                    vm.suggestions.push(response.data);
                }, function (error) {
                    vm.errorMessage = 'Failed to save suggestion: ' + error.status + ' - ' + error.statusText;
                });
        }
    }
})();
(function() {
    angular.module('controls', [])
            .directive('sgWaitCursor', sgWaitCursor);

    function sgWaitCursor() {
        return {
            scope: {
                show: '=displayWhen'
            },
            restrict: 'E',
            templateUrl: '/app/controls/sgWaitCursor.html'
        };
    }
})();

'use strict';
(function () {
    dataService.$inject = ["$http"];
  angular.module('app')
        .factory('dataService', dataService);

    function dataService($http) {
        var service = {
            getAllSuggestions: getSuggestions,
            getSuggestion: getSuggestion,
            addSuggestion: addSuggestion,
            updateSuggestion: updateSuggestion
        };
        return service;

        function getSuggestions() {
            return $http.get('/api/suggestions');
        }

        function addSuggestion(newSuggestion) {
            return $http.post('/api/suggestions/', newSuggestion);
        }

        function getSuggestion(id) {
            return $http.get('/api/suggestions/' + id);
        }

        function updateSuggestion(suggestion) {
            return $http.put('/api/suggestions/'  + suggestion.id, suggestion);
        }
    }
})();