import { Product } from "../interfaces/Product";

// Replace with your actual API endpoint
const API_URL = 'https://localhost:7090/api/product'; 

export const fetchProducts = async (): Promise<Product[]> => {
  try {
    const response = await fetch(API_URL);
    const data: Product[] = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching products", error);
    return [];
  }
};
