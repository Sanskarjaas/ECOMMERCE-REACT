import React from 'react';
import { FaLinkedin, FaGithub, FaTwitter } from 'react-icons/fa';
import './Footer.css';

const Footer: React.FC = () => {
  return (
    <footer className="footer-container">
      <div className="contact-info">
        &copy; 2024 Sanskar Jaiswal | Contact: sanskar@example.com
      </div>
      <div className="social-links">
        <a href="https://www.linkedin.com/in/sanskar-jaiswal" target="_blank" rel="noopener noreferrer">
          <FaLinkedin />
        </a>
        <a href="https://github.com/sanskarjaiswal" target="_blank" rel="noopener noreferrer">
          <FaGithub />
        </a>
        <a href="https://twitter.com/sanskarjaiswal" target="_blank" rel="noopener noreferrer">
          <FaTwitter />
        </a>
      </div>
    </footer>
  );
};

export default Footer;
