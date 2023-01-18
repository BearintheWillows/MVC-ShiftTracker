export default class ShiftService {
    static baseUrl = "https://localhost:44392/api/shifts";

    constructor() {
    }

    static getShifts() {
        return fetch(this.baseUrl)
            .then(response => {
                console.log(response.json())
            })
    }
}


