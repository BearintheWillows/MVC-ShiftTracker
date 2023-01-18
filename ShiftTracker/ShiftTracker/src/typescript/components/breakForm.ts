export class breakForm {

    breaks: IBreak[] = [];

    constructor() {
    }

    displayRow() {
        const form = document.getElementById("breakForm");
        form.innerHTML = "";
        if(this.breaks.length < 1) {
            form.append(this.createRow(undefined, undefined, "add"));
        } else {
        }
    }
    
    displayAllRows(){
        const form = document.getElementById("breakForm");
        form.innerHTML = "";
        if(this.breaks.length < 1) {
            form.append(this.createRow(undefined, undefined, "add"));
        } else {
            for(let i = 0; i < this.breaks.length; i++) {
                if(i === this.breaks.length - 1 && this.breaks.length > 1) {
                    form.append(this.createRow(this.breaks[i].startTime, this.breaks[i].endTime, "addAndRemove"));
                } else {
                    form.append(this.createRow(this.breaks[i].startTime, this.breaks[i].endTime, "remove"));
                }
            }
        }
        
    }

    createTimeInput(startOrEnd: string, time?: Date) {
        const input = document.createElement("input") as HTMLInputElement;
        const label = document.createElement("label") as HTMLLabelElement;
        const timeInputDiv = document.createElement("div") as HTMLDivElement;

        label.textContent = startOrEnd ? "Start Time: " : "End Time: ";
        label.setAttribute("for", startOrEnd ? "startTime" : "endTime");
        input.type = "Time";
        if(startOrEnd === "startTime") {
            input.id = "startTime";
        } else if(startOrEnd === "endTime") {
            input.id = "endTime";
        }
        input.id = (this.breaks.length - 1).toString();

        timeInputDiv.append(label, input);

        return timeInputDiv
    }

    createRemoveBreakButton() {
        const button = document.createElement("button") as HTMLButtonElement;
        button.textContent = "Remove";
        button.addEventListener("click", (event) => {
            event.preventDefault();
            let element = event.target as HTMLElement;
            let id = element.parentElement.id;
            this.breaks.splice(parseInt(id), 1);
            console.log (this.breaks);

        });
        return button;
    }

    createAddBreakButton() {
        const button = document.createElement("button") as HTMLButtonElement;
        button.textContent = "Add";
        button.addEventListener("click", (event) => {
            event.preventDefault();
            
            this.addBreak(new Date(), new Date());
            this.displayAllRows();
        });
        return button;
    }

    createRow(startTime?: Date, endTime?: Date, buttonType?: string) {
        const row = document.createElement("div") as HTMLDivElement;

        if(buttonType === "addAndRemove") {
            row.append(this.createTimeInput("startTime", startTime ? startTime : undefined), this.createTimeInput("endTime", endTime ? endTime : undefined), this.createRemoveBreakButton());
        } else if(buttonType === "remove") {
            row.append(this.createTimeInput("startTime", startTime ? startTime : undefined), this.createTimeInput("endTime", endTime ? endTime : undefined), this.createRemoveBreakButton(), this.createAddBreakButton());
        } else if(buttonType === "add") {
            row.append(this.createTimeInput("startTime", startTime ? startTime : undefined), this.createTimeInput("endTime", endTime ? endTime : undefined), this.createAddBreakButton());
        }
        row.classList.add("breakForm__row");
        return row;
    }

    addBreak(startTime: Date, endTime: Date) {
        const newBreak = {
            startTime: startTime,
            endTime: endTime,
            duration: this.calculateDuration(startTime, endTime)
        }
        console.log(newBreak);
        console.log (this.breaks);
        this.breaks.push(newBreak);
    }

    private calculateDuration(startTime: Date, endTime: Date) {
        const duration: Date = new Date( endTime.getTime() - startTime.getTime());
        return duration;
    }
}