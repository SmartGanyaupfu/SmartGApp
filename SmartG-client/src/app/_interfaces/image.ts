export interface Image {
    imageId: number;
    imageUrl: string;
    publicId: string;
    postId?: any;
    portfolioId?: any;
    pageId?: number;
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId?: any;
}
