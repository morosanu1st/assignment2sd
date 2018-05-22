import { AssignmentModel } from "./assignment";
import { UserModel } from "./user-model";
import { AbstractModel } from "./abstract-model";

export interface SubmissionModel extends AbstractModel{       
    Student?: UserModel;
    
    Assignment?: AssignmentModel;

    Remarks?: string;

    Link?: string;

    Grade?: number;

    Attempt?: number;
}