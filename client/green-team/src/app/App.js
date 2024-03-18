import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import Header from "../widgets/Header/Header";
import Vitrina from "../pages/Vitrina";
import Bin from "../pages/Bin";
<<<<<<< HEAD
=======
import Profile from "../pages/Profile";
import Registration from "../pages/Registration";
>>>>>>> 14742b750be844e924fd99fcc89b06b39d32deaf
import Login from "../pages/Login";


function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <div className="content">
        <Routes>
        <Route path="/bin" element={<Bin/>}></Route>
<<<<<<< HEAD
        <Route path="/" element={<Vitrina/>}></Route>
        <Route path="/login" element={<Login/>}></Route>
=======
        <Route path="/catalog" element={<Vitrina/>}></Route>
        <Route path="/" element={<Choice />}></Route>
        <Route path="/profile" element={<Profile />}></Route>
        <Route path="/login" element={<Login />}></Route>
        <Route path="/registration" element={<Registration />}></Route>
>>>>>>> 14742b750be844e924fd99fcc89b06b39d32deaf
      </Routes>
      </div>
      
    </BrowserRouter>
  );
}

export default App;
