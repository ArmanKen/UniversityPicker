import { makeAutoObservable } from "mobx";

export default class StepStore {
	branchOfKnowledgeStep = { active: true, completed: false, disabled: false };
	specilatyStep = { active: false, completed: false, disabled: true };
	disciplineStep = { active: false, completed: false, disabled: true };
	currentStep: JSX.Element | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
	}

	setCurrentStep = (step: JSX.Element) => {
		switch (step.key?.toString()) {
			case '1':
				this.branchOfKnowledgeStep = { active: true, completed: false, disabled: false };
				this.specilatyStep = { active: false, completed: false, disabled: true };
				this.disciplineStep = { active: false, completed: false, disabled: true };
				break;
			case '2':
				this.branchOfKnowledgeStep = { active: false, completed: true, disabled: false };
				this.specilatyStep = { active: true, completed: false, disabled: false };
				this.disciplineStep = { active: false, completed: false, disabled: true };
				break;
			case '3':
				this.branchOfKnowledgeStep = { active: false, completed: true, disabled: false };
				this.specilatyStep = { active: false, completed: true, disabled: false };
				this.disciplineStep = { active: true, completed: false, disabled: false };
				break;
			case '4':
				break;
		}
		this.currentStep = step;
	}
}