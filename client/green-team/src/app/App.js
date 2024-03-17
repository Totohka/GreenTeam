import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import Choice from "../pages/Choice";
import Header from "../widgets/Header/Header";
import Vitrina from "../pages/Vitrina";
import Bin from "../pages/Bin";
import Profile from "../pages/Profile";
import Registration from "../pages/Registration";
import Login from "../pages/Login";


function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <Routes>
        <Route path="/bin" element={<Bin/>}></Route>
        <Route path="/catalog" element={<Vitrina/>}></Route>
        <Route path="/" element={<Choice />}></Route>
        <Route path="/profile" element={<Profile />}></Route>
        <Route path="/login" element={<Login />}></Route>
        <Route path="/registration" element={<Registration />}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
