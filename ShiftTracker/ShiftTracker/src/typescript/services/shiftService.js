export default class ShiftService {
    constructor() {
    }
   static baseUrl = "https://localhost:44392/api/shifts";
   static getShifts() {
        return fetch(this.baseUrl)
            .then(response => {console.log(response.json())})
    }
}


