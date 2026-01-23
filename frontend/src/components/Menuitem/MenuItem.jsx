import React from 'react';

import './MenuItem.css';

const MenuItem = ({ title, price, tags, img, description}) => {
 
  return(
  <div className='app__menuitem'>
    {img && <img src={img} alt={title} className="menu-item-image" />}
    <div className='app__menuitem-head'>
      <div className='app__menuitem-name'>
        <p className='p__cormorant' style= {{color:'#DCCA87'}}>{title}</p>
        {description && (
              <p className="menu-item-description p__opensans">{description}</p>
            )}
      </div>

      <div className='app__menuitem-dash' />

      <div className='app__menuitem-price'>
        <p className='p__cormorant'>{price}</p>
      </div>
    </div>

    <div className='app__menuitem-sub'>
        <p className='p__opensans' style ={{ color: '#AAAAAA'}}>{tags}</p>
      </div>
    </div>
  );
};

export default MenuItem;

