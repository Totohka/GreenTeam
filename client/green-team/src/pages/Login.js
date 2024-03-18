import { NavLink } from "react-router-dom";

function Login () {
    return (
        <div className="login-main main-block"> 
                <div className="info-login info-block">            
                    <p><input className="input-login input-text" placeholder="Эл. почта:" type="email"></input></p>
                    <p><input className="input-login input-text" placeholder="Пароль:" type="password"></input></p>
                    <span><button className="btn-primary btn-google">Войти через Google</button></span>
                    <span><button className="btn-primary">Войти</button></span>
                  <NavLink to="/registration" className="btn-second"><p><label >Зарегистрироваться</label></p></NavLink> 
                </div>
            </div>

    )
}

export default Login;