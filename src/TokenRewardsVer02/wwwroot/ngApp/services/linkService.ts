namespace TokenRewardsVer02.Services {
    export class LinkService {

        public getAllLinks() {
            let temp = this.$http.get(`/api/links`);
            return temp;
        }

        public saveLink(linkToSave) {
            return this.$http.post(`/api/links`, linkToSave);
        }

        public deleteLink(id: number) {
            return this.$resource(`/api/links`).delete({ id: id });
        }

        constructor(
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService
        ) {

        }
    }
    angular.module(`TokenRewardsVer02`).service(`linkService`, LinkService);
}
