export interface Pagination {
    CurrentPage: number;
    PageNumber:number
    TotalPages: number;
    PageSize: number;
    TotalCount: number;
    HasPrevious: boolean;
    HasNext: boolean;
}
export class PaginatedResult<T>{
    public result:T;
   public  pagination:Pagination;
}