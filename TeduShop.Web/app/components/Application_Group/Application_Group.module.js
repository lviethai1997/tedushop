/// <reference path="../../../assets/admin/scripts/angular.js" />

(function () {
    angular.module('tedushop.Application_Group', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('Application_Group_list', {
            url: "/Application_Group_list",
            parent: 'base',
            templateUrl: "/app/components/Application_Group/Application_GroupListView.html",
            controller: "Application_GroupListController"
        }).state('Application_Group_add_view', {
            url: "/Application_Group_add_view",
            parent: 'base',
            templateUrl: "/app/components/Application_Group/Application_GroupAddView.html",
            controller: "Application_GroupAddController"
        }).state('Application_Group_edit_view', {
            url: "/Application_Group_edit_view/:id",
            parent: 'base',
            templateUrl: "/app/components/Application_Group/Application_GroupEditView.html",
            controller: "Application_GroupEditController"
        });
    }
})();