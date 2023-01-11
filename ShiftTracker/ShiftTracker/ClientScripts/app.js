"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const shiftService_js_1 = require("./shiftService.js");
let shiftService = new shiftService_js_1.default();
document.querySelector(".addButton").addEventListener("click", () => {
    console.log(shiftService.getShifts());
});
//# sourceMappingURL=app.js.map