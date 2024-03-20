//import Headers from "../widgets/Header/Header"
import "./AboutUs.css";
import vk from "./images/vk.png";
import insta from "./images/insta.png";
import tg from "./images/tg.png";

function AboutUs () {
    return (
        <div className="aboutus-main"> 
            <div className="aboutus-documents block">
                <div className="aboutus-document-items">
                    <div className="aboutus-document-item">
                        Документы магазина
                    </div>
                </div>
            </div>

            <div className="aboutus-info block">
                <div className="aboutus-info-items">
                    <div className="aboutus-info-item contact">
                        <h1>Контакты</h1>
                        <p>Почта</p>
                        <p>Телефон</p>
                    </div>
                    <div className="aboutus-info-item aboutus-address">
                        <h1>Адрес</h1>
                        <p>Там-то и там-то</p>
                    </div>
                    <div className="aboutus-info-item legal-info">
                        <h1>Инфа про ИП или ООО</h1>
                    </div>
                    <div className="aboutus-info-item button">
                        <div> <img src={vk} className='info-button'/> </div>
                        <div>    <img src={insta} className='info-button'/> </div>
                         <div>   <img src={tg} className='info-button'/></div>
                        
                    </div>
                </div>
            </div>
        </div>

    )
}

export default AboutUs;