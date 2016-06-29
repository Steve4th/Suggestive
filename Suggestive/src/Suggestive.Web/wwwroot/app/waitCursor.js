angular.module("controls", [])
        .directive("waitCursor", waitCursor);

function waitCursor() {
    return {
        scope: {
            show: "=displayWhen"
        },
        restrict: "E",
        templateUrl: "/app/waitCursor.html"
    };
}