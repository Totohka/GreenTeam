//import Headers from "../widgets/Header/Header"
// import { useSelector } from "react-redux";
import "./Profile.css";
import { useEffect, useState } from "react";
import axios from "axios";
import { useDispatch, useSelector } from "react-redux";
import { deleteUserInfo } from "../store/userSlice";
import { Navigate, useNavigate } from "react-router-dom";

function Profile () {
    let user = useSelector((state)=> state.user.data);
    let token = localStorage.getItem("token");     
    const navigateP = useNavigate();
    const dispatch = useDispatch();
    const [cheques, setCheques] = useState('');
  
    const DeleteUser = () => {
        dispatch(deleteUserInfo());
        navigateP("/catalog");
    }
    const WaitInfo = async() => {
        try{
            const cheq = await axios.get("http://25.32.11.98:8084/api/Cheque/all",{
            headers: {
            'Authorization': token
            },
            params: {userId: user.Id}
            })
            console.log(cheq.data);
        setCheques(cheq.data.map((ch)=>{return(
            <div  className="receipt">
                    <embed src={"http://25.32.11.98:8084/cheques/"+ch.path}></embed>
                <a
                    href={"http://25.32.11.98:8084/cheques/"+ch.path}
                    download="Example-PDF-document"
                    target="_blank"
                    rel="noreferrer"
                >
                <button className="showCheq">Показать чек</button>
                </a>
            </div>)}));
        } catch (error) {
            navigateP("/login");
        }
        
        
    }
    let content = <div>"Loading..."</div>;
    useEffect(() => {
        WaitInfo();
    },[]);
    return (
        <div className="profile-main"> 
            <div className="about-user">
                <span className="title-profile title-info">Мои данные:</span>
                <div className="info">            
                    <p className="input-info">{user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]}</p>
                    <p className="input-info">{user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"]}</p>
                    {/* <p className="input-info">{user.Phone}</p> */}
                    {/* <p className="input-info">г. Красноярск, ул. Кирова 21</p> */}
                    <p><button className="btn-exit" onClick={()=> DeleteUser()}>Выйти из аккаунта</button></p>
                </div>
            </div>

            <div className="receipts-block">
                <span className="title-profile title-receipts">Мои чеки:</span>
                <div className="receipts">
                    {cheques}
                </div>
            </div>
        </div>

    )
}

export default Profile;