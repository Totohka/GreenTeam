//import Headers from "../widgets/Header/Header"


function Profile () {
    return (
        <div className="profile-main"> 
            <div className="about-user">
                <span className="title-profile title-info">Мои данные:</span>
                <div className="info">            
                    <p><input className="input-info" value="Фамилия Имя отчество" type="text"></input></p>
                    <p><input className="input-info" value="example@mail.ru"></input></p>
                    <p><input className="input-info" value="8-999-111-11-22"></input></p>
                    <p><input className="input-info" value="г. Красноярск, ул. Кирова 21"></input></p>
                    <p><button className="btn-exit">Выйти из аккаунта</button></p>
                </div>
            </div>

            <div className="receipts-block">
                <span className="title-profile title-receipts">Мои чеки:</span>
                <div className="receipts">
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                    <div className="receipt"></div>
                </div>
            </div>
        </div>

    )
}

export default Profile;