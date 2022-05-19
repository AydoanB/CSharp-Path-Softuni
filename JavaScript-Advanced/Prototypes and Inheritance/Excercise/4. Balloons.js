function solution() {
    class Balloon {
        constructor(color, hasWeight) {
            this.color = color;
            this.hasWeight = hasWeight;
        }
    }
    class PartyBalloon extends Balloon {
        constructor(color, hasWeight, ribbonColor, ribboncLength) {
            super(color, hasWeight);
            this._ribbon = {
                color: ribbonColor,
                length: ribboncLength,
            };
        };
        get ribbon() {
            return this._ribbon;
        }
    }
    class BirthdayBalloon extends PartyBalloon {
        constructor(color, hasWeight, ribboncColor, ribboncLength, text) {
            super(color, hasWeight, ribboncColor, ribboncLength);
            this._text = text;
        };
        get text() { return this._text; }


    }

    return {
        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon,
    }
}
let classes = solution();
let testBalloon = new classes.Balloon("yellow", 20.5);
let testPartyBalloon = new classes.PartyBalloon("yellow", 20.5, "red", 10.25);
let ribbon = testPartyBalloon.ribbon;
console.log(testBalloon);
console.log(testPartyBalloon);
console.log(ribbon);

