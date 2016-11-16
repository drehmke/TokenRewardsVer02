namespace TokenRewardsVer02.Controllers {

    export class HomeController {
        private UserAchievementResource;
        private UserRewardResource;
        public achievementList;
        public rewardList;

        public getAList() {
            let userName = this.accountService.getUserName();
            return this.UserAchievementResource.getList({ userName: userName });
        }
        public getRList() {
            let userName = this.accountService.getUserName();
            return this.UserRewardResource.getRewards({userName: userName });
        }
        
        constructor(
            private $resource: angular.resource.IResourceService,
            private accountService: TokenRewardsVer02.Services.AccountService
        ) {
            this.UserAchievementResource = $resource(`/api/userAchievements/`, null, {
                getList: {
                    method: 'GET',
                    url: `/api/userAchievements/GetAchievements/:userName`,
                    isArray: true
                }
            });
            this.UserRewardResource = $resource(`/api/userRewards/`, null, {
                getRewards: {
                    method: 'GET',
                    url: `/api/userRewards/GetRewards/:userName`,
                    isArray: true
                }
            });
            this.achievementList = this.getAList();
            this.rewardList = this.getRList();
            console.log(this.achievementList);
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
