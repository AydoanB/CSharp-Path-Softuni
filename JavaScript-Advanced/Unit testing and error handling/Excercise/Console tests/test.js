const chai = require("chai");
let lookupChar = require("./3.Char Lookup");
const { expect } = require("chai");

describe("charLookup", () => {
    it("undefined 1", () => {
        expect(lookupChar(1, 2)).to.undefined;
        expect(lookupChar("asd", "2")).to.undefined;
        expect(lookupChar(["asd"], 2)).to.undefined;
        
        
        expect(lookupChar("asd", 2.12)).to.undefined;
    })
    it("Incorect index", () => {
        expect(lookupChar("asd", 3)).be.equal("Incorrect index");
        expect(lookupChar("asd", -1)).be.equal("Incorrect index");
    })
    it("return charred", () => {
        expect(lookupChar("asd", 0)).to.equal("asd".charAt(0))
        expect(lookupChar("asd", 0)).to.equal('a')
    })
})