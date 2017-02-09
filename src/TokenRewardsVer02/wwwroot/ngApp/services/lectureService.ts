namespace TokenRewardsVer02.Services {
    export class LectureService {

        public getAllLectures() {
            return this.$http.get(`/api/lectures`);
        }


        constructor(
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService
        ) {

        }
    }
    angular.module(`TokenRewardsVer02`).service('lectureService', LectureService);
}
