angular.module("controls", [])
        .directive("sgWaitCursor", sgWaitCursor);

function sgWaitCursor() {
    return {
        scope: {
            show: "=displayWhen"
        },
        restrict: "E",
        templateUrl: "/app/controls/sgWaitCursor.html"
    };
}