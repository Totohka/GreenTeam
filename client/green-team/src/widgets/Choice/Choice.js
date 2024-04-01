import { useDispatch} from "react-redux";
import { decrementCount, incrementCount, removeItemFromBin } from "../../store/binSlice";

import "./Choice.css";
import xmark from "./images/xmark.png";
import Counter from "../Counter/Counter";
import { useEffect, useState } from "react";
import axios from "axios";


function Choice ({ item }) {
    const dispatch = useDispatch();
    const [image, setImage] = useState('');
    const GetImage = async() => {
        const responce = await axios.get("http://25.32.11.98:8083/api/Image",{params:{productId:item.id}});
        setImage("http://25.32.11.98:8083/products/"+responce.data[0]);
    }
    useEffect(() => {
        GetImage();
    },[]);
    return (
        <div className="choice">
                <img className="choice-img" src={image}></img>
            <p className="choice-name">{item.name}</p>
            <Counter item={item}/>
            <div className="del-and-sum">
                <img src={xmark} onClick={() => dispatch(removeItemFromBin(item.id))}className="choice-delete" />
                <p className="choice-subsum">{item.subsum} ₽</p>
            </div>
        </div>
    )}
export default Choice;