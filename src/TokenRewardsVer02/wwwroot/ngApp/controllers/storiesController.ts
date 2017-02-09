namespace TokenRewardsVer02.Controllers {
    export class StoriesController {
        public storiesList;

        public getAllStories() {
            this.storiesService.getAllStories()
                .then((result) => {
                    this.storiesList = result.data;
                });
        }

        constructor(
            private storiesService: TokenRewardsVer02.Services.StoriesService
        ) {
            this.getAllStories();
        }
    }
    angular.module(`TokenRewardsVer02`).controller(`storiesController`, StoriesController);
}
