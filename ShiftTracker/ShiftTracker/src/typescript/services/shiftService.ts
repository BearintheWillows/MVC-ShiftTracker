import {breakForm} from "../components/breakForm";

let shift: IShift = {
    id: 0,
    date: new Date(),
    runId: 0,
    startTime: new Date(),
    endTime: new Date(),
    driveTime: new Date(),
    otherWorkTime: new Date(),
    workTime: new Date()
}

let newBreakForm = new breakForm()

document.addEventListener("DOMContentLoaded", () => {
    newBreakForm.displayAllRows();
    document.getElementById("form__btn--submit").addEventListener('click', () => {
        getShiftDetails();
        addShift(shift, newBreakForm.breaks);
});
    
    function getShiftDetails(){
        shift.date = new Date(Date.parse((<HTMLInputElement>document.getElementById("shiftFormDateInput")).value));
        shift.runId = parseInt((<HTMLInputElement>document.getElementById("shiftFormRunIdInput")).value);
        console.log(<HTMLInputElement>document.getElementById("StartTime")).value)
        shift.startTime = new Date(Date.parse((<HTMLInputElement>document.getElementById("StartTime")).value).toString());
        shift.driveTime = new Date(Date.parse((<HTMLInputElement>document.getElementById("DriveTime")).value));
        shift.endTime = new Date(Date.parse((<HTMLInputElement>document.getElementById("EndTime")).value));
        shift.otherWorkTime = new Date(Date.parse((<HTMLInputElement>document.getElementById("OtherWorkTime")).value));
        shift.workTime = new Date(Date.parse((<HTMLInputElement>document.getElementById("WorkTime")).value));
        console.log(shift);
    }


async function addShift(shiftObj: IShift, breakObj: IBreak[]) {
    
    let shift = {shiftObj, breakObj};
    
    const response = await fetch("https://localhost:5236/api/shifts", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(shift)
    });
    if (response.ok) {
        console.log("Entities added");
    } else {
        console.log("Entities not added");
    }
}});