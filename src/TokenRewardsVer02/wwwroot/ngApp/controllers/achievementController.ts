namespace TokenRewardsVer02.Controllers {

    export class AchievementsHomeController {
        private AchievementResource;
        public achievements;
        private ACResource;
        public categories;

        public getAchievements() {
            this.achievements = this.AchievementResource.query();
        }

        public getCategories() {
            this.categories = this.ACResource.query();
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.AchievementResource = $resource(`/api/achievements`);
            this.getAchievements();
            this.ACResource = $resource(`api/achievementCategories`);
            this.getCategories();
        }
    }

    export class AchievementsAddController {
        private AchievementResource;
        public achievement;

        private ACResource;
        public categories;
        public getCategories() {
            this.categories = this.ACResource.query();
        }

        public saveNew() {
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
            this.ACResource = $resource(`api/achievementCategories`);
            this.getCategories();
        }
        
    }

    export class AchievementsEditController {
        private AchievementResource;
        public achievement;

        private ACResource;
        public categories;
        public getCategories() {
            this.categories = this.ACResource.query();
        }

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
            this.ACResource = $resource(`api/achievementCategories`);
            this.getCategories();
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
