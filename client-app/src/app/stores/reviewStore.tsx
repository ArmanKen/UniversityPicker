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

	loadReviews = async (universityId: string) => {
		this.setReviewsLoadingInitial(true);
		try {
			const result = await agent.Reviews.list(this.axiosParams, universityId);
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

	createReview = async (universityId: string, review: ReviewFormValues) => {
		this.setReviewsLoadingInitial(true);
		try {
			await agent.Reviews.create(universityId, review);
			this.setReviewsLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setReviewsLoadingInitial(false);
		}
	}

	editReview = async (universityId: string, review: ReviewFormValues, reviewId: string) => {
		this.setReviewsLoadingInitial(true);
		try {
			await agent.Reviews.edit(universityId, review, reviewId);
			this.setReviewsLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setReviewsLoadingInitial(false);
		}
	}

	deleteReview = async (universityId: string, reviewId: string) => {
		this.setReviewsLoadingInitial(true);
		try {
			await agent.Reviews.delete(universityId, reviewId);
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
