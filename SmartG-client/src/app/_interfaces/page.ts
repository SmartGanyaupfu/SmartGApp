import { ContentBlock } from "./content-block";
import { Image } from "./image";

export interface Page {


        pageId: number;
        title: string;
        content: string;
        excerpt?: any;
        metaDescription: string;
        metaKeyWords: string;
        slug: string;
        image: Image;
        contentBlocks: ContentBlock[];
        dateCreated: Date;
        dateUpdated: Date;
        deleted: boolean;
        authorId?: any;
  

}
