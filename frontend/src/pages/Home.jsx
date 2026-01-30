import { useEffect } from "react";
import {useLocation} from "react-router-dom";
import {
  AboutUs,
  Chef,
  FindUs,
  Footer,
  Gallery,
  Header,
  Intro,
  Laurels,
  SpecialMenu,
} from "../container";

const Home = () => {
  const location = useLocation();

    useEffect(() => {
        const hash = window.location.hash;
        if (location.hash) {
          const element = document.querySelector(location.hash);
          if (element) {
            setTimeout(() => {
              element.scrollIntoView({ behavior: "smooth" });
            }, 100);
            
          }
          return;
        }   
 // 2 — Kolla query (?scroll=about)
    const params = new URLSearchParams(location.search);
    const scrollTo = params.get("scroll");
    if (scrollTo) {
      const element = document.getElementById(scrollTo);
      if (element) {
        setTimeout(() => {
          element.scrollIntoView({ behavior: "smooth" });
        }, 100);
      }
      return;
    }

    // 3 — Om inget, scrolla till toppen
    window.scrollTo({ top: 0, behavior: "smooth" });
  }, [location]);
return(
  <div>
    <div id="home"><Header /></div>
    <div id="about"><AboutUs /></div>    
    <div id="menu"><SpecialMenu /></div>
    <Chef />
    <Intro />
    <div id="awards"><Laurels /></div>
    <Gallery />
    <div id="contact"><FindUs /></div>
    <div id="subscribe"><Footer /></div>
  </div>
);
};

export default Home;
