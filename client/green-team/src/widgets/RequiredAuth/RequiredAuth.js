import React from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link,
  Navigate,
  useLocation,
} from "react-router-dom";
import { setAccessTokenUser, setAccoutSetting } from "../../store/userSlice";
import { jwtDecode } from "jwt-decode";

const RequireAuth = ({ children }) => {
    let location = useLocation();
    let dispatch=useDispatch();
    if (localStorage.getItem("token") == undefined) {
      return <Navigate to="/login" state={{ from: location }} replace />;
    }
    setAccessTokenUser(localStorage.getItem("token"));
    const user = jwtDecode(localStorage.getItem("token"));
    console.log("Инфа о пользователе ", user);
    dispatch(setAccoutSetting(user));
    return children;
  }

export default RequireAuth;