import { ContentBlock } from "./content-block";
import { Gallery } from "./gallery";
import { Image } from "./image";

export interface Service {


    offeredServiceId: string;
    title: string;
    content: string;
    excerpt: string;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    image: Image;
    imageId: number;
    contentBlocks: ContentBlock[];
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId: string;
    galleryId:number;
    gallery:Gallery;
}
