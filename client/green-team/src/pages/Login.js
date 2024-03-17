function Login () {
    return (
        <div className="login-main main-block"> 
                <div className="info-login info-block">            
                    <p><input className="input-login input-text" placeholder="Эл. почта:" type="text"></input></p>
                    <p><input className="input-login input-text" placeholder="Пароль:" type="password"></input></p>
                    <span><button className="btn-primary btn-google">Войти через Google</button></span>
                    <span><button className="btn-primary">Войти</button></span>
                    <p><label className="btn-second">Зарегистрироваться</label></p>
                </div>
            </div>

    )
}

export default Login;