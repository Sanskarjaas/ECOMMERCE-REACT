import React from 'react';
import { Product } from '../interfaces/Product';
import './ProductsGrid.css';

interface ProductGridProps {
  products: Product[];
}

const ProductGrid: React.FC<ProductGridProps> = ({ products }) => {
  return (
    <div className="product-grid">
      {products.map((product) => (
        <div className="product-card" key={product.id}>
          <img src={product.pictureUrl} alt={product.name} />
          <h3>{product.name}</h3>
          <p>{product.description}</p>
          <span className="price">₹{product.price}</span>
          <button>Add to Cart</button>
        </div>
      ))}
    </div>
  );
}

export default ProductGrid;
