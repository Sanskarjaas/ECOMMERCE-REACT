import React from 'react';
import './Sidebar.css';

const Sidebar: React.FC = () => {
  return (
    <aside className="sidebar-container">
      <div className="filter-section">
        <h2 className="filter-title">Price Range</h2>
        <div className="filter-option">
          <input type="checkbox" id="low" />
          <label htmlFor="low">Under $50</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="mid" />
          <label htmlFor="mid">$50 - $150</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="high" />
          <label htmlFor="high">Above $150</label>
        </div>
      </div>

      <div className="filter-section">
        <h2 className="filter-title">Brand</h2>
        <div className="filter-option">
          <input type="checkbox" id="brand1" />
          <label htmlFor="brand1">Puma</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="brand2" />
          <label htmlFor="brand2">Nike</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="brand2" />
          <label htmlFor="brand2">Crocs</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="brand2" />
          <label htmlFor="brand2">Adidas</label>
        </div>
      </div>

      <div className="filter-section">
        <h2 className="filter-title">Categories</h2>
        <div className="filter-option">
          <input type="checkbox" id="type1" />
          <label htmlFor="type1">Shoes</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="type2" />
          <label htmlFor="type2">Accessories</label>
        </div>
      </div>
      <div className="filter-section">
        <h2 className="filter-title">Color</h2>
        <div className="filter-option">
          <input type="checkbox" id="type1" />
          <label htmlFor="type1">Blue</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="type2" />
          <label htmlFor="type2">Black</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="type2" />
          <label htmlFor="type2">White</label>
        </div>
        <div className="filter-option">
          <input type="checkbox" id="type2" />
          <label htmlFor="type2">Brown</label>
        </div> <div className="filter-option">
          <input type="checkbox" id="type2" />
          <label htmlFor="type2">Grey</label>
        </div>
      </div>
    </aside>
  );
};

export default Sidebar;
