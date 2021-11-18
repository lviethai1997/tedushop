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
            height: '500px',
            language: 'vi'
        }

        function loadproductDetail() {
           
            apiService.get('api/product/GetById/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImage);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updateproduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);
            apiService.put('api/product/Update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('products_list');
                }, function (error) {
                    notificationService.displayError('cập nhật không thành công.');
                });
        }

        $scope.ChooseImage = ChooseImage;

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
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
        loadproductDetail();
    }
})(angular.module('tedushop.products'));