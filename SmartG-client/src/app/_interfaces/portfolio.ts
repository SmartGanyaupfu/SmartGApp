import { Category } from "./category";
import { ContentBlock } from "./content-block";
import { Image } from "./image";

export interface Portfolio {

    portfolioId: string;
    title: string;
    content: string;
    excerpt: string;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    category: Category;
    imageId: number;
    image: Image;
    contentBlocks: ContentBlock[];
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId: string;
}