angular.module("controls", [])
        .directive("waitCursor", waitCursor);

function waitCursor() {
    return {
        scope: {
            show: "=displayWhen"
        },
        restrict: "E",
        templateUrl: "/app/controls/waitCursor.html"
    };
}