/// <reference path="../../../assets/admin/scripts/angular.js" />

(function () {
    angular.module('tedushop.ProductCategories', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];



    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productsCategory_list', {
            url: "/productsCategory_list",
            templateUrl: "/app/components/ProductCategories/productCategoryListView.html",
            controller: "productCategoryListController"
        }).state('productsCategory_add_view', {
            url: "/productsCategory_add_view",
            templateUrl: "/app/components/ProductCategories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        }).state('productsCategory_edit_view', {
            url: "/productsCategory_edit_view/:id",
            templateUrl: "/app/components/ProductCategories/productCategoryEditView.html",
            controller: "productCategoryEditController"
        });
    }
})();