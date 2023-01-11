export interface IShift {
    readonly id: number;
    date: Date;
    runId: number;
    
    run?: IRun;
    breaks?: IBreak[];
    startTime?: Date;
    endTime?: Date;
    breakDuration?: Date;
    driveTime?: Date;
    shiftDuration?: Date;
    otherWorkTime?: Date;
    workTime?: Date;
}

export interface IRun {
    readonly id: number;
    number: string;
    startTime: Date;
    routes?: IRoute[];
}

export interface IBreak { 
    readonly id: number;
    startTime: Date;
    endTime: Date;
    duration: Date;
    shiftId: number;
    shift?: IShift;
}

export interface IRoute {
    readonly id: number;
    dayOfWeek: number;
    windowOpenTime: Date;
    windowCloseTime: Date;
    runId: number;
    run?: IRun;
    
    shopId: number;
    shop?: IShop;
}

export interface IShop {
    readonly id: number;
    name: string;
    number: number;
    street: string;
    street2?: string;
    city: string;
    county: string;
    postcode: string;
    phoneNumber: number;
    routes?: IRoute[];
}