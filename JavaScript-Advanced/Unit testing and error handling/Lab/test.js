let sum = require('./4.Sum of Numbers');
let isSymmetric = require('./5.Check for Symmetry');
// import { sum } from "./4.Sum of Numbers";
const { expect } = require("chai");

// describe("Test 4", () => {
//     it("1st", () => {
//         expect(sum([1, 2, 3])).to.be.equal(6);
//     })
// })


describe("Test 5", () => {
    it("1st", () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
    })
    it("2nd", () => {
        expect(Array.isArray(isSymmetric("text"))).to.be.false
    })
    it("3rd", () => {
        expect(isSymmetric([1, 2, 3, 4])).to.be.false
    })
    it("4th", () => {
        expect(isSymmetric([1, 2, '3', 4])).to.be.false
    })
    it("5th", () => {
        expect(Array.isArray(isSymmetric(45))).to.be.false
    })
    it("6th", () => {
        expect(isSymmetric([1, 2, 1])).to.be.true
    })
    it("7th", () => {
        expect(isSymmetric(["a", "b", "b", "a"])).to.be.true;
    })
    
})
