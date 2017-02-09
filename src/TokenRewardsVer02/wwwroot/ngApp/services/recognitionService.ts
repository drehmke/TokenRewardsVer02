namespace TokenRewardsVer02.Services {
    export class RecognitionService {

        public getAllRecognitions() {
            return this.$http.get(`/api/recognitions`);
        }

        constructor(
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService
        ) {

        }
    }
    angular.module(`TokenRewardsVer02`).service(`recognitionService`, RecognitionService);
}
