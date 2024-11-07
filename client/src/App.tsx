import React, { useState, useEffect } from 'react';
import './App.css'; 
import Header from './components/Header';
import Footer from './components/Footer';
import HomePage from './pages/HomePages';
import Sidebar from './components/Sidebar';

const App: React.FC = () => {
  // State for products (can later be replaced with API call)
  const [products, setProducts] = useState<any[]>([]);

  useEffect(() => {
    // Sample data to simulate API fetch (replace with real API call)
    const fetchProducts = async () => {
      const res = await fetch('https://localhost:7090/api/product'); // Replace with real API URL
      const data = await res.json();
      setProducts(data);
    };

    fetchProducts();
  }, []);

  return (
    <div className="App">
      <Header/>
      <div className="main-container">
      <Sidebar />
        <HomePage/>
      </div>
     <Footer/>
    </div>
  );
}

export default App;
