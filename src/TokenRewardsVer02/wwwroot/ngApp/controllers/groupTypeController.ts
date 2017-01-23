namespace TokenRewardsVer02.Controllers {
    class GroupType {
        constructor(public id: number, public name: string, public isAdmin: boolean) {
        }
    }

    export class GroupTypeController {
        public groupTypes;
        public newType: GroupType;

        public getAllGroupTypes() {
            this.groupTypeService.getAllGroupTypes()
                .then((result) => {
                    this.groupTypes = result.data;
                });
        }

        public addType() {
            this.groupTypeService.saveGroupType(this.newType)
                .then((response) => {
                    this.newType = null;
                    this.getAllGroupTypes();
                });
        }

        private findType(id: number) {
            for (let i = 0; i < this.groupTypes.length; i++) {
                if (this.groupTypes[i].id == id) {
                    return this.groupTypes[i];
                }
            }
        }

        public updateType(id: number) {
            let typeToEdit: GroupType = this.findType(id);
            this.groupTypeService.saveGroupType(typeToEdit)
                .then(() => {
                    this.getAllGroupTypes();
                })
        }

        public deleteType(id: number) {
            this.groupTypeService.deleteGroupType(id).$promise
                .then(() => {
                    this.getAllGroupTypes();
                });
        }

        constructor(
            private groupTypeService: TokenRewardsVer02.Services.GroupTypeService
        ) {
            this.getAllGroupTypes();
        }
    }
    angular.module(`TokenRewardsVer02`).controller(`groupTypeController`, GroupTypeController);
}
