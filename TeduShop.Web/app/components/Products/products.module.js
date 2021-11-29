/// <reference path="../../../assets/admin/scripts/angular.js" />

(function () {
    angular.module('tedushop.products', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products_list', {
            url: "/products_list",
            parent:'base',
            templateUrl: "/app/components/Products/productListView.html",
            controller: "productListController"
        }).state('product_add_view', {
            url: "/product_add_view",
            parent: 'base',
            templateUrl: "/app/components/Products/productAddView.html",
            controller: "productAddController"
        }).state('product_edit_view', {
            url: "/product_edit_view/:id",
            parent: 'base',
            templateUrl: "/app/components/Products/productEditView.html",
            controller: "productEditController"
        });
    }
})();