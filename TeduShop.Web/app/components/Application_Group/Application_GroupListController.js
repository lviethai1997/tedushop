(function (app) {
    app.controller('productCategoryListController', productCategoryListController)

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCagories = getProductCagories;
        $scope.keyword = '';
        $scope.delProductCategory = delProductCategory;
        $scope.search = search;
        $scope.checkAll = checkAll;
        $scope.deleteMultiple = deleteMultiple;



        $scope.isAll = false;
        function checkAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
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

            apiService.del('/api/productCategory/DeleteMulti', config, function () {
                notificationService.displaySuccess('Xóa thành công!')
                search()
            }, function () {
                notificationService.displayError('Xóa không thành công!')
            })
        }

        $scope.$watch('productCategories', function (n, o) {
            var checked = $filter('filter')(n, { checked: true });

            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true)

        function search() {
            getProductCagories();
        }

        function delProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('/api/productCategory/Delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!')
                    search()
                }, function () {
                    notificationService.displayError('Xóa không thành công!')
                })
            })
        }

        function getProductCagories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/productCategory/GetAll', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy dữ liệu nào!')
                }

                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }

        $scope.getProductCagories();
    }
})(angular.module('tedushop.ProductCategories'));