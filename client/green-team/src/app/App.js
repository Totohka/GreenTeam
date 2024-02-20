import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import Choice from "../pages/Choice";


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Choice />}>
          
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
