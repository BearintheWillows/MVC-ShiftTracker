
export class BreakService {
     constructor() {
     }
     
     BaseUrl = "https://localhost:5236/api/breaks";
     
     async PostBreaks(breaks: IBreak[]) {
         const response = await fetch(this.BaseUrl, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(breaks)
            });
         
            if(response.ok) {
                console.log("Success");
            }
     }
}