import { NavLink, useNavigate } from "react-router-dom";
import "./Registration.css";
import { useState } from "react";
import axios from "axios";
import { jwtDecode } from "jwt-decode";
import { useDispatch, useSelector } from "react-redux";
import { regUser, setAccessTokenUser, setAccoutSetting } from "../store/userSlice";

function Registration (props) {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [pass, setPass] = useState("");
    const [phone, setPhone] = useState("");
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        let newUser={
            id: 0,
            firstName: firstName,
            lastName: lastName,
            email: email,
            password: pass,
            phone: phone
        };
        try{
          const result = await axios.post("http://25.32.11.98:8082/Auth", newUser, {
          headers: {
            'Content-Type': 'application/json'
          }
          });
          console.log(result.data);
          let token = result.data;// debugger;
          dispatch(setAccessTokenUser("Bearer " + token));  
          const user = jwtDecode(token);
          console.log("Инфа о пользователе ", user);
          dispatch(setAccoutSetting(user));
          navigate("/profile");
        } catch (error){
          alert(error);
        }
      } ;

    const handleChangeFirstName = (e) => {
      setFirstName(e.target.value);
    }
    const handleChangeLastName = (e) => {
      setLastName(e.target.value);
    }
    const handleChangeEmail = (e) => {
      setEmail(e.target.value);
    }
    const handleChangePass = (e) => {
      setPass(e.target.value);
    }
    const handleChangePhone = (e) => {
      setPhone(e.target.value);
    }
    return (
        <div className="registration-main main-block"> 
                <form className="info-registration info-block" onSubmit={handleSubmit}>            
                    <p><input className="input-registration input-text" placeholder="Имя:" type="text" value={firstName}
                            onChange={handleChangeFirstName} required></input></p>
                    <p><input className="input-registration input-text" placeholder="Фамилия:" type="text" value={lastName}
                            onChange={handleChangeLastName} required></input></p>
                    <p><input className="input-registration input-text" placeholder="Эл. почта:" type="email" value={email}
                                onChange={handleChangeEmail} required></input></p>
                    <p><input className="input-registration input-text" placeholder="Пароль:" type="password" value={pass}
                                onChange={handleChangePass} required></input></p>
                    <p><input className="input-registration input-text" placeholder="Телефон:" type="tel" value={phone}
                                onChange={handleChangePhone} required pattern='^\+?\d{0,13}'></input></p>
                    <p><button className="btn-primary" type="submit">Зарегистрироваться</button></p>
                    <NavLink to="/login" className="btn-second"><p><label>Авторизоваться</label></p></NavLink>
                </form>
            </div>

    )
}

export default Registration;