/// <reference path="../assets/admin/scripts/angular.js" />


(function () {
    angular.module('tedushop', ['tedushop.products', 'tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/Home/HomeView.html",
            controller: "HomeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();