import React from 'react';
import {images} from '../../constants'

import './Header.css';
import { SubHeading } from '../../components';

const Header = () => (
  <div className='app__header app__wrapper section__padding' id='home'>
    <div className='app__wrapper_info'>
      <SubHeading title='Chase the new flavour'/>
      <h1 className='app__header-h1'>The Key to Fine Dining</h1>
      <p className='p__opensans' style={{margin: '2rem 0'}}>Fine dining is about excellence in every detail, from fresh ingredients to impeccable service. With innovative cuisine, expert pairings, and a welcoming ambiance, we create memorable experiences. Consistency, dietary accommodations, and continuous improvement ensure every visit is exceptional. </p>
      <button type='button' className='custom__button'>Explore Menu</button>
    </div>

    <div className='app__wrapper_img'>
      <img src={images.c9} alt='header img'/>
    </div>
  </div>
);

export default Header;
