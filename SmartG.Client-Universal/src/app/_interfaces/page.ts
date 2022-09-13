export interface Page {
    pageId: number;
    title: string;
    content: string;
    excerpt?: any;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    imageId: number;
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId?: any;
}
