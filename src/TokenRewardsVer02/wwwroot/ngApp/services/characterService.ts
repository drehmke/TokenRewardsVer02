namespace TokenRewardsVer02.Services {
    class Character {
        constructor(private name: string, private isActive: boolean, private isNpc: boolean) {
        }
    }
    class ToDelete {
        constructor(private id: number) {

        }
    }


    export class CharacterService {
        private playerGetAllMyCharactersResource;

        public getMyCharacters() {
            let temp = this.playerGetAllMyCharactersResource.getAllMyCharacters();
            return temp;
        }

        public saveMyCharacter(character, isNpc) {
            let characterToSave: Character;
            
            if (typeof character == "object") {
                characterToSave = character;
            } else if(typeof character == "string") {
                characterToSave = new Character(character, true, isNpc);
            }
            console.log(characterToSave);
            return this.$q((resolve, reject) => {
                this.$http.post(`/api/character`, characterToSave).then((result) => {
                    resolve();
                }).catch((result) => {
                    var messages = this.flattenValidation(result.data);
                    reject(messages);
                });
            });
        }

        public deleteMyCharacter(idToDelete) {
            let characterToDelete: ToDelete = new ToDelete(idToDelete);
            //this.$resource(`/api/character/SoftDelete/:id`).delete(characterToDelete);
            return this.$q((resolve, reject) => {
                this.$http.delete(`/api/character/SoftDelete/:id`, characterToDelete).then((result) => {
                    resolve();
                }).catch((result) => {
                    var messages = this.flattenValidation(result.data);
                    reject(messages);
                })
            })
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
            this.playerGetAllMyCharactersResource = $resource(`/api/character/`, null, {
                getAllMyCharacters: {
                    method: `GET`,
                    url: `/api/character/GetAllMyCharacters`,
                    isArray: true
                }
            });
        }
    }

    angular.module(`TokenRewardsVer02`).service(`characterService`, CharacterService);
}