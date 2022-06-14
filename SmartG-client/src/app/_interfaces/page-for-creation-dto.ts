import { ContentBlock } from "./content-block";
import { Image } from "./image";

export interface PageForCreationDto {
    
    title: string;
    content: string;
    excerpt?: any;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    image: Image;
    contentBlocks: ContentBlock[];
    authorId?: any;
}
