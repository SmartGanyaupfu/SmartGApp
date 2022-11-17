import { ContentBlockForCreationDto } from "./content-block-for-creation-dto";
import { Image } from "./image";

export interface ServiceForCreationDto {

    title: string;
    content: string;
    excerpt: string;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    contentBlocks: ContentBlockForCreationDto[];

    
   

        sgImageId?: number;
        sgGalleryId?: number;
}
