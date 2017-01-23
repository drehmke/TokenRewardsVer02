namespace TokenRewardsVer02.Services {
    class GroupTypeToDelete {
        constructor(public id: number){}
    }

    export class GroupTypeService {

        public getAllGroupTypes() {
            let test = this.$http.get(`/api/groupType`);
            return test;
        }

        public saveGroupType(groupType) {
            return this.$http.post(`/api/groupType`, groupType);
        }

        public deleteGroupType(typeId: number) {
            let groupTypeToDelete: GroupTypeToDelete = new GroupTypeToDelete(typeId);
            return this.$resource(`/api/groupType/:id`).delete(groupTypeToDelete);
        }

        constructor(
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService
        ) {

        }
    }
    angular.module(`TokenRewardsVer02`).service(`groupTypeService`, GroupTypeService)
}
