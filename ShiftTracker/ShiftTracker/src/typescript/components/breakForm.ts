

export class breakForm {
    
    constructor() {
    }
    
    breaks: IBreak[] = [];
    
    displayRow(){
        const form = document.getElementById("breakForm");
        const row = document.createElement("div") as HTMLDivElement;
        const input = document.createElement("input") as HTMLInputElement;
        const label = document.createElement("label") as HTMLLabelElement;
        const button = document.createElement("button") as HTMLButtonElement;
        
        input.type = "Time";
        let startTimeLabel = label.cloneNode(false) as HTMLLabelElement;
        startTimeLabel.textContent = "Start Time: ";
        startTimeLabel.setAttribute("for", "startTime");
        
        let startTimeInput = input.cloneNode(false) as HTMLInputElement;
        startTimeInput.id = "startTime";
        
        let endTimeLabel = label.cloneNode(false) as HTMLLabelElement;
        endTimeLabel.textContent = "End Time: ";
        endTimeLabel.setAttribute("for", "endTime");
        
        let endTimeInput = input.cloneNode(false) as HTMLInputElement;
        endTimeInput.id = "endTime";
        
        let submitButton = button.cloneNode(false) as HTMLButtonElement;
        submitButton.textContent = "Submit";
        submitButton.addEventListener("click", (event) => {
            event.preventDefault();
            console.log("Submit button clicked");
        });
        form.append(row);
        row.append(startTimeLabel, startTimeInput, endTimeLabel, endTimeInput, submitButton);
        
        
    } 
}