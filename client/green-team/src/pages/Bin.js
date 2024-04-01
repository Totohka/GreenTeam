import { useSelector } from "react-redux";
import Choice from "../widgets/Choice/Choice";
import "./Bin.css";

function Bin(){
    const items = useSelector(state=>state.bin.items);
    console.log(items);
    console.log("Null elem of items ",items[0]);
    let choices=items.map(item=>(
        <Choice key={item.id} item={item}></Choice>
    ));
    console.log(choices);
    let summ = useSelector(state=>state.bin.summ);
    return(
        <div className="bin">
            <div className="choices">
                {choices}
            </div>
            <div className="endsumm">
                {/* <div > */}
                    <input className="address" placeholder="Адрес доставки"></input>
                {/* </div> */}
                <div className="h-summ">
                    <p>Итого</p>
                    <h1>{summ} ₽</h1>
                </div>
                <div className="buttom-buy">Заказать</div>
            </div>
            
        </div>
    );
}
export default Bin;