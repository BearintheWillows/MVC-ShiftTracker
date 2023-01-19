export class breakForm {

    breaks: IBreak[] = [];

    constructor() {
    }


    displayAllRows() {
        const form = document.getElementById("breakForm");
        form.innerHTML = "";
        form.append(this.createAddBreakButton())
        console.log(this.breaks);

        this.breaks.forEach((b) => {
            form.appendChild(this.createRow(b, this.breaks.indexOf(b)));
        });
    }

    createTimeInput(i: number, timeType: string): HTMLInputElement {
        const input = document.createElement("input");
        input.type = "time";
        input.id = `${timeType}-${i}`;
        input.addEventListener('change', () => {
            this.updateBreak(input.value, i, timeType);
        })
        return input;
    }
    
    private createAddBreakButton(): HTMLButtonElement {
        const button = document.createElement("button");
        button.innerText = "Add Break";
        button.classList.add("addBreakButton");
        button.type = "button";
        button.addEventListener('click', () => {
            this.breaks.push({startTime: null, endTime: null, duration: null});
            this.displayAllRows();
        });
        
        return button;
    }

    private createRow(b?: IBreak, i?: number): HTMLDivElement {
        const row = document.createElement("div");
        row.className = "breakRow";
        row.id = `breakRow-${i}`;
        let startTime = this.createTimeInput(i, "startTime");
        let endTime = this.createTimeInput(i, "endTime");
        let removeButton = this.CreateRemoveButton(i);
        row.append(startTime, endTime, removeButton);
        return row;
    }
    
    private CreateRemoveButton(i: number): HTMLButtonElement {
        const button = document.createElement("button");
        button.innerText = "Remove";
        button.classList.add("removeBreakButton");
        button.type = "button";
        button.addEventListener('click', () => {
            this.breaks.splice(i, 1);
            this.displayAllRows();
        });

        return button;
    }
        


    private formatTime(value: string) {
        return new Date(value);
    }

    private updateBreak(date: string, i: number, timeType: string) {
        
        if (timeType === "startTime") {
            this.breaks[i].startTime = this.dateFormat(date);
        } else {
            this.breaks[i].endTime = this.dateFormat(date);
        }
        
        if(this.breaks[i].startTime != null && this.breaks[i].endTime != null) {
            this.breaks[i].duration = this.calculateDuration(this.breaks[i].startTime, this.breaks[i].endTime);
            document.querySelector(`#breakRow-${i}`).removeChild(document.querySelector("button"));
            this.displayAllRows();
        }
        console.log(this.breaks);
    }

    private calculateDuration(startTime: Date, endTime: Date) {
        let duration = (endTime.getTime() - startTime.getTime()) / (1000 * 60);
        let hours = Math.floor(duration / 60);
        let minutes = duration % 60;
        return new Date(0, 0, 0, hours, minutes, 0, 0);
    }

    private dateFormat(date: string) {
        let timeArray = date.split(":");
        return new Date(0, 0, 0, parseInt(timeArray[0]), parseInt(timeArray[1]), 0, 0);
    }
}