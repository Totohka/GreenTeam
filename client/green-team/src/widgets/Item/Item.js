import { useDispatch, useSelector } from "react-redux";
import { addItemToBin, removeItemFromBin } from "../../store/binSlice";
import "./Item.css";
import { useEffect, useState } from "react";
function Item ({item}){
    const [aClass, setClass] = useState("block");
    const [bClass, setBClass] = useState("none"); 
    const binitems = useSelector(state=>state.bin.items);
    function Added(item){
        setBClass("block");
        setClass("none");
        dispatch(addItemToBin(item))
    }
    function Remove(item){
        setClass("block");
        setBClass("none");
        dispatch(removeItemFromBin(item.id));
    }
    const dispatch = useDispatch();
    useEffect(()=>{
        if (binitems.filter((it) => it.id==item.id).length) {
            setBClass("block");
            setClass("none");
          }
    }, [binitems, dispatch])
    return (
        <div className='item'>
            <div className="item-image"></div>
            <p className='item-price'>{item.price} ₽</p>
            <p className='item-name'>{item.name}</p>
        <div className="add-to-bin" style={{display: aClass}} onClick={()=>Added(item)}>В корзину</div>
        <div className="already-in-bin" style={{display: bClass}} onClick={()=>Remove(item)}>Убрать из корзины</div>
    </div>
    )
}
export default Item;