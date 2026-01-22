import React, { useEffect } from "react";
import { useLocation } from "react-router-dom";
import { mains, desserts, appetizers, wines, beers, cocktails } from "../constants/data";
import MenuItem from "../components/Menuitem/MenuItem";
import "./Menu.css";

const Menu = () => {
  const { hash } = useLocation();

  useEffect(() => {
    if (hash) {
      const el = document.querySelector(hash);
      if (el) {
        setTimeout(() => {
          el.scrollIntoView({ behavior: "smooth" });
        }, 100);
      }
    } else {
      window.scrollTo({ top: 0, behavior: "smooth" });
    }
  }, [hash]);

  return (
    <div className="menu-page">
      <section className="menu-section p__cormorant">
        <h1>Menu</h1>
      </section>

      <section className="menu-section p__cormorant">
        <h2>Appetizers</h2>
        {appetizers.map((item, index) => (
          <div className="menu-item-wrapper" key={`appetizer-${index}`}>
            <MenuItem {...item} />
          </div>
        ))}
      </section>

      <section className="menu-section p__cormorant">
        <h2>Mains</h2>
        {mains.map((item, index) => (
          <div className="menu-item-wrapper" key={`main-${index}`}>
            <MenuItem {...item} />
          </div>
        ))}
      </section>

      <section className="menu-section p__cormorant">
        <h2>Desserts</h2>
        {desserts.map((item, index) => (
          <div className="menu-item-wrapper" key={`dessert-${index}`}>
            <MenuItem {...item} />
          </div>
        ))}
      </section>

      <section id="drinks" className="menu-section p__cormorant">
        <h2>Drinks</h2>

        <h3>Wine</h3>
        {wines.map((item, index) => (
          <div className="menu-item-wrapper" key={`wine-${index}`}>
            <MenuItem {...item} />
          </div>
        ))}

        <h3>Beer</h3>
        {beers.map((item, index) => (
          <div className="menu-item-wrapper" key={`beer-${index}`}>
            <MenuItem {...item} />
          </div>
        ))}

        <h3>Cocktails</h3>
        {cocktails.map((item, index) => (
          <div className="menu-item-wrapper" key={`cocktail-${index}`}>
            <MenuItem {...item} />
          </div>
        ))}
      </section>
    </div>
  );
};

export default Menu;
