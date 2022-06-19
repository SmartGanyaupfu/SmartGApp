export interface Image {
    imageId: number;
    imageUrl: string;
    publicId: string;
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId?: any;
}
