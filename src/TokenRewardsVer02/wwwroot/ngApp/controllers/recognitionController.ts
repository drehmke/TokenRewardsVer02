namespace TokenRewardsVer02.Controllers {
    export class RecognitionController {
        public recognitionsList;

        public getAllRecognitions() {
            this.recognitionService.getAllRecognitions()
                .then((result) => {
                    this.recognitionsList = result.data;
                });
        }

        constructor(
            private recognitionService: TokenRewardsVer02.Services.RecognitionService
        ) {
            this.getAllRecognitions();
        }
    }
    angular.module(`TokenRewardsVer02`).controller(`recognitionController`, RecognitionController);
}
