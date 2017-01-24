namespace TokenRewardsVer02.Controllers {

    class NewGroup {
        constructor(public id: number, public name: string) { }
    }

    export class GroupListController {
        public typesList;
        public groupsList;
        public newGroup: NewGroup;

        public getTypes() {
            this.groupService.getTypesForPulldown()
                .then((result) => {
                    this.typesList = result.data;
                });
        }
        public getAllGroups() {
            this.groupService.getAllGroups()
                .then((result) => {
                    this.groupsList = result.data;
                })
        }
        public addGroup() {
            this.groupService.saveGroup(this.newGroup)
                .then(() => {
                    this.getAllGroups();
                });
        }
        public deleteGroup(id: number) {
            this.groupService.deleteGroup(id).$promise
                .then(() => {
                    this.getAllGroups();
                });
        }

        constructor(
            private groupService: TokenRewardsVer02.Services.GroupService
        ) {
            this.getTypes();
            this.getAllGroups();
        }

    }
    angular.module(`TokenRewardsVer02`).controller(`groupListController`, GroupListController);
}