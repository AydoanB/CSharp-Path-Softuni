function deckValidator(cards) {
    let result = [];

    for (const card of cards) {
        const cardFace = card.slice(0, -1);
        const cardSuit = card.slice(-1);
        result.push(cardValidator(cardFace, cardSuit));
    }
    function cardValidator(face, suit) {
        const faces = ['2', '3', "4", '5', "6", '7', "8", "9", "10", 'J', 'Q', 'K', "A"];
        const suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        }

        if (faces.includes(face) == false || Object.keys(suits).includes(suit) == false) {
            throw new Error("Invalid card: " + face + suit);
        }

        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit;
            }
        }

    }
    console.log(result.join(" "));
}

// console.log(cardValidator('A', 'S').toString());
// console.log(cardValidator('10', 'H'));
// console.log(cardValidator('1', 'C'));

deckValidator(['AS', '10D', 'KH', '2C']);
deckValidator(['5S', '3D', 'QD', '1C']);