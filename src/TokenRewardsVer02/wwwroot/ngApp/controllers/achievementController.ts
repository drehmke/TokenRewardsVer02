namespace TokenRewardsVer02.Controllers {

    export class AchievementsHomeController {
        private AchievementResource;
        public achievements;

        public getAchievements() {
            this.achievements = this.AchievementResource.query();
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.AchievementResource = $resource(`/api/achievements`);
            this.getAchievements();
        }
    }

    export class AchievementsAddController {
        private AchievementResource;
        public achievement;

        public save() {
            this.AchievementResource.save(this.achievement).$promise
                .then(() => {
                    this.achievement = null;
                    this.$state.go(`achievements`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $state: ng.ui.IStateService
        ) {
            this.AchievementResource = $resource(`/api/achievements`);
        }
        
    }

    export class AchievementsEditController {
        private AchievementResource;
        public achievement;

        public getAchievementById(id: number) {
            this.achievement = this.AchievementResource.get({ id: id });
        }

        public save() {
            this.AchievementResource.save(this.achievement).$promise
                .then(() => {
                    this.achievement = null;
                    this.$state.go(`achievements`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.AchievementResource = $resource(`/api/achievements/:id`);
            this.getAchievementById($stateParams[`id`]);
        }

    }
    export class AchievementsDeleteController {
        private AchievementResource;
        public achievement;

        public getAchievementById(id: number) {
            this.achievement = this.AchievementResource.get({ id: id });
        }

        public delete() {
            this.AchievementResource.delete({ id: this.achievement.id }).$promise
                .then(() => {
                    this.achievement = null;
                    this.$state.go(`achievements`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.AchievementResource = $resource(`/api/achievements/:id`);
            this.getAchievementById($stateParams[`id`]);
        }

    }
}
