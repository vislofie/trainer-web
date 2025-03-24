import './Landing.css'
import Navbar from '../../components/Navbar/Navbar'
import promo2 from '../../assets/imgs/promo-2.jpg'
import { useEffect } from 'react'
import { Link } from 'react-router-dom';

function Landing() {  
  useEffect(() => {
    document.title = "Trainer Web";
  }, []);

  return (
    <>
      <Navbar showNavigationLabels={true}/>
      
      <div className="container">
        
        <div className="promo-container">
          
          <div className="filler">
            <h1>
              The best workout tracker there is*.
            </h1>
            <p className="subTitle">
              Confidential, personal and useful.
            </p>
            <Link to="/personal">
              <button>
                Get started
              </button>
            </Link>
            <p className="asterisk-text">
              *Certified by <a href="https://vk.com/id187280105" target="_blank">Stanislav Zmeu</a>
            </p>
          </div>
          
        </div>
        

        <div className="promo-list">
          <div className="info-card">
            <h1 className="title">
              Title element
            </h1>
            <p className="subTitle">
              Subtitle element
            </p>
          </div>
          <div className="info-card">
          <h1 className="title">
              Title element
            </h1>
            <p className="subTitle">
              Subtitle element
            </p>
          </div>
          <div className="info-card">
          <h1 className="title">
              Title element
            </h1>
            <p className="subTitle">
              Subtitle element
            </p>
          </div>
        </div>

        <div className="vyebony-raz">
          <div className="image-vyebony">

          </div>
          <div className="text-vyebony">
            <div className="vyebony-card">
              <h1>Our app is so god damn cool!</h1>
              <p>Yeah basicaly because umm yeah so it's cool because umm yeah you can think for yourself you fucking cunt</p>
            </div>
            <div className="vyebony-card">
              <h1>Our app is so much better than that other app!</h1>
              <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatem, totam. Amet cupiditate quis vero esse nostrum ut pariatur reprehenderit quae!</p>
            </div>
            <div className="vyebony-card">
              <h1>Yeah it's really cool and incredible!</h1>
              <p>Shut the fuck up I know this already</p>
            </div>
          </div>
        </div>
        
        <div className="big-vyebony-card">
          <h1>Yeah, it also can do this!</h1>
        </div>

        <div className="masked-promo">
          <img src={promo2} alt="Promo 2"/>
        </div>
        
        <h1 className="promo-text">
          You gotta try it mate!
        </h1>

        <Link to="/personal">
          <button className="promo-btn">
            Get started
          </button>
        </Link>

      </div>
      <footer>
        <div className="left-links">
          <a href="">
            Privacy Policy
          </a>
          <a href="">
            Terms of Use
          </a>
        </div>

        <h2>Sasha Karpov (C) 2024. Copyright</h2>

        <div className="right-links">
          <a href="">
            Twitter
          </a>
          <a href="">
            Github
          </a>
        </div>
      </footer>
    </>
  )
}

export default Landing
