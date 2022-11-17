import { ContentBlockForCreationDto } from "./content-block-for-creation-dto";

export interface PostForCreationDto {

    title: string;
    content: string;
    excerpt: string;
    metaDescription: string;
    metaKeyWords: string;
    slug: string;
    contentBlocks: ContentBlockForCreationDto[];

        sgCategoryId?: number;
        sgImageId: number;
        sgGalleryId?: any;
}
