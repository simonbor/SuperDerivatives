(function () {

    var app = angular.module("MathematicLab", ['ngSanitize']);

    var mainController = function ($scope, $http) {

        var onError = function (reason) {
            $scope.error = "Could not fetch the data - : " + reason.status;
            $scope.new_body = $scope.error;
        };

        var fillOperations = function (response) {
            $scope.opers = response.data || { };
        };

        $scope.getOperations = function () {
            $http({
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                url: "/api/sd/operations"

            }).then(fillOperations, onError);
        }

        var fillResult = function (response) {
            $scope.result = response.data || 'NA';
        };

        $scope.calculate = function (operand_1, operand_2, operation) {
            $http({
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                data: { Operand_1: operand_1, Operand_2: operand_2, Operation: operation },
                url: "/api/Mathematic/Calculate"
            }).then(fillResult, onError);
        };

        $scope.caption = "Mathematic Lab";
        $scope.getOperations();
    };

    app.controller("mainController", mainController);
})();
