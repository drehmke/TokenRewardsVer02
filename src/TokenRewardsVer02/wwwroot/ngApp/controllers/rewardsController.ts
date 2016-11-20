namespace TokenRewardsVer02.Controllers {

    export class RewardHomeController {
        private RewardResource;
        public rewards;

        public getRewards() {
            this.rewards = this.RewardResource.query();
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.RewardResource = $resource(`/api/rewards`);
            this.getRewards();
        }
    }

    export class RewardAddController {
        private RewardResource;
        public reward;
        
        public save() {
            this.RewardResource.save(this.reward).$promise
                .then(() => {
                    this.reward = null;
                    this.$state.go(`rewards`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private accountService: TokenRewardsVer02.Services.AccountService,
            private $state: ng.ui.IStateService
        ) {
            this.RewardResource = $resource(`/api/rewards/`);
        }
    }

    export class RewardEditController {
        private RewardResource;
        public reward;

        public getRewardById(id: number) {
            this.reward = this.RewardResource.get({ id: id });
        }

        public save() {
            this.RewardResource.save(this.reward).$promise
                .then(() => {
                    this.reward = null;
                    this.$state.go(`rewards`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.RewardResource = $resource(`/api/rewards/:id`);
            this.getRewardById($stateParams[`id`]);
        }
    }

    export class RewardDetailController {
        private RewardResource;
        public reward;

        public getRewardById(id: number) {
            this.reward = this.RewardResource.get({ id: id });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.RewardResource = $resource(`/api/rewards/:id`);
            this.getRewardById($stateParams[`id`]);
        }
    }

    export class RewardDeleteController {
        private RewardResource;
        public reward;

        public getRewardById(id: number) {
            this.reward = this.RewardResource.get({ id: id });
        }

        public delete() {
            this.RewardResource.delete({ id: this.reward.id }).$promise
                .then(() => {
                    this.reward = null;
                    this.$state.go(`rewards`)
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.RewardResource = $resource(`/api/rewards/:id`);
            this.getRewardById($stateParams[`id`]);
        }
    }
}
