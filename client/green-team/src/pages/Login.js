import { React, useState } from 'react';
import { NavLink, useNavigate } from "react-router-dom";
import axios from 'axios';
import "./Registration.css";
import { jwtDecode } from 'jwt-decode';
import { useDispatch } from 'react-redux';
import { getUser, setAccessTokenUser, setAccoutSetting } from '../store/userSlice';

function Login (props) {
    const [email, setEmail] = useState("");
    const [pass, setPass] = useState("");
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const changeEmail = (e) => {
      setEmail(e.target.value);
    }

    const changePass = (e) => {
      setPass(e.target.value);
    }

    const handleSubmit = async (e) => {
      e.preventDefault();
      let inf = {params:{ email: email, password: pass}};
      try {
        const result = await axios.get("http://25.32.11.98:8082/Auth", inf);
        const token=result.data;
        //console.log(token);
        //console.log(result);
        dispatch(setAccessTokenUser("Bearer " + token));  
        const user = jwtDecode(token);
        //console.log("Инфа о пользователе ", user);
        dispatch(setAccoutSetting(user));
        navigate("/profile");
      } catch(error){
        console.log(error);
        alert("Неверный логин или пароль!");
      }
    }
    return (
        <div className="login-main main-block"> 
                <form onSubmit={handleSubmit} className="info-login info-block">            
                    <p><input className="input-login input-text" placeholder="Эл. почта:" type="email" value={email}
                    onChange={changeEmail} required></input></p>
                    <p><input className="input-login input-text" placeholder="Пароль:" type="password" value={pass}
                    onChange={changePass} required></input></p>
                    {/* <span><button className="btn-primary btn-google">Войти через Google</button></span> */}
                    <span><button className="btn-primary" type="submit">Войти</button></span>
                  <NavLink to="/registration" className="btn-second"><p><label >Зарегистрироваться</label></p></NavLink> 
                </form>
            </div>
    )
}

export default Login;