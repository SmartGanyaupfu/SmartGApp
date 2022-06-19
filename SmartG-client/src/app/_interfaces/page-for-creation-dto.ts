import { ContentBlock } from "./content-block";
import { ContentBlockForCreationDto } from "./content-block-for-creation-dto";
import { Image } from "./image";

export interface PageForCreationDto {
    
    title: string;
    content: string;
    excerpt?: any;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    imageId: number;
    contentBlocks: ContentBlockForCreationDto[];
    
}
