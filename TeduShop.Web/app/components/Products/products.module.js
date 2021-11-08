/// <reference path="../../../assets/admin/scripts/angular.js" />

(function () {
    angular.module('tedushop.products', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products_list', {
            URL: "/products_list",
            templateUrl: "/app/components/Products/productListView.html",
            controller: "productListController"
        }).state('product_add', {
            URL: "/product_add",
            templateUrl: "/app/components/Products/productAddView.html",
            controller: "productAddController"
        });
    }
})();