namespace TokenRewardsVer02.Controllers {

    export class UserClaimRewardController {
        private UserRewardResource;
        private rewardId;

        public claim() {
            let userName = this.accountService.getUserName();
            this.UserRewardResource.save({ userId: userName, rewardId: this.rewardId }).$promise
                .then(() => {
                    this.rewardId = 0;
                    this.$state.go(`home`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private accountService: TokenRewardsVer02.Services.AccountService
        ) {
            this.UserRewardResource = $resource(`/api/userrewards`);
            this.rewardId = $stateParams[`id`];
        }
    }
}