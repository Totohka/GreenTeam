import axios from "axios";
import "./Product.css";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { useEffect, useState } from "react";
import { getAllItems } from "../store/itemsSlice";
import { useGetItemQuery, useGetSupplierQuery } from "../store/apiSlice";
import { addItemToBin, removeItemFromBin } from "../store/binSlice";

function Product () {
    //#region ButtonBin 
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
    //#endregion
    function TakePhoto(e){
        setMainPhoto(e.target.src);
    }
    let param = useParams();
    let id = Number(param['*']);
    const dispatch = useDispatch(); 
    const items = useSelector(state => state.items.data.filter((el)=>el.id==id)[0]);
    const itemsStatus = useSelector(state => state.items.status)
    const error = useSelector(state => state.items.error)
    // console.log(item);
    const [supplier, setSupplier] = useState('');
    const [photos, setPhotos] = useState('');
    const [mainPhoto, setMainPhoto] = useState('');
    const [item, setItem] = useState('');
    const WaitInfo = async() => {
        const iteminfo = await axios.get("http://25.32.11.98:8083/api/Product", {params: {id: id}}, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
        setItem(iteminfo.data);
        // console.log(item);
        const info = await axios.get("http://25.32.11.98:8083/api/Supplier", {params:{ id: iteminfo.data.supplierId}}, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
        // console.log(info);
        setSupplier(info.data);
        // console.log(supplier);
        const pictures = await axios.get("http://25.32.11.98:8083/api/Image", {params:{ productId: iteminfo.data.id}},{
            headers: {
                'Content-Type': 'application/json'
            }
        });
        console.log(id);
        setPhotos(pictures.data.map((pho)=>{return (<img onClick={TakePhoto} className="photoProduct" src={"http://25.32.11.98:8083/products/"+pho}></img>)}));
        setMainPhoto("http://25.32.11.98:8083/products/"+pictures.data[0]);
        
    }
    let content = <div>"Loading..."</div>;
    useEffect(() => {
        WaitInfo();
    },[id]);
    useEffect(()=>{
        if (binitems.filter((it) => it.id==item.id).length) {
            setBClass("block");
            setClass("none");
          }
        console.log("bin");
    }, [binitems])
    if (item === '') {
        content = <div>"Loading..."</div> 
      } else {
       
        //console.log(item);
        
        content = <div className="prod-info">
                    <div className="prod-name">{item.name}</div>
                    <div className="prod-price">{item.price} ₽</div>
                    <div className="prod-suplier">Производитель: {supplier.name}</div>
                    <div className="prod-description">Описание товара: {item.description}</div>
                    <div className="add-to-bin-prod" style={{display: aClass}} onClick={()=>Added(item)}>В корзину</div>
                    <div className="already-in-bin-prod" style={{display: bClass}} onClick={()=>Remove(item)}>Убрать из корзины</div>
                </div>;
      };
    
    return(
        <div className="product">
            <div className="all-photos">
                {photos}
            </div>
            <div className="main-photo">
                <img  src={mainPhoto}></img>
            </div>
            {content}
            {/* <div className="prod-info">
                <div className="prod-name">{item.name}</div>
                <div className="prod-price">{item.price} ₽</div>
                <div className="prod-suplier">Производитель: {supplier.name}</div>
                <div className="prod-description">Описание товара: {item.description}</div>
                <div className="add-to-bin-prod" style={{display: aClass}} onClick={()=>Added(item)}>В корзину</div>
                <div className="already-in-bin-prod" style={{display: bClass}} onClick={()=>Remove(item)}>Убрать из корзины</div>
            </div> */}
        </div>
    )
}
export default Product;