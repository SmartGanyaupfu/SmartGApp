import { Category } from "./category";
import { ContentBlock } from "./content-block";
import { Gallery } from "./gallery";
import { Image } from "./image";

export interface Portfolio {

    portfolioId: string;
    title: string;
    content: string;
    excerpt: string;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    category?: Category;
  
    image: Image;
    contentBlocks: ContentBlock[];
    dateCreated: Date;
    dateUpdated: Date;
    deleted: boolean;
    authorId: string;
    gallery:Gallery;

    sgCategoryId?: any;
    sgImageId?: number;
    sgGalleryId?: number;
    
  
}