
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
            console.log(b);
            form.appendChild(this.createRow(b, this.breaks.indexOf(b)));
        });
        
        document.getElementById("form__btn--submit").addEventListener('click', () => {
            console.log(this.breaks);
        }   );
    }

    createTimeInput(b: IBreak,  i: number, timeType: string): HTMLInputElement {
        const input = document.createElement("input");
        input.type = "time";
        input.classList.add("form-control");
        input.id = `${timeType}-${i}`;
        
            if(timeType === "startTime") {
                input.value = b.startTime.toLocaleTimeString([], {hour: "2-digit", minute: "2-digit"});       
            } else {
                input.value = b.endTime.toLocaleTimeString([], {hour: '2-digit', minute:'2-digit'});
            }
        input.addEventListener('blur', () => {
            this.updateBreak(input.value, i, timeType);
            console.log(input.value);
        })
       
        return input;
    }
    
    private createAddBreakButton(): HTMLButtonElement {
        const button = document.createElement("button");
        button.innerText = "Add Break";
        button.classList.add("btn", "btn-primary");
        button.type = "button";
        button.addEventListener('click', () => {
            this.breaks.push({
                startTime: new Date(0,0, 0, 0,0) ,
                endTime: new Date(0,0,0,0,0), 
                duration: null});
            this.displayAllRows();
        });
        
        return button;
    }

    private createRow(b?: IBreak, i?: number): HTMLDivElement {
        const row = document.createElement("div");
        row.className = "form-group";
        row.id = `breakRow-${i}`;
        let startTime = this.createTimeInput( b  ,i, "startTime");
        let endTime = this.createTimeInput(b , i, "endTime");
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

        if(timeType === "startTime") {
            this.breaks[i].startTime = this.dateFormat(date);
        } else {
            this.breaks[i].endTime = this.dateFormat(date);
        }
        
        this.breaks[i].duration = this.calculateDuration(this.breaks[i].startTime, this.breaks[i].endTime);
        
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