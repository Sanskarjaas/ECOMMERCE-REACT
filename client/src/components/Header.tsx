import React from 'react';
import './Header.css';

const Header: React.FC = () => {
  return (
    <header className="header-container">
      <div className="logo">SJ</div>
      <nav className="nav-links">
        <a href="#home">WOMEN</a>
        <a href="#about">MEN</a>
        <a href="#projects">KIDS</a>
        <a href="#contact">BEAUTY</a>
      </nav>
      <button className="button">Profile</button>
    </header>
  );
};

export default Header;
