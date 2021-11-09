(function (app) {
    app.controller('productCategoryListController', productCategoryListController)

    productCategoryListController.$inject = ['$scope','apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.getListProductCategory = [];

        $scope.getListProductCategory = getListProductCategory;

        function getListProductCategory() {
            apiService.get('/api/productCategory/GetAll', null, function (result) {
                $scope.getListProductCategory = result.data;
            }, function () {
                console.log("load productCategory Failed.");
            });
        }

        $scope.getListProductCategory();
    }
})(angular.module('tedushop.ProductCategories'));