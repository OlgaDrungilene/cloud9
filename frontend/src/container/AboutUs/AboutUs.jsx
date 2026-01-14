import React from "react";

import { images } from "../../constants";
import "./AboutUs.css";

const AboutUs = () => (
  <div className="app__aboutus app__bg flex__center section__padding" id="about">
    <div className="app__aboutus-overlay flex__center ">
      <img src={images.c_9} alt="c letter" />
    </div>

    <div className="app__aboutus-content flex__center">
      <div className="app__aboutus-content_about">
        <h1 className="headtext__cormorant">About us</h1>
        <img src={images.spoon} alt="about_spoon" className="spoon__img" />
        <p className="p__opensans">
          Welcome to Cloud 9, where culinary dreams take flight amidst the
          ethereal ambiance of our intimate restaurant. Located in the heart of
          Stockholm inviting you to embark on a journey of indulgence and
          delight. Whether you're seeking a romantic dinner for two, a lively
          gathering with friends, or a special occasion to remember, every visit
          promises an unforgettable dining experience. At Cloud 9, each dish is
          a masterpiece, meticulously crafted to tantalize the senses and ignite
          the imagination. Step into our world and immerse yourself in pure
          bliss as we transport you to cloud nine. Join us and discover the
          magic for yourself.
        </p>
        <button type="button" className="custom__button">
          Know More
        </button>
      </div>

      <div className="app__aboutus-content_knife flex__center">
        <img src={images.knife} alt="about_knife" className="knife__img" />
      </div>

      <div className="app__aboutus-content_history">
        <h1 className="headtext__cormorant">Our History</h1>
        <img src={images.spoon} alt="about_spoon" className="spoon__img" />
        <p className="p__opensans">
          Founded in Stockholm by Cloudy Cloudman, Cloud 9 is the culmination of
          a shared passion for exceptional cuisine and unparalleled hospitality.
          From our humble beginnings, we've strived to create a dining
          experience like no other, blending innovative cuisine with impeccable
          service and enchanting ambiance. Since opening our doors, Cloud 9 has
          become synonymous with excellence, earning acclaim for our creative
          dishes and unwavering commitment to quality. Join us on this culinary
          journey as we continue to redefine fine dining and create
          unforgettable moments for our guests.
        </p>
        <button type="button" className="custom__button">
          Know More
        </button>
      </div>
    </div>
  </div>
);

export default AboutUs;
