namespace TokenRewardsVer02.Controllers {

    export class ProfileController {
        public achievementList;
        public rewardList;
        public characterList;
        public character;
        public charactersAllowed = 3;

        public getAList() {

        }
        public getRList() {

        }
        /* Character Manipulation */
        public getCList() {
            let test = this.characterService.getMyCharacters();
            return test;
        }
        public addCharacter() {
            this.characterService.saveMyCharacter(this.character)
                .then(() => {
                    this.character = null; // clear the field
                    this.characterList = this.getCList();
                })
        }
        private findCharacter(id: number) {
            let temp = null;
            for (let i = 0; i < this.characterList.length; i++) {
                if (this.characterList[i].id == id) {
                    temp = this.characterList[i];
                }
            }
            return temp;
        }
        public toggleCharacterActive(id: number) {
            let temp = this.findCharacter(id);
            this.characterService.saveMyCharacter(temp);
            this.getCList();
        }
        public deleteCharacter(id: number) {
            this.characterService.deleteMyCharacter(id);
            this.getCList();
        }


        /* Utils */
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