export default class ShiftService {
    constructor() {
    }
    baseUrl = "https://localhost:44392/api/shifts";
    getShifts() {
        return fetch(this.baseUrl)
            .then(response => response.json());
    }
}
//# sourceMappingURL=shiftService.js.map
//# sourceMappingURL=shiftService.js.map