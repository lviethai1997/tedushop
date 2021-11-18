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
            height: '500px',
            language: 'vi'
        }

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        function Addproduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);
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

        $scope.moreImages = [];

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder()
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl)
                })
            }
            finder.popup();
        }

        LoadCategoriesID();
    }
})(angular.module('tedushop.products'));