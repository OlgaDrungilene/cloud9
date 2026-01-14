import React from 'react';
import {FiFacebook, FiTwitter, FiInstagram} from 'react-icons/fi';

import {FooterOverlay, Newsletter } from '../../components';
import './Footer.css';
import { images } from '../../constants';

const Footer = () => (
  <div className='app__footer section__padding' id='login'>
    <FooterOverlay />
    <Newsletter />

    <div className='app__footer-links'>
      <div className='app__footer-links_contact'>
        <h1 className='app__footer-headtext'>Contact us</h1>
        <p className='p__opensans'>Heavenly Street 9 Skyview Plaza Universe, Sky, Cloud 9 Code 009</p>
        <p className='p__opensans'>+46 793 393 317</p>
        <p className='p__opensans'>+9 000 000 009</p>
      </div>
      <div className='app__footer-links_logo'>
        <img src={images.cloud9} alt='footer_logo'/>
        <p className='p__opensans'>&quot;we believe that the finest flavors come from the heart.&quot;</p>
        <img src={images.spoon} alt='spoon' className='spoon__img' style={{marginTop: 15}}/>
        <div className='app__footer-links_icons'>
          <FiFacebook />
          <FiTwitter />
          <FiInstagram />
        </div>
      </div>
      <div className='app__footer-links_work'>
      <h1 className='app__footer-headtext'>Working hours</h1>
        <p className='p__opensans'>Monday-Friday:</p>
        <p className='p__opensans'>08:00 am - 12:00 am</p>
        <p className='p__opensans'>Saturday-Sunday:</p>
        <p className='p__opensans'>07:00 am - 11:00 pm</p>

      </div>
    </div>
    <div className='footer__copyright'>
      <p className='p__opensans'>2024 Cloud9. All rights reserved.</p>
    </div>
  </div>
);

export default Footer;
