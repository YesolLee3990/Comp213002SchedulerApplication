
angular.module('demo', ['textAngular']).controller('demoCtrl', function ($scope) {

    $scope.timesSubmitted = 0;
    $scope.testFrm = {};

    $scope.test = function () {
        $scope.timesSubmitted++;
    };

    $scope.accessFormFromScope = function () {
        alert("Form Invalid: " + $scope.testFrm.$invalid);
    }

});