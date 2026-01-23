import React, {useState} from 'react';
import { GiHamburgerMenu } from 'react-icons/gi';
import { MdOutlineRestaurantMenu } from 'react-icons/md';
import { scrollToTop } from '../../utils/scroll';
import { Link, useLocation } from 'react-router-dom';
import images from '../../constants/images';
import './Navbar.css';

const Navbar = () => {
  const {pathname}=useLocation();
  const isHome = pathname === "/" ;
  const [toggleMenu, setToggleMenu] = useState(false);
  return(
  <nav className='app__navbar'>
    <div className='app__navbar-logo'>
      <img 
      src={images.cloud9} 
      alt='app__logo'
      onClick={scrollToTop }
      style={{ cursor: "pointer" }}
      />
    </div>
    <ul className='app__navbar-links'>
      {isHome ? (
      <>
        <li className='p__opensans'><a href='#home'>Home</a></li>
        <li className='p__opensans'><a href='#about'>About</a></li>
        <li className='p__opensans'><Link to='/menu'>Menu</Link></li>
        <li className='p__opensans'><a href='#awards'>Awards</a></li>
        <li className='p__opensans'><a href='#contact'>Contact</a></li>
      </>
      ) : (
        <>
        <li className='p__opensans'><Link to="/">Home</Link></li>
        <li className='p__opensans'><Link to="/#about">About</Link></li>  
        <li className='p__opensans'><Link to="/menu">Menu</Link></li>
        <li className='p__opensans'><Link to="/#awards">Awards</Link></li>
        <li className='p__opensans'><Link to="/#contact">Contact</Link></li>
        </>
      )}
    </ul>
    <div className='app__navbar-login'>
      <Link to="/login" className='p__opensans'>Log In / Register</Link>
      <div />
      <Link to="/booking" className='p__opensans'>Book Table</Link>
    </div>
    <div className='app__navbar-smallscreen'>
      <GiHamburgerMenu color='#fff' fontSize={27} onClick={()=> setToggleMenu(true)}/>
      {toggleMenu && (
      <div className='app__navbar-smallscreen_overlay flex__center slide-bottom'>
        <MdOutlineRestaurantMenu fontSize={27} className='overlay__close' onClick={()=> setToggleMenu(false)} />
        <ul className='app__navbar-smallscreen_links'>
          {isHome ? (
        <>
          <li className='p__opensans'><a href='#home'>Home</a></li>
          <li className='p__opensans'><a href='#about'>About</a></li>
          <li className='p__opensans'>
            <Link to='/menu'>Menu</Link>
            </li>
          <li className='p__opensans'><a href='#awards'>Awards</a></li>
          <li className='p__opensans'><a href='#contact'>Contact</a></li> 
        </>
          ) : (
        <>
          <li className='p__opensans'><Link to="/">Home</Link></li>     
          <li className='p__opensans'><Link to="/#about">About</Link></li>
          <li className='p__opensans'><Link to="/menu">Menu</Link></li>
          <li className='p__opensans'><Link to="/#awards">Awards</Link></li>
          <li className='p__opensans'><Link to="/#contact">Contact</Link></li> 
        </>
          )}
        </ul>
      </div>  
      )}
    </div>
  </nav>
  );
};

export default Navbar;
