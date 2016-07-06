(function () {
    "use strict";

  angular.module('app')
        .factory('dataService', dataService);

    function dataService($http) {
        var service = {
            getAllSuggestions: getSuggestions,
            addSuggestion: addSuggestion
        };
        return service;

        function getSuggestions() {
            return $http.get("/api/suggestions");
        }

        function addSuggestion(newSuggestion) {
            return $http.post("/api/suggestions/", newSuggestion);
        }
    }
})();