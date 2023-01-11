"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class ShiftService {
    constructor() {
        this.baseUrl = "https://localhost:44392/api/shifts";
    }
    getShifts() {
        return fetch(this.baseUrl)
            .then(response => response.json());
    }
}
exports.default = ShiftService;
//# sourceMappingURL=shiftService.js.map