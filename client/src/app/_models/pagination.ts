export interface Paginated {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
}

export class PaginatedResult<T> {
    items?: T;
    pagination?: Paginated;
}