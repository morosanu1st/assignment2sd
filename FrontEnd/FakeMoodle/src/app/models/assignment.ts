import { AbstractModel } from "./abstract-model";
import { LaboratoryModel } from "./laboratory";
import { SubmissionModel } from "./submission";

export interface AssignmentModel extends AbstractModel{

    LaboratoryId?: number;

    Name?: string;

    DueDate?: Date | string;

    Description?: string;

    Submissions?: SubmissionModel[];
}