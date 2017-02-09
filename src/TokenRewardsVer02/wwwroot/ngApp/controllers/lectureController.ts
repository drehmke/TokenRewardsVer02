namespace TokenRewardsVer02.Controllers {
    export class LectureController {
        public lecturesList;

        public getAllLectures() {
            this.lectureService.getAllLectures()
                .then((result) => {
                    this.lecturesList = result.data;
                });
        }

        constructor(
            private lectureService: TokenRewardsVer02.Services.LectureService
        ) {
            this.getAllLectures();
        }
    }
    angular.module(`TokenRewardsVer02`).controller(`lectureController`, LectureController);
}
