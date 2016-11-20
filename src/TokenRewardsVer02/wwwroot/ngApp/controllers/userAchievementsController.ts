namespace TokenRewardsVer02.Controllers {

    export class UserClaimAchievementController {
        private UserAchievementResource;
        //private achievementId;
        
        // save it
        public claim( id: number ) {
            //let userName = this.accountService.getUserName();
            this.UserAchievementResource.save({ achievementId: id }).$promise
                .then(() => {
                    this.$state.go(`home`)
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private accountService: TokenRewardsVer02.Services.AccountService
        ) {
            this.UserAchievementResource = $resource(`/api/userachievements/`);
            //this.achievementId = $stateParams[`id`];
            this.claim($stateParams[`id`]);
        }
    }


}
