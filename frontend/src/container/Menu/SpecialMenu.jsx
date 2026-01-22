import React from 'react';

import {SubHeading, MenuItem } from '../../components';
import { images } from '../../constants';
import * as data from'../../constants';
import { scrollToTop, scrollTo } from '../../utils/scroll';
import { useNavigate } from 'react-router-dom';
import './SpecialMenu.css';

const SpecialMenu = () => {
  const navigate = useNavigate();

return(
  <section className='app__specialMenu flex__center section__padding section-full' id='menu'>
    <div className='app__specialMenu-title'>
      <SubHeading title='Menu that suits your palate' />
      <h1 className='headtext__cormorant'>Today's Special</h1>
    </div>

    <div className='app__specialMenu-menu'>
      <div className='app__specialMenu-menu_wine flex__center'>
        <p className='app__specialMenu-menu_heading'>Wine & Beer</p>
        <div className='app__specialMenu_menu_items'>
          {data.wines.map((wine, index) =>(
            <MenuItem key={wine.title + index} title={wine.title} price={wine.price} tags={wine.tags} />
          ))}
          {data.beers.map((beer, index) =>(
            <MenuItem key={beer.title + index} title={beer.title} price={beer.price} tags={beer.tags} />
          ))}
        </div>
      </div>

      <div className='app__specialMenu-menu_img'>
          <img src={images.margarita} alt= 'menu img'/>
      </div>

      <div className='app__specialMenu-menu_cocktails flex__center'>
        <p className='app__specialMenu-menu_heading'>Cocktails</p>
        <div className='app__specialMenu_menu_items'>
          {data.cocktails.map((cocktail, index) =>(
            <MenuItem key={cocktail.title + index} title={cocktail.title} price={cocktail.price} tags={cocktail.tags} />
          ))}
        </div>
      </div>

    </div>

    <div style={{marginTop: '15px'}}>
        <button type='button' className='custom__button' onClick={()=> navigate("/menu#drinks")}>View More</button>
    </div>
    <div className="section-nav">
      <span onClick={() => scrollToTop()}>↑ Top</span>
      <span onClick={() => scrollTo("#awards")}>Next →</span>
    </div>
  </section>
);
};

export default SpecialMenu;
