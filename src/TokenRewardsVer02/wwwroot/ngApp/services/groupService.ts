namespace TokenRewardsVer02.Services {
    
    export class GroupService {

        public getTypesForPulldown() {
            return this.groupTypeService.getAllGroupTypes();
        }
        public getAllGroups() {
            return this.$http.get(`/api/group`);
        }

        public saveGroup(groupToSave) {
            return this.$http.post(`/api/group`, groupToSave);
        }

        public deleteGroup(groupId: number) {
            return this.$resource(`/api/group/:id`).delete({ id: groupId });
        }
        constructor(
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService,
            private groupTypeService: TokenRewardsVer02.Services.GroupTypeService
        ) {

        }
    }
    angular.module(`TokenRewardsVer02`).service(`groupService`, GroupService);

}
