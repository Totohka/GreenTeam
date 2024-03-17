function Registration () {
    return (
        <div className="registration-main main-block"> 
                <div className="info-registration info-block">            
                    <p><input className="input-registration input-text" placeholder="ФИО:" type="text"></input></p>
                    <p><input className="input-registration input-text" placeholder="Эл. почта:" type="text"></input></p>
                    <p><input className="input-registration input-text" placeholder="Пароль:" type="password"></input></p>
                    <p><input className="input-registration input-text" placeholder="Телефон:" type="text"></input></p>
                    <p><button className="btn-primary">Зарегистрироваться</button></p>
                    <p><label className="btn-second">Авторизоваться</label></p>
                </div>
            </div>

    )
}

export default Registration;