(function () {
    "use strict";

    angular.module("suggestive", []);

    angular.module("suggestive")
        .controller("suggestionController", suggestionController)

    function suggestionController() {

        var vm = this;

        vm.suggestions = [{
            title: "suggestion one",
            createdOn: new Date(),
            description: "Change the world to be a better place"
        }, {
            title: "suggestion two",
            createdOn: new Date(),
            description: "fly me to the moon"
        }];

    }

})();