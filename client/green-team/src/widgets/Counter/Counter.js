import { useDispatch} from "react-redux";
import { decrementCount, incrementCount} from "../../store/binSlice";
import "./Counter.css";
import plus from "./images/plus.png";
import minus from "./images/minus.png";
function Counter ({item}){
    const dispatch = useDispatch();
    return(
        <div className="choice-counter">
                <img src={minus} onClick={() => dispatch(decrementCount(item.id))}></img>
                <span>{item.count}</span>
                <img src={plus} onClick={() => dispatch(incrementCount(item.id))}></img>
        </div>
    );
}
export default Counter;