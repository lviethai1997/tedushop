(function () {
    angular.module('tedushop.statistic', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('statistic_revenues', {
            url: "/statistic_revenues",
            parent: 'base',
            templateUrl: "/app/components/statistic/revenuesStatisticView.html",
            controller: "revenuesStatisticController"
        });
    }
})();