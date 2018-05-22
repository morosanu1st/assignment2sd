import { AbstractModel } from "./abstract-model";
import { AssignmentModel } from "./assignment";
import { AttendanceModel } from "./attendance";

export interface LaboratoryModel extends AbstractModel{
        Number?: number;

        Title?: string;

        Curricula?: string;

        Description?: string;

        Date?: Date | string;

        Assignments?: AssignmentModel[];

        Attendances?: AttendanceModel[];
    }