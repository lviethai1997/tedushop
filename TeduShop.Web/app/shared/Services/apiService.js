﻿/// <reference path="../../../assets/admin/scripts/angular.js" />


(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get:get
        }

        function get(url, params, success, failed) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failed(error);
            });
        }
    }

})(angular.module('tedushop.common'))