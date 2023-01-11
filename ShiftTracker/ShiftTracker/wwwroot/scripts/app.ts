const ShiftService = require('./shiftService');

let shiftService = new ShiftService();

document.querySelector( ".addButton").addEventListener("click", () => {
console.log(shiftService.getShifts())
});