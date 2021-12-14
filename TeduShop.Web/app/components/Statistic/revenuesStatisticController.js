(function (app) {
    app.controller('revenuesStatisticController', revenuesStatisticController)
    revenuesStatisticController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function revenuesStatisticController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.getStatistic = getStatistic;
        $scope.tbldata = [];

        $scope.labels = [];
        $scope.series = ['Doanh thu', 'Lợi Nhuận'];
        $scope.data = [];
        $scope.colors = ['#803690', '#46BFBD'];
       
        $scope.datasetOverride = [{ yAxisID: 'y-axis-1' }, { yAxisID: 'y-axis-2' }];

        $scope.options = {
            responsive: true,
            scales: {
                yAxes: [
                    {
                        id: 'y-axis-1',
                        type: 'linear',
                        display: true,
                        position: 'left',
                        ticks: {
                            beginAtZero: true,
                            userCallback: function (value, index, values) {
                                return value.toLocaleString();   // this is all we need
                            }
                        }
                    },
                    {
                        id: 'y-axis-2',
                        type: 'linear',
                        display: true,
                        position: 'right',
                        ticks: {
                            beginAtZero: true,
                            userCallback: function (value, index, values) {
                                return value.toLocaleString();   // this is all we need
                            }
                        }
                    },

                ]
            },
            //tooltips: {
            //    callbacks: {
            //        label: function (tooltipItem, data) {
            //            return tooltipItem.yLabel.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
            //        }
            //    }
            //}
        };

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