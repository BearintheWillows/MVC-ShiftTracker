class ShiftDataAccess {
    constructor() {
    }
    shifts = [];
    shift = null;
    initProperties() {
        this.getAllShifts().then((shifts) => {
            this.shifts = shifts;
            console.log(this.shifts);
        });
        this.getShift(-1).then((shift) => {
            this.shift = shift;
            console.log(this.shift);
        });
    }
    async getAllShifts() {
        let response = await fetch("/api/Shifts");
        let shifts = await response.json();
        return shifts;
    }
    async getShift(id) {
        let response = await fetch(`/api/Shifts/${id}`);
        let shift = await response.json();
        return shift;
    }
}
let shiftDataAccess = new ShiftDataAccess();
shiftDataAccess.initProperties();
//# sourceMappingURL=app.js.map