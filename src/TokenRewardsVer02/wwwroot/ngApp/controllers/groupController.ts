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
                    this.newGroup = null;
                });
        }
        public deleteGroup(id: number) {
            this.groupService.deleteGroup(id).$promise
                .then(() => {
                    this.getAllGroups();
                });
        }

        public findGroupById(id: number) {
            let returnableGroup;
            for (let i = 0; i < this.groupsList.length; i++) {
                if (this.groupsList[i].id == id) {
                    returnableGroup = this.groupsList[i];
                }
            }
            return returnableGroup;
        }
        public updateGroup( id: number ) {
            let groupToUpdate = this.findGroupById(id);
            this.groupService.saveGroup(groupToUpdate)
                .then(() => {
                    this.$state.go(`groupList`);
                });
        }

        constructor(
            private groupService: TokenRewardsVer02.Services.GroupService,
            private $state: ng.ui.IStateService
        ) {
            this.getTypes();
            this.getAllGroups();
        }

    }
    angular.module(`TokenRewardsVer02`).controller(`groupListController`, GroupListController);
}