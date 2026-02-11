import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import MenuItem from "../components/Menuitem/MenuItem";
import "./Menu.css";

const BASE_URL =
  import.meta.env.VITE_API_URL || "https://cloud9-3.onrender.com";

const Menu = () => {
  const { hash } = useLocation();
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    if (!loading && hash) {
      const el = document.querySelector(hash);
      if (el) {
        setTimeout(() => {
          el.scrollIntoView({ behavior: "smooth" });
        }, 100);
      }
    } else {
      window.scrollTo({ top: 0, behavior: "smooth" });
    }
  }, [hash, loading]);

  useEffect(() => {
    fetch(`${BASE_URL}/menu-items`)
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch menu items");
        return res.json();
      })
      .then((data) => {
        setItems(data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err.message);
        setLoading(false);
      });
  }, []);

  if (loading) return <p style={{ color: "#fff" }}>Loading menu...</p>;
  if (error) return <p style={{ color: "red" }}>Error: {error}</p>;

  const appetizers = items.filter(i => i.category?.name === "Appetizers");
  const mains = items.filter(i => i.category?.name === "Mains");
  const desserts = items.filter(i => i.category?.name === "Desserts");

  const wines = items.filter(i => i.category?.name === "Wine");
  const beers = items.filter(i => i.category?.name === "Beer");
  const cocktails = items.filter(i => i.category?.name === "Cocktails");
  
  return (
    <div className="menu-page">
      <section className="menu-section p__cormorant">
        <h1>Menu</h1>
      </section>

      <section className="menu-section p__cormorant">
        <h2>Appetizers</h2>
        {appetizers.map((item, index) => (
          <div className="menu-item-wrapper" key={`app-${index}`}>
            <MenuItem item={item} />
          </div>
        ))}
      </section>

      <section className="menu-section p__cormorant">
        <h2>Mains</h2>
        {mains.map((item, index) => (
          <div className="menu-item-wrapper" key={`main-${index}`}>
            <MenuItem item={item} />
          </div>
        ))}
      </section>

      <section className="menu-section p__cormorant">
        <h2>Desserts</h2>
        {desserts.map((item, index) => (
          <div className="menu-item-wrapper" key={`dess-${index}`}>
            <MenuItem item={item} />
          </div>
        ))}
      </section>

      <section id="drinks" className="menu-section p__cormorant">
        <h2>Drinks</h2>

        <h3>Wine</h3>
        {wines.map((item, index) => (
          <div className="menu-item-wrapper" key={`wine-${index}`}>
            <MenuItem item={item} />
          </div>
        ))}

        <h3>Beer</h3>
        {beers.map((item, index) => (
          <div className="menu-item-wrapper" key={`beer-${index}`}>
            <MenuItem item={item} />
          </div>
        ))}

        <h3>Cocktails</h3>
        {cocktails.map((item, index) => (
          <div className="menu-item-wrapper" key={`cocktail-${index}`}>
            <MenuItem item={item} />
          </div>
        ))}
      </section>
    </div>
  );
};

export default Menu;
