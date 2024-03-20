import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import Header from "../widgets/Header/Header";
import Vitrina from "../pages/Vitrina";
import Bin from "../pages/Bin";
import Profile from "../pages/Profile";
import Registration from "../pages/Registration";
import Login from "../pages/Login";
import AboutUs from "../pages/AboutUs";


function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <div className="content">
        <Routes>
        <Route path="/bin" element={<Bin/>}></Route>
        <Route path="/" element={<Vitrina/>}></Route>
        <Route path="/login" element={<Login/>}></Route>
        <Route path="/catalog" element={<Vitrina/>}></Route>
        <Route path="/profile" element={<Profile />}></Route>
        <Route path="/login" element={<Login />}></Route>
        <Route path="/registration" element={<Registration />}></Route>
        <Route path="/about" element={<AboutUs />}></Route>
      </Routes>
      </div>
      
    </BrowserRouter>
  );
}

export default App;
