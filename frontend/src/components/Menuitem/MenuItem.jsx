import React from "react";

import "./MenuItem.css";

const MenuItem = ({ item }) => {
  if (!item) return null;
  const baseUrl = "https://cloud9-3.onrender.com";

  return (
    <div className="app__menuitem">
      {item.imageUrl && (
        <img
          src={`${baseUrl}${item.imageUrl}`}
          alt={item.name}
          className="menu-item-image"
        />
      )}
      <div className="app__menuitem-head">
        <div className="app__menuitem-name">
          <p className="p__cormorant" style={{ color: "#DCCA87" }}>
            {item.name}
          </p>
          {item.description && (
            <p className="menu-item-description p__opensans">
              {item.description}
            </p>
          )}
        </div>

        <div className="app__menuitem-dash" />

        <div className="app__menuitem-price">
          <p className="p__cormorant">€{item.price}</p>
        </div>
      </div>

      <div className="app__menuitem-sub">
        <p className="p__opensans" style={{ color: "#AAAAAA" }}>
          {item.tags}
        </p>
      </div>
    </div>
  );
};

export default MenuItem;
