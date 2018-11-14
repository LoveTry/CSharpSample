(function () {
    var app = angular.module("music", ["ngRoute"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/details/:id", { templateUrl: "client/views/details.html", controller: "DetailsController" });

    };
    app.config(config);

    //创建常量给musicService的参数使用
    app.constant("musicApiUrl", "/api/musicapi/");
}());