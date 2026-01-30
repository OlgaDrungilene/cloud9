import React, { useEffect, useState } from "react";
import { SubHeading } from "../../components";
import MenuItemCompact from "../../components/Menuitem/MenuItemCompact";
import { images } from "../../constants";
import { scrollToTop, scrollTo } from "../../utils/scroll";
import { useNavigate } from "react-router-dom";
import "./SpecialMenu.css";

const SpecialMenu = () => {
  const navigate = useNavigate();

  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("http://localhost:5077/menu-items")
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

  const cocktails = items.filter((i) => i.category?.name === "Cocktails");

  return (
    <section
      className="app__specialMenu flex__center section__padding section-full"
      id="menu"
    >
      <div className="app__specialMenu-title">
        <SubHeading title="Menu that suits your palate" />
        <h1 className="headtext__cormorant">Today's Special</h1>
      </div>

      <div className="app__specialMenu-menu">
        <div className="app__specialMenu-menu_wine flex__center">
          <p className="app__specialMenu-menu_heading">Wine & Beer</p>
          <div className="app__specialMenu_menu_items">
            {items
              .filter(
                (i) => i.category.name === "Wine" || i.category.name === "Beer",
              )
              .map((i) => (
                <MenuItemCompact
                  key={i.id}
                  name={i.name}
                  price={i.price}
                  tags={i.tags}
                />
              ))}
          </div>
        </div>

        <div className="app__specialMenu-menu_img">
          <img src={images.margarita} alt="menu img" />
        </div>

        <div className="app__specialMenu-menu_cocktails flex__center">
          <p className="app__specialMenu-menu_heading">Cocktails</p>
          <div className="app__specialMenu_menu_items">
            {cocktails.map((item) => (
              <MenuItemCompact
                key={item.id}
                name={item.name}
                price={item.price}
                tags={item.tags}
              />
            ))}
          </div>
        </div>
      </div>

      <div style={{ marginTop: "15px" }}>
        <button
          type="button"
          className="custom__button"
          onClick={() => navigate("/menu#drinks")}
        >
          View More
        </button>
      </div>

      <div className="section-nav">
        <span onClick={() => scrollToTop()}>↑ Top</span>
        <span onClick={() => scrollTo("#awards")}>Next →</span>
      </div>
    </section>
  );
};

export default SpecialMenu;
