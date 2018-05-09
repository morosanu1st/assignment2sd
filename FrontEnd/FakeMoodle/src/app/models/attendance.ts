import { LaboratoryModel } from "./laboratory";
import { UserModel } from "./user-model";
import { AbstractModel } from "./abstract-model";

export interface AttendanceModel extends AbstractModel{
        Lab: LaboratoryModel;

        Student: UserModel;
    }