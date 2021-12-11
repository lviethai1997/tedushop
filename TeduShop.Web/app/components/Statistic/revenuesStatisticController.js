(function (app) {
    app.controller('revenuesStatisticController', revenuesStatisticController)
    revenuesStatisticController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function revenuesStatisticController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.getStatistic = getStatistic;
        $scope.tbldata = [];

        $scope.labels = [];
        $scope.series = ['Doanh thu', 'Lợi Nhuận'];
        $scope.data = [];

        function getStatistic() {
            var config = {
                param: {
                    fromDate: '01/01/2021',
                    toDate: '01/01/2022'
                }
            }
            apiService.get('api/statistic/getRevenues?fromDate=' + config.param.fromDate + "&toDate=" + config.param.toDate, null, function (response) {
                $scope.tbldata = response.data;
                var labels = [];
                var data = [];
                var revenues = [];
                var benefit = [];
                $.each(response.data, function (i, item) {
                    labels.push($filter('date')(item.CreateDate,'yyyy-MM-dd'));
                    revenues.push(item.Revenues);
                    benefit.push(item.Benefit);
                })

                data.push(revenues);
                data.push(benefit);
                $scope.data = data;
                $scope.labels = labels;
            }, function (response) {
                notificationService.displayError("loi");
            })
        }


        getStatistic();
    }
})(angular.module('tedushop.statistic'));