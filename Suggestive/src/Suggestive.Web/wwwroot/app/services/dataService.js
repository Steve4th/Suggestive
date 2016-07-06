'use strict';
(function () {
  angular.module('app')
        .factory('dataService', dataService);

    function dataService($http) {
        var service = {
            getAllSuggestions: getSuggestions,
            getSuggestion: getSuggestion,
            add: addSuggestion,
            update: updateSuggestion
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