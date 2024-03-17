import profile from "./images/profile.png";
import menu from "./images/menu.png";
import bin from "./images/bin.png";
import "./Header.css"
import { NavLink } from "react-router-dom";

function Header(props) {
    return (
      <header>
          <img src={menu} className='menu-button'/>
          <NavLink className='title'to="/catalog">
            <p>Store</p>
            <p className="subtitle">Special for you</p>
          </NavLink>
          <div className='buttons-rigth'>
            <NavLink to="/login"><img src={profile} className='user-button'/></NavLink>
            <NavLink to="/bin"><img src={bin} className='bin-button'/></NavLink>
          </div>
      </header>
    )
  }
export default Header;  