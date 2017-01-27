namespace TokenRewardsVer02.Controllers {

    class BelongsTo {
        constructor(public id: number){}
    }
    class newRank {
        constructor(public belongsTo: BelongsTo, public name: string, public level: number) {

        }
    }

    export class RankController {
        public ranksList;
        public groupsList;
        public newRank: newRank;

        public getAllRanks() {
            this.rankService.getAllRanks()
                .then((result) => {
                    this.ranksList = result.data;
                });
        }

        public getAllGroups() {
            this.groupService.getAllGroups()
                .then((result) => {
                    this.groupsList = result.data;
                });
        }

        public addRank() {
            this.rankService.saveRank(this.newRank)
                .then((result) => {
                    this.newRank = null;
                    this.ranksList = this.getAllRanks();
                });
        }

        private findRank(id: number) {
            for (let i = 0; i < this.ranksList.length; i++) {
                if (this.ranksList[i].id == id) {
                    return this.ranksList[i];
                }
            }
        }

        public updateRank(id: number) {
            let rankToSave = this.findRank(id);
            this.rankService.saveRank(rankToSave)
                .then((result) => {
                    this.getAllRanks();
                });
        }

        public deleteRank(id: number) {
            this.rankService.deleteRank(id).$promise
                .then((result) => {
                    this.getAllRanks();
                })
        }

        constructor(
            private rankService: TokenRewardsVer02.Services.RankService,
            private groupService: TokenRewardsVer02.Services.GroupService
        ) {
            this.getAllRanks();
            this.getAllGroups();
        }
    }
    angular.module(`TokenRewardsVer02`).controller('rankController', RankController);
}