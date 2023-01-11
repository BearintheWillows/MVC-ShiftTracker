import ShiftService from "./shiftService.js";

export namespace functions {
    let shiftService = new ShiftService();

    document.querySelector(".addButton").addEventListener("click", () => {
        console.log(shiftService.getShifts())
    });
}