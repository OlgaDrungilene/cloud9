import React from "react";

import { SubHeading } from "../../components";
import { images } from "../../constants";
import { scrollToTop, scrollTo } from "../../utils/scroll";
import "./Chef.css";

const Chef = () => (
  <section className="app__bg app__wrapper section__padding " id="chef" >
    <div className="app__wrapper_img app__wrapper_img-reverse">
      <img src={images.chef} alt="chef" />
    </div>

    <div className="app__wrapper_info">
      <SubHeading title="Chef's Word" />
      <h1 className="headtext__cormorant">What we believe in</h1>

      <div className="app__chef-content">
        <div className="app__chef-content_quote">
          <img src={images.quote} alt="quote" />
          <p className="p__opensans">
            As a Chef, my mission is to elevate the ordinary to the
            extraordinary, to tantalize the taste buds and ignite the senses
            with every dish.
          </p>
        </div>
        <p className="p__opensans">
          At Restaurant Cloud 9, we strive to create culinary experiences that
          linger in the memory long after the last bite, where each ingredient
          tells a story and every plate is a work of art.
        </p>
      </div>

      <div className="app__chef-sign">
        <p>Cloudy Cloudman</p>
        <p className="p__opensans">Chef & Founder</p>
        <img src={images.sign} alt='sign'/>
      </div>

    </div>
    <div className="section-nav">
      <span onClick={() => scrollToTop()}>↑ Top</span>
      <span onClick={() => scrollTo("#awards")}>Next →</span>
    </div>
  </section>
);

export default Chef;
