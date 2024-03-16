import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import Choice from "../pages/Choice";
import Header from "../widgets/Header/Header";
import Vitrina from "../pages/Vitrina";
import Bin from "../pages/Bin";


function App() {
  return (
    <BrowserRouter>
      <Header></Header>
      <Routes>
        <Route path="/bin" element={<Bin/>}></Route>
        <Route path="/catalog" element={<Vitrina/>}></Route>
        <Route path="/" element={<Choice />}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
