(function (app) {
    app.controller('productAddController', productAddController)

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];


    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag: true
        }

        $scope.ChooseImage = ChooseImage;
        $scope.Addproduct = Addproduct;
        $scope.getSeoTitle = getSeoTitle;
        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        $scope.ckeditorOptions = {
            height: '200px',
            language: 'vi'
        }

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }
        
        function Addproduct() {
            apiService.post('api/product/Create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('products_list');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
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
    }
})(angular.module('tedushop.products'));