/// <reference path="../../../assets/admin/scripts/angular.js" />

(function () {
    angular.module('tedushop.ProductCategories', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productsCategory_list', {
            URL: "/productsCategory_list",
            templateUrl: "/app/components/ProductCategories/productCategoryListView.html",
            controller: "productCategoryListController"
        });
    }
})();