export interface Comment {
    commentId: number;
    content: string;
    approved: boolean;
    postId: string;
    portfolioId?: any;
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId: string;
}

