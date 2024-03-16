import { useDispatch, useSelector } from "react-redux";
import { decrementCount, incrementCount } from "../store/binSlice";

const Choice = ({ item }) => {
    const dispatch = useDispatch();
    return (
        <div className="choice">
            <p>{item.name}</p>
            <p>{item.count}</p>
            <p>{item.subsum}</p>
            <div>
                <button
                aria-label="Increment value"
                onClick={() => dispatch(incrementCount(item.id))}
                >
                +
                </button>
                <span>{item.count}</span>
                <button
                aria-label="Decrement value"
                onClick={() => dispatch(decrementCount(item.id))}
                >
                -
                </button>
            </div>
        </div>
    )}

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
        <div>
            {choices}
            <h1>{summ}</h1>
        </div>
    );
}
export default Bin;