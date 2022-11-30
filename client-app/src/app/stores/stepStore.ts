import { makeAutoObservable } from "mobx";
import { Step } from "../models/step";

export default class StepStore {
	defaultStep: Step = { active: false, completed: false, disabled: true };
	branchOfKnowledgeStep = this.defaultStep;
	specilatyStep = this.defaultStep;
	disciplineStep = this.defaultStep;

	constructor() {
		makeAutoObservable(this);
	}

	allToDefault = () => {
		this.branchOfKnowledgeStep = { active: true, completed: false, disabled: false };
		this.specilatyStep = this.defaultStep;
		this.disciplineStep = this.defaultStep;
	}

	setStepToActive = (step: Step) => {
		step = { active: true, completed: false, disabled: false  };
	}

	setStepToCompleted = (step: Step) => {
		step = { active: false, completed: true, disabled: false };
	}

	setStepToDisabled = (step: Step) => {
		step = { active: false, completed: false, disabled: true };
	}
}