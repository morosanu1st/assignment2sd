import { AbstractModel } from "./abstract-model";
import { LaboratoryModel } from "./laboratory";
import { SubmissionModel } from "./submission";

export interface AssignmentModel extends AbstractModel{

    Laboratory: LaboratoryModel;

    Name: string;

    DueDate: Date | string;

    Description: string;

    Submissions: SubmissionModel[];
}