namespace TokenRewardsVer02.Services {
    export class StoriesService {

        public getAllStories() {
            return this.$http.get(`/api/stories`);
        }

        constructor(
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService
        ) {

        }
    }
    angular.module(`TokenRewardsVer02`).service('storiesService', StoriesService);
}
