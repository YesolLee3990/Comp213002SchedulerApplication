export class Task {
    id: number;
    userInfo_Id: number;
    assignor: number;
    subject: string;
    description: string;
    priority: string;
    status: string;
    scheduleStart: Date;
    scheduleEnd: Date;
    deleteFlag: boolean;
    createDate: Date;
    updateDate: Date;
}