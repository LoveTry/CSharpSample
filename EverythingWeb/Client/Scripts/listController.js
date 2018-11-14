//第一种访问music模块的方法
//(function (app) {

//}(angular.module("music")));
//第二种
//(function (app) {
//    var app = angular.module("music");
//}());

//控制器负责通过扩展$scope变量组建模型
//$http包含HTTP异步请求的方法，使用$http服务与服务器上的WebAPI端点进行通信。
(function (app) {
    //var ListController = function ($scope, $http) {
    //    //$scope.message = "Hello, Angluar !";
    //    $http.get("/api/musicapi/getmusics").then(function (respsone) {
    //        //for (var p in respsone) {
    //        //    document.write(p + ":" + respsone[p] + "<br />");
    //        //}
    //        $scope.musics = respsone.data;
    //    });
    //};

    var ListController = function ($scope, musicService) {
        musicService.getAll().then(function (respsone) {
            $scope.musics = respsone.data;
        });

        $scope.delete = function (music) {
            musicService.delete(music).then(function () {
                removeMusic(music.ID);
            });
        };

        $scope.create = function () {
            $scope.edit = {
                music: {
                    Name: "",
                    Singer: ""
                }
            };
        };

        //私有方法 不与$scope对象关联
        var removeMusic = function (id) {
            for (var i = 0; i < $scope.musics.length; i++) {
                if ($scope.musics[i].ID == id) {
                    $scope.musics.splice(i, 1);
                    break;
                }
            }
        };
    };

    //注解组件 防止压缩简化参数名 
    //ListController.$inject = ["$scope", "$http"];
    //注册控制器
    app.controller("ListController", ListController);
}(angular.module("music")));