export interface ProductDTORequest {
    name: string;
    price: number;
    image: string | null;
    isActive: boolean;
}