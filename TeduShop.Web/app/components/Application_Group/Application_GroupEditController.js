(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag: true
        }
        $scope.UpdateProductCategory = UpdateProductCategory;

        $scope.getSeoTitle = getSeoTitle;

        function getSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productCategory/GetById/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProductCategory() {
            apiService.put('api/productCategory/Update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('productsCategory_list');
                }, function (error) {
                    notificationService.displayError('cập nhật không thành công.');
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
        loadProductCategoryDetail();
    }
})(angular.module('tedushop.ProductCategories'))