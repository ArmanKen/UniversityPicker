import { makeAutoObservable, runInAction } from "mobx";
import { Review, ReviewFormValues } from "../models/review";
import { Pagination, PagingParams } from "../models/pagination";
import agent from "../api/agent";

export default class ReviewStore {
	reviews = new Map<string, Review>();
	userReview: Review | undefined = undefined;
	reviewLoadingInitial = true;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();

	constructor() {
		makeAutoObservable(this);
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setReviewsLoadingInitial = (state: boolean) => this.reviewLoadingInitial = state;

	setUserReview = (review: Review) => this.userReview = review;

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		return params;
	}

	loadReviews = async (higherEducationFacilityId: string) => {
		this.setReviewsLoadingInitial(true);
		try {
			const result = await agent.Reviews.list(this.axiosParams, higherEducationFacilityId);
			runInAction(() => {
				result.data.forEach(review => {
					this.reviews.set(review.id, review);
				});
			});
			this.setPagination(result.pagination);
			this.setReviewsLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setReviewsLoadingInitial(false);
		}
	}

	loadUserReview = async (username: string) => {
		this.setReviewsLoadingInitial(true);
		try {
			var userReview = await agent.Reviews.userReview(username);
			this.setUserReview(userReview);
			this.setReviewsLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setReviewsLoadingInitial(false);
		}
	}

	createReview = async (higherEducationFacilityId: string, review: ReviewFormValues) => {
		this.setReviewsLoadingInitial(true);
		try {
			await agent.Reviews.create(higherEducationFacilityId, review);
			this.setReviewsLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setReviewsLoadingInitial(false);
		}
	}

	editReview = async (higherEducationFacilityId: string, review: ReviewFormValues, reviewId: string) => {
		this.setReviewsLoadingInitial(true);
		try {
			await agent.Reviews.edit(higherEducationFacilityId, review, reviewId);
			this.setReviewsLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setReviewsLoadingInitial(false);
		}
	}

	deleteReview = async (higherEducationFacilityId: string, reviewId: string) => {
		this.setReviewsLoadingInitial(true);
		try {
			await agent.Reviews.delete(higherEducationFacilityId, reviewId);
			this.reviews.delete(reviewId);
			this.setReviewsLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setReviewsLoadingInitial(false);
		}
	}
}
