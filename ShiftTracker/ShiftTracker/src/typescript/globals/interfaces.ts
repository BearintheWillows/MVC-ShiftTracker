interface IShift {
    id: number;
    date: Date;
    runId: number;

    //run: IRun;
    //TODO: Add IRun

    //breaks?: IBreak[];
    //TODO: Add IBreak[]
    startTime?: Date;
    endTime?: Date;
    breakDuration?: Date;
    shiftDuration?: Date;
    otherWorkTime?: Date;
    workTime?: Date;
}

interface IBreak {
    Id?: number;
    startTime: Date;
    endTime: Date;
    duration: Date;
}
