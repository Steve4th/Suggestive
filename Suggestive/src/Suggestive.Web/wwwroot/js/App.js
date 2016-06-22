(function () {
    "use strict";

    angular.module("suggestive", []);

    angular.module("suggestive")
        .controller("suggestionController", suggestionController)

    function suggestionController() {

        var vm = this;

        vm.name = "suggestion please";

    }

})();