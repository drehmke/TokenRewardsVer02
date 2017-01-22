namespace TokenRewardsVer02.Controllers {

    export class ProfileController {
        public achievementList;
        public rewardList;
        public characterList;

        public getAList() {

        }
        public getRList() {

        }
        /* Character Manipulation */
        public getCList() {
            let test = this.characterService.getMyCharacters();
            return test;
        }
        public character;
        public addCharacter() {
            this.characterService.saveMyCharacter(this.character, false)
                .then(() => {
                    this.character = null; // clear the field
                    this.characterList = this.getCList();
                    //this.pcTotal = this.pcCount();
                })
        }
        public npc;
        public addNPC() {
            this.characterService.saveMyCharacter(this.npc, true)
                .then(() => {
                    this.npc = null; // clear the field
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
            this.characterService.saveMyCharacter(temp, temp.isNpc);
            this.characterList = this.getCList();
            //this.pcTotal = this.pcCount()
        }
        public deleteCharacter(id: number) {
            this.characterService.deleteMyCharacter(id);
            this.characterList = this.getCList();
            //this.pcTotal = this.pcCount()
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
            //this.pcTotal = this.pcCount();
            //console.log(this.pcTotal);
        }
    }
}