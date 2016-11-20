namespace TokenRewardsVer02.Controllers {
    export class AchievementCategoryController {
        public ACResource;
        public categories;

        public getAchievementCategories() {
            this.categories = this.ACResource.query();
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.ACResource = $resource(`/api/achievementCategories`);
            this.getAchievementCategories();
        }
    }

    export class AchievementCategoryAddController {
        private ACResource;
        public category;

        public save() {
            this.ACResource.save(this.category).$promise
                .then(() => {
                    this.category = null;
                    this.$state.go(`achievementCategories`);
                });
        }
        constructor(
            private $resource: angular.resource.IResourceService,
            private $state: ng.ui.IStateService
        ) {
            this.ACResource = $resource(`/api/achievementCategories`);
        }
    }

    export class AchievementCategoriesEditController {
        private ACResource;
        private category;

        public getAchievementCategoryById(id: number) {
            this.category = this.ACResource.get({ id: id });
        }

        public save() {
            this.ACResource.save(this.category).$promise
                .then(() => {
                    this.category = null;
                    this.$state.go(`achievementCategories`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.ACResource = $resource(`/api/achievementCategories/:id`);
            this.getAchievementCategoryById($stateParams[`id`]);
        }
    }

    export class AchievementCategoriesDeleteController {
        private ACResource;
        public category;

        public getAchievementCategoryById(id: number) {
            this.category = this.ACResource.get({ id: id });
        }

        public delete() {
            this.ACResource.delete({ id: this.category.id }).$promise
                .then(() => {
                    this.category = null;
                    this.$state.go(`achievementCategories`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.ACResource = $resource(`/api/achievementCategories/:id`);
            this.getAchievementCategoryById($stateParams[`id`]);
        }
    }
}