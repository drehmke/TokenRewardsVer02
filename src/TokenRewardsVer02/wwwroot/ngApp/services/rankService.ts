namespace TokenRewardsVer02.Services {
    export class RankService {

        public getAllRanks() {
            return this.$http.get(`/api/rank`);
        }

        public saveRank(rankToSave) {
            return this.$http.post(`/api/rank`, rankToSave);
        }

        public deleteRank(id: number) {
            return this.$resource(`/api/rank/:id`).delete({ id: id });
        }

        constructor(
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService
        ) {

        }
    }
    angular.module(`TokenRewardsVer02`).service(`rankService`, RankService);
}
