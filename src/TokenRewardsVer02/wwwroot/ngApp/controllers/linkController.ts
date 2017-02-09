namespace TokenRewardsVer02.Controllers {
    export class LinkController {
        public linksList;

        public getAllLinks() {
            this.linkService.getAllLinks()
                .then((result) => {
                    this.linksList = result.data;
                });
        }

        private findLink(id: number) {
            let linkTosave;
            for (let i = 0; i < this.linksList.length; i++) {
                if (this.linksList[i].id == id) {
                    linkTosave = this.linksList[i];
                }
            }
            return linkTosave;
        }
        public updateLink(id: number) {
            let linkToSave = this.findLink(id);
            this.linkService.saveLink(linkToSave)
                .then((result) => {
                    this.linksList = this.getAllLinks();
                });
        }
        public deleteLink(id: number) {
            this.linkService.deleteLink(id).$promise
                .then(() => {
                    this.linksList = this.getAllLinks();
                });
        }

        constructor(
            private linkService: TokenRewardsVer02.Services.LinkService
        ) {
            this.getAllLinks();
        }
    }
    angular.module(`TokenRewardsVer02`).controller(`linkController`, LinkController);
}
