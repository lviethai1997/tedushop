(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];

    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag: true
        }
        $scope.Updateproduct = Updateproduct;

        $scope.getSeoTitle = getSeoTitle;

        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        $scope.ckeditorOptions = {
            height: '200px',
            language: 'vi'
        }

        function loadproductDetail() {
            apiService.get('api/product/GetById/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updateproduct() {
            apiService.put('api/product/Update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('products_list');
                }, function (error) {
                    notificationService.displayError('cập nhật không thành công.');
                });
        }

        function LoadCategoriesID() {
            apiService.get("api/productCategory/getAllParent", null, function (result) {
                $scope.CategoriesID = result.data;
            }, function () {
                console.log("cant get parentID");
            })
        }

        LoadCategoriesID();
        loadproductDetail();
    }
})(angular.module('tedushop.products'));