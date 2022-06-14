export interface Pagination {
    currentPage: number;
    pageNumber:number
    totalPages: number;
    pageSize: number;
    totalCount: number;
    hasPrevious: boolean;
    hasNext: boolean;
}
export class PaginatedResult<T>{
    public result:T;
   public  pagination:Pagination;
}