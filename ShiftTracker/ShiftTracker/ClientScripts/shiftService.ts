import {IShift} from "./interfaces";

export default class ShiftService {
    
    constructor() {
    }
    
    readonly baseUrl = "https://localhost:44392/api/shifts";
    
    getShifts(): Promise<void | IShift[]> {
        return fetch(this.baseUrl)
            .then(response => response.json()
            );
    }
}



