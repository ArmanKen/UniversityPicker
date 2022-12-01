import { makeAutoObservable } from "mobx";
import { Step } from "../models/step";

export default class StepStore {
	branchOfKnowledgeStep = { active: false, completed: false, disabled: true };
	specilatyStep = { active: false, completed: false, disabled: true };
	disciplineStep = { active: false, completed: false, disabled: true };
	currentStep: JSX.Element | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
	}

	allStepsToDefault = () => {
		this.branchOfKnowledgeStep.active = true;
		this.branchOfKnowledgeStep.disabled = false;
		this.branchOfKnowledgeStep.completed = false;
		this.specilatyStep.active = false;
		this.specilatyStep.disabled = false;
		this.specilatyStep.completed = false;
		this.disciplineStep.active = false;
		this.disciplineStep.disabled = false;
		this.disciplineStep.completed = false;
	}

	setStepToActive = (step: Step) => {
		step.active = true;
		step.completed = false;
		step.disabled = false;
	}

	setStepToCompleted = (step: Step) => {
		step.active = false;
		step.completed = true;
		step.disabled = false;
	}

	setStepToDisabled = (step: Step) => {
		step.active = false;
		step.completed = false;
		step.disabled = true;
	}

	setCurrentStep = (step: JSX.Element) => {
		this.currentStep = step;
	}
}