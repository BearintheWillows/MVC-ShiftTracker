interface IBreak {
    Id: number;
    StartTime: Date;
    EndTime: Date;
    ShiftId: number;
    Shift: IShift;
}
interface IShift {
    Id: number;
    RunId: number;
    StartTime: Date;
    EndTime: Date;
    TotalBreakLength: Date;
    TotalShiftLength: Date;
    TotalDriveLength: Date;
    TotalWorkLength: Date;
    Breaks: IBreak[];
}

class ShiftDataAccess{
    constructor() {
    }
    shifts: IShift[] = [];
    shift: IShift = null;
    
    initProperties(): void {
        this.getAllShifts().then((shifts) => {
            this.shifts = shifts;
            console.log(this.shifts);
        });
        this.getShift(-1).then((shift) => {
            this.shift = shift;
            console.log(this.shift);
        });
    }
    async getAllShifts(): Promise<IShift[]> {
        let response = await fetch("/api/Shifts");
        let shifts = await response.json();
        return shifts;
    }
    
    async getShift(id: number): Promise<IShift> {
        let response = await fetch(`/api/Shifts/${id}`);
        let shift = await response.json();
        return shift;
    }
}

let shiftDataAccess = new ShiftDataAccess();

shiftDataAccess.initProperties();


