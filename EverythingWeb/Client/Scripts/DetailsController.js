(function (app) {
    var DetailsController = function ($scope, $http, $routeParams) {
        var id = $routeParams.id;
        $http.get("/api/musicapi/getmusic/" + id).then(function (respsone) {
            $scope.music = respsone.data;
        });

        $scope.edit = function () {
            $scope.edit.music = angular.copy($scope.music);
        };

    };
    app.controller("DetailsController", DetailsController);
}(angular.module("music")));;