namespace TokenRewardsVer02.Controllers {

    export class HomeController {
        private UserAchievementResource;
        private UserRewardResource;
        public achievementList;
        public rewardList;
        public characterList;

        public getAList() {
            //let userName = this.accountService.getUserName();
            return this.UserAchievementResource.getList();
        }
        public getRList() {
            //let userName = this.accountService.getUserName();
            return this.UserRewardResource.getRewards();
        }
        public getCList() {
            return this.characterService.getMyCharacters();
        }
        
        constructor(
            private $resource: angular.resource.IResourceService,
            private accountService: TokenRewardsVer02.Services.AccountService,
            private characterService: TokenRewardsVer02.Services.CharacterService
        ) {
            let check = this.accountService.getUserName();
            if (check != null)
            {
                this.UserAchievementResource = $resource(`/api/userAchievements/`, null, {
                    getList: {
                        method: 'GET',
                        url: `/api/userAchievements/GetAchievements/`,
                        isArray: true
                    }
                });
                this.UserRewardResource = $resource(`/api/userRewards/`, null, {
                    getRewards: {
                        method: 'GET',
                        url: `/api/userRewards/GetRewards/`,
                        isArray: true
                    }
                });
                this.achievementList = this.getAList();
                this.rewardList = this.getRList();
                this.characterList = this.getCList();
            }
        }
    }
    
    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
