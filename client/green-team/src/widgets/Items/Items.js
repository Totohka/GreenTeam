import { useDispatch, useSelector } from "react-redux";
import { getAllItems } from "../../store/itemsSlice";
import { useEffect } from "react";
import "./Items.css";
import Item from "../Item/Item";

function Items(){
    const dispatch = useDispatch();
    const items = useSelector(state=>state.items.data)
    const itemsStatus = useSelector(state => state.items.status)
    const error = useSelector(state => state.items.error)

    useEffect(()=>{
        console.log ("Try taken response");
        if (itemsStatus === 'idle') {
            dispatch(getAllItems())
          }
    }, [itemsStatus, dispatch])
    
    let content=<div>Content</div>;

  if (itemsStatus === 'loading') {
    content = <div>"Loading..."</div> 
  } else if (itemsStatus === 'succeeded') {
    const orderedItems = items;
    console.log(items);
    content = items.map(item=>(
      <Item key={item.id} item={item}/>
    ));
  } else if (itemsStatus === 'failed') {
    content = <div>{error}</div>
  };
  return (
    <div className="products-cards">
      {content}
    </div>
  )
}
export default Items;