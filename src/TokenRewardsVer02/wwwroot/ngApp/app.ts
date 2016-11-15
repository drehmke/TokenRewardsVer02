namespace TokenRewardsVer02 {

    angular.module('TokenRewardsVer02', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: TokenRewardsVer02.Controllers.HomeController,
                controllerAs: 'c'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: TokenRewardsVer02.Controllers.SecretController,
                controllerAs: 'c'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: TokenRewardsVer02.Controllers.LoginController,
                controllerAs: 'c'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: TokenRewardsVer02.Controllers.RegisterController,
                controllerAs: 'c'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: TokenRewardsVer02.Controllers.ExternalRegisterController,
                controllerAs: 'c'
            })
            // ---- Achievement States ----------------------------------------
            .state(`achievements`, {
                url: `/achievements`,
                templateUrl: `/ngApp/views/achievements/list.html`,
                controller: TokenRewardsVer02.Controllers.AchievementsHomeController,
                controllerAs: `c`
            })
            .state(`achievementsAdd`, { // admin
                url: `/achievements/admin/add`,
                templateUrl: `/ngApp/views/achievements/add.html`,
                controller: TokenRewardsVer02.Controllers.AchievementsAddController,
                controllerAs: `c`
            })
            .state(`achievementsEdit`, { // admin
                url: `/achievements/admin/edit/:id`,
                templateUrl: `/ngApp/views/achievements/edit.html`,
                controller: TokenRewardsVer02.Controllers.AchievementsEditController,
                controllerAs: `c`
            })
            .state(`achievementsDelete`, { // admin
                url: `/achievements/admin/delete/:id`,
                templateUrl: `/ngApp/views/achievements/delete.html`,
                controller: TokenRewardsVer02.Controllers.AchievementsDeleteController,
                controllerAs: `c`
            })
            // ---- Reward States ---------------------------------------------
            .state(`rewards`, {
                url: `/rewards`,
                templateUrl: `/ngApp/views/rewards/list.html`,
                controller: TokenRewardsVer02.Controllers.RewardHomeController,
                controllerAs: `c`
            })
            .state(`rewardsAdd`, { // admin
                url: `/rewards/admin/add`,
                templateUrl: `/ngApp/views/rewards/add.html`,
                controller: TokenRewardsVer02.Controllers.RewardAddController,
                controllerAs: `c`
            })
            .state(`rewardsEdit`, { // admin
                url: `/rewards/admin/edit/:id`,
                templateUrl: `/ngApp/views/rewards/edit.html`,
                controller: TokenRewardsVer02.Controllers.RewardEditController,
                controllerAs: `c`
            })
            .state(`rewardsDetail`, {
                url: `/rewards/:id`,
                templateUrl: `/ngApp/views/rewards/detail.html`,
                controller: TokenRewardsVer02.Controllers.RewardDetailController,
                controllerAs: `c`
            })
            .state(`rewardsDelete`, { // admin
                url: `/rewards/admin/delete/:id`,
                templateUrl: `/ngApp/views/rewards/delete.html`,
                controller: TokenRewardsVer02.Controllers.RewardDeleteController,
                controllerAs: `c`
            })
            // ----------------------------------------------------------------
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('TokenRewardsVer02').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('TokenRewardsVer02').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
