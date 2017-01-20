namespace TokenRewardsVer02.Controllers {

    export class ProfileController {
        public achievementList;
        public rewardList;
        public characterList;
        public character;

        public getAList() {

        }
        public getRList() {

        }
        public getCList() {
            let test = this.characterService.getMyCharacters();
            return test;
        }

        public addCharacter() {
            this.characterService.saveMyCharacter(this.character);
            this.character = null; // clear the field
            this.characterList = this.getCList();
        }

        private flattenValidation(modelState) {
            let messages = [];
            for (let prop in modelState) {
                messages = messages.concat(modelState[prop]);
            }
            return messages;
        }

        constructor(
            private characterService: TokenRewardsVer02.Services.CharacterService
        ) {
            this.characterList = this.getCList();
        }
    }
}