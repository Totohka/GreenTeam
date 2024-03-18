import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import Header from "../widgets/Header/Header";
import Vitrina from "../pages/Vitrina";
import Bin from "../pages/Bin";
import Login from "../pages/Login";


function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <div className="content">
        <Routes>
        <Route path="/bin" element={<Bin/>}></Route>
        <Route path="/" element={<Vitrina/>}></Route>
        <Route path="/login" element={<Login/>}></Route>
      </Routes>
      </div>
      
    </BrowserRouter>
  );
}

export default App;
