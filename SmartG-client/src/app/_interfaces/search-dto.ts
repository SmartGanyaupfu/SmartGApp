import { Page } from "./page";
import { Portfolio } from "./portfolio";
import { Post } from "./post";
import { Service } from "./service";

export interface SearchDto {
    pages: Page[];
    posts: Post[];
    services: Service[];
    portfolios: Portfolio[];
}
