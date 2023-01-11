import ShiftService from "./shiftService.js";
export var functions;
(function (functions) {
    let shiftService = new ShiftService();
    document.querySelector(".addButton").addEventListener("click", () => {
        console.log(shiftService.getShifts());
    });
})(functions || (functions = {}));
//# sourceMappingURL=functions.js.map