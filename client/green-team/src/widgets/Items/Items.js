import { useDispatch, useSelector } from "react-redux";
import { getAllItems } from "../../store/itemsSlice";
import { useEffect } from "react";
import "./Items.css"
import { addItemToBin } from "../../store/binSlice";

const Item = ({ item }) => {
    const dispatch = useDispatch();
    return (
        <div className='item'>
            <div className="item-image"></div>
            <p className='item-price'>{item.price} ₽</p>
            <p className='item-name'>{item.name}</p>
        <div className="add-to-bin" onClick={()=>dispatch(addItemToBin(item))}>В корзину</div>
    </div>
    )}

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
    // Sort posts in reverse chronological order by datetime string
    const orderedItems = items;
    console.log(items);
    content = items.map(item=>(
        <Item key={item.id} item={item}/>
    ));
    // content = orderedItems.map(item => (
    //   <Item key={item.id} item={item} />
    // ))
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