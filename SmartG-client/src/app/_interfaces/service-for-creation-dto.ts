import { ContentBlockForCreationDto } from "./content-block-for-creation-dto";

export interface ServiceForCreationDto {

    title: string;
    content: string;
    excerpt: string;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    categoryId: number
    imageId: number;
    contentBlocks: ContentBlockForCreationDto[];
}
