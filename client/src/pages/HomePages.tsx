import React, { useState, useEffect } from 'react';
import { fetchProducts } from '../services/productService';
import ProductGrid from '../components/ProductsGrid';
import Sidebar from '../components/Sidebar';
import { Product } from '../interfaces/Product';


const HomePage: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const getProducts = async () => {
      const productsData = await fetchProducts();
      setProducts(productsData);
      setLoading(false);
    };

    getProducts();
  }, []);

  return (
    <div className="homepage">
      
      <div className="product-grid-container">
        {loading ? (
          <div>Loading...</div>
        ) : (
          <ProductGrid products={products} />
        )}
      </div>
    </div>
  );
}

export default HomePage;
