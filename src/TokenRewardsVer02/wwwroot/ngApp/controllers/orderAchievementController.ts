namespace TokenRewardsVer02.Controllers {
    export class OrderAchievementController {
        private OrderAchievementResource;
        public achievementOrdersList;

        public getAchievementOrders() {
            
        }


        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.OrderAchievementResource = $resource('/api/orderAchievement');
        }
    }
}