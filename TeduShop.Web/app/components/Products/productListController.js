(function (app) {
    app.controller('productListController', productListController)

    function productListController() {

    }
    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProducts = getProducts;
        $scope.keyword = '';
        $scope.delProduct = delProduct;
        $scope.search = search;
        $scope.checkAll = checkAll;
        $scope.deleteMultiple = deleteMultiple;
        $scope.updateStatus = updateStatus;

        $scope.isAll = false;
        function checkAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }

        function deleteMultiple() {
            var listid = '';
            $.each($scope.selected, function (i, item) {
                listid += item.ID + ',';
            })

            var config = {
                params: {
                    items: listid
                }
            }

            apiService.del('/api/product/DeleteMulti', config, function () {
                notificationService.displaySuccess('Xóa thành công!')
                search()
            }, function () {
                notificationService.displayError('Xóa không thành công!')
            })
        }

        $scope.$watch('products', function (n, o) {
            var checked = $filter('filter')(n, { checked: true });

            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true)

        function search() {
            getProducts();
        }

        function delProduct(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('/api/product/Delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!')
                    search()
                }, function () {
                    notificationService.displayError('Xóa không thành công!')
                })
            })
        }

        function updateStatus(id) {
            var config = {
                params: {
                    id: id
                }
            }
          
            apiService.get('/api/product/ChangeStatus', config,
                function (result) {
                    notificationService.displaySuccess(' Đã được cập nhật.');
                    search()
                }, function (error) {
                    notificationService.displayError('cập nhật không thành công.');
                });
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/product/GetAll', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy dữ liệu nào!')
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product failed.');
            });
        }

        $scope.getProducts();
    }
})(angular.module('tedushop.products'));