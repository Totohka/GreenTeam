import { React, useState } from 'react';
import { NavLink, useNavigate } from "react-router-dom";
import axios from 'axios';
import "./Registration.css";
import { jwtDecode } from 'jwt-decode';

function Login (props) {
    const [email, setEmail] = useState("");
    const [pass, setPass] = useState("");
    const navigate = useNavigate();

    const changeEmail = (e) => {
      setEmail(e.target.value);
    }

    const changePass = (e) => {
      setPass(e.target.value);
    }

    const handleSubmit = async (e) => {
      e.preventDefault();
      await axios.get('http://localhost:5152/Auth', { params: { email: email, password: pass}}).then(
        res => {
          const token = res.data
          props.setAccessTokenUser("Bearer " + token);  
          const user = jwtDecode(token);
          props.setAccoutSetting(user);
        }
      )
      navigate("/profile");
    }
    return (
        <div className="login-main main-block"> 
                <form onSubmit={handleSubmit} className="info-login info-block">            
                    <p><input className="input-login input-text" placeholder="Эл. почта:" type="email" value={email}
                    onChange={changeEmail} ></input></p>
                    <p><input className="input-login input-text" placeholder="Пароль:" type="password" value={pass}
                    onChange={changePass} ></input></p>
                    {/* <span><button className="btn-primary btn-google">Войти через Google</button></span> */}
                    <span><button className="btn-primary" type="submit">Войти</button></span>
                  <NavLink to="/registration" className="btn-second"><p><label >Зарегистрироваться</label></p></NavLink> 
                </form>
            </div>
    )
}

export default Login;