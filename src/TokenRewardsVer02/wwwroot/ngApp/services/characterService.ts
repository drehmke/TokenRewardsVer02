namespace TokenRewardsVer02.Services {
    class Character {
        constructor(private id: number, private name: string, private user, private wufooFormId: number, private active: boolean) {
        }
    }


    export class CharacterService {

        public getMyCharacters() {
            //let returnData = null;
            this.$http.get(`/api/character/GetAllMyCharacters/`)
                .then((result) => {
                    return result.data;
                })
                .catch((result) => {
                    var messages = this.flattenValidation(result.data);
                    console.error(messages);
                });
            //return returnData;
        }

        public saveMyCharacter(character) {
            let characterToSave: Character = new Character(0, character, '', 0, true);
            return this.$q((resolve, reject) => {
                this.$http.post(`/api/character`, characterToSave).then((result) => {
                    resolve();
                }).catch((result) => {
                    var messages = this.flattenValidation(result.data);
                    reject(messages);
                });
            });
        }


        private flattenValidation(modelState) {
            let messages = [];
            for (let prop in modelState) {
                messages = messages.concat(modelState[prop]);
            }
            return messages;
        }

        constructor(
            private $q: ng.IQService,
            private $http: ng.IHttpService,
            private $resource: ng.resource.IResourceService
        ) {

        }
    }

    angular.module(`TokenRewardsVer02`).service(`characterService`, CharacterService);
}