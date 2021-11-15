(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];

    function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag:true
        }

        $scope.AddProductCategory = AddProductCategory;
        $scope.getSeoTitle = getSeoTitle;
        function getSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function AddProductCategory() {
            apiService.post('api/productCategory/Create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('productsCategory_list');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function LoadparentCategories() {
            apiService.get("api/productCategory/getAllParent", null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log("cant get parentID");
            })
        }

        LoadparentCategories();
    }
})(angular.module('tedushop.ProductCategories'))