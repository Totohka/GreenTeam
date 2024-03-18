import { useDispatch} from "react-redux";
import { decrementCount, incrementCount, removeItemFromBin } from "../../store/binSlice";

import "./Choice.css";
import xmark from "./images/xmark.png";
import Counter from "../Counter/Counter";


function Choice ({ item }) {
    const dispatch = useDispatch();
    return (
        <div className="choice">
            <div className="choice-img"></div>
            <p className="choice-name">{item.name}</p>
            <Counter item={item}/>
            <div className="del-and-sum">
                <img src={xmark} onClick={() => dispatch(removeItemFromBin(item.id))}className="choice-delete" />
                <p className="choice-subsum">{item.subsum} ₽</p>
            </div>
            
        </div>
    )}
export default Choice;