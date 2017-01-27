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
            .state(`/profile`, {
                url: `/profile`,
                templateUrl: '/ngApp/views/users/profile.html',
                controller: TokenRewardsVer02.Controllers.ProfileController,
                controllerAs: `c`
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
            // ---- achievement claims states ---------------------------------
            .state(`claimAchievement`, {
                url: `/achievements/claim/:id`,
                templateUrl: `/ngApp/views/userAchievements/claim.html`,
                controller: TokenRewardsVer02.Controllers.UserClaimAchievementController,
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
            // ---- reward claims states --------------------------------------
            .state(`claimReward`, {
                url: `/rewards/claim/:id`,
                templateUrl: `/ngApp/views/userRewards/claim.html`,
                controller: TokenRewardsVer02.Controllers.UserClaimRewardController,
                controllerAs: `c`
            })
            // ---- achievement category states -------------------------------
            .state(`achievementCategories`, {
                url: `/achievementCategories`,
                templateUrl: `/ngApp/views/achievementCategory/list.html`,
                controller: TokenRewardsVer02.Controllers.AchievementCategoryController,
                controllerAs: `c`
            })
            .state(`achievementCategoriesAdd`, {
                url: `/achievementCategories/admin/add`,
                templateUrl: `/ngApp/views/achievementCategory/add.html`,
                controller: TokenRewardsVer02.Controllers.AchievementCategoryAddController,
                controllerAs: `c`
            })
            .state(`achievementCategoriesEdit`, {
                url: `/achievementCategories/admin/edit/:id`,
                templateUrl: `/ngApp/views/achievementCategory/edit.html`,
                controller: TokenRewardsVer02.Controllers.AchievementCategoriesEditController,
                controllerAs: `c`
            })
            .state(`achievementCategoriesDelete`, {
                url: `/achievementCategories/admin/delete/:id`,
                templateUrl: `/ngApp/views/achievementCategory/delete.html`,
                controller: TokenRewardsVer02.Controllers.AchievementCategoriesDeleteController,
                controllerAs: `c`
            })
            // ---- admin -----------------------------------------------------
            .state(`admin`, {
                url: `/admin`,
                templateUrl: `/ngApp/views/admin/dashboard.html`,
                controller: TokenRewardsVer02.Controllers.AdminController,
                controllerAs: `c`
            })
            .state(`groupList`, {
                url: `/admin/groups`,
                templateUrl: `/ngApp/views/groups/list.html`,
                controller: TokenRewardsVer02.Controllers.GroupListController,
                controllerAs: `c`
            })
            .state(`groupTypeList`, {
                url: `/admin/group/types`,
                templateUrl: `/ngApp/views/groups/list-types.html`,
                controller: TokenRewardsVer02.Controllers.GroupTypeController,
                controllerAs: `c`
            })
            .state(`groupRankList`, {
                url: `/admin/group/ranks`,
                templateUrl: `/ngApp/views/groups/list-ranks.html`,
                controller: TokenRewardsVer02.Controllers.RankController,
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
