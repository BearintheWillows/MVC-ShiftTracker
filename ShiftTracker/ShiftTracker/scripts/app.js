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
    async addShift(shift) {
        let response = await fetch("/api/Shifts/Create", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(shift)
        });
        let DeSerializedResponse = await response.json();
        return DeSerializedResponse;
    }
}
let shiftDataAccess = new ShiftDataAccess();
shiftDataAccess.initProperties();
let shift = {
    Breaks: [],
    Date: new Date(),
    EndTime: new Date(2023, 0, 1, 17, 0, 0),
    RunId: 78,
    StartTime: new Date(2023, 0, 1, 8, 0, 0),
    TotalBreakLength: new Date(2023, 0, 1, 0, 30, 0),
    TotalDriveLength: new Date(2023, 0, 1, 3, 30, 0),
    TotalShiftLength: new Date(2023, 0, 1, 12, 0, 0),
    TotalWorkLength: new Date(2023, 0, 1, 8, 0, 0),
};
console.log(shift);
shiftDataAccess.addShift(shift).then((shift) => console.log(shift));
//# sourceMappingURL=app.js.map