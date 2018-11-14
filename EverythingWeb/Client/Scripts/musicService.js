(function (app) {
    //服务 用于执行API 代替$http
    var musicService = function ($http, musicApiUrl) {
        var getAll = function () {
            return $http.get(musicApiUrl+"getmusics");
        };

        var getById = function (id) {
            return $http.get(musicApiUrl +"getmusic/" + id);
        };

        var update = function (music) {
            return $http.put(musicApiUrl + "putmusic/"+ music.ID, music);
        };

        var create = function (music) {
            return $http.post(musicApiUrl + "postmusic", music);
        };

        var destory = function (music) {
            return $http.delete(musicApiUrl+"deletemusic/" + music.ID);
        };
        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destory
        };
    };

    app.factory("musicService", musicService);


}(angular.module("music")));