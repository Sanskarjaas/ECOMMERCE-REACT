import React from 'react';
import './ProductCard.css'; // Import the CSS file

interface ProductCardProps {
  name: string;
  description: string;
  price: number;
  pictureUrl: string;
}

const ProductCard: React.FC<ProductCardProps> = ({
  name,
  description,
  price,
  pictureUrl,
}) => {
  return (
    <div className="product-card">
      <img src={pictureUrl} alt={name} />
      <div className="name">{name}</div>
      <div className="price">₹{price}</div>
      <div className="description">{description}</div>
    </div>
  );
};

export default ProductCard;
