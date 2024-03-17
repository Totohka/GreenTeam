import { NavLink } from "react-router-dom";

function Registration () {
    return (
        <div className="registration-main main-block"> 
                <div className="info-registration info-block">            
                    <p><input className="input-registration input-text" placeholder="ФИО:" type="text"></input></p>
                    <p><input className="input-registration input-text" placeholder="Эл. почта:" type="email"></input></p>
                    <p><input className="input-registration input-text" placeholder="Пароль:" type="password"></input></p>
                    <p><input className="input-registration input-text" placeholder="Телефон:" type="tel"></input></p>
                    <p><button className="btn-primary">Зарегистрироваться</button></p>
                    <NavLink to="/login" className="btn-second"><p><label>Авторизоваться</label></p></NavLink>
                </div>
            </div>

    )
}

export default Registration;