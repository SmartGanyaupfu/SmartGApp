export interface Image {
    imageId: number;
    imageUrl: string;
    caption:string;
    altText:string;
    publicId: string;
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId?: any;
}
