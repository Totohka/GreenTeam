import { useDispatch, useSelector } from "react-redux";
import { getAllItems } from "../../store/itemsSlice";
import { NavLink, useParams } from 'react-router-dom';
import { useEffect, useRef } from "react";
import "./Items.css";
import Item from "../Item/Item";
import { useGetAllItemsQuery, useGetPhotosQuery } from "../../store/apiSlice";
import axios from "axios";

function Items(){
    const param = useParams();
    const id = Number(param['*']);
    console.log(id);
    const {
      data: items = [],
      isLoading,
      isSuccess,
      isError,
      error
    } = useGetAllItemsQuery();
    const {
      data: photos = [],
      isLoadingP,
      isSuccessP,
      isErrorP,
      errorP
    } = useGetPhotosQuery();
  //   const WaitPhoto = async() => {
  //     const pic = await axios.get("http://25.32.11.98:8083/api/Image/all", {
  //         headers: {
  //             'Content-Type': 'application/json'
  //         }
  //     });
  //     // console.log(pictures);
  //     photos=pic.data;
  // }
  // useRef(()=>{
  //     WaitPhoto();
  // },[])
  //   const dispatch = useDispatch();
  //   const items = useSelector(state=>state.items.data)
  //   const itemsStatus = useSelector(state => state.items.status)
  //   const error = useSelector(state => state.items.error)

  //   useEffect(()=>{
  //       console.log ("Try taken response");
  //       if (itemsStatus === 'idle') {
  //           dispatch(getAllItems())
  //         }
  //   }, [itemsStatus, dispatch])
    
   let content=<div className="non-content">"Loading..."</div>;
   if (isLoading) {
    content = <div className="non-content">"Loading..."</div>
  } else if (isSuccess) {
    console.log(items);
    console.log(photos);
    content = items;
  } else if (isError) {
    content = <div>{error.toString()}</div>
  }
  console.log(photos);
  // if (itemsStatus === 'loading') {
  //   content = <div>"Loading..."</div> 
  // } else if (itemsStatus === 'succeeded') {
  //   const orderedItems = items;
  //   console.log(items);
  //   content = items;
  // } else if (itemsStatus === 'failed') {
  //   content = <div>{error}</div>
  // };
  let photo='';
  if (content!==<div>{error}</div> && content!==<div className="non-content">"Loading..."</div>){
    content = items.map((el)=>{
      photo=null;
      photos.forEach(element => {
          // console.log(`${el.id}/`);
          // console.log(element.includes(`${el.id}/`))
          // console.log(element);
          if (element.includes(`${el.id}/`))
            photo=element;
        });
      if (photo==null) photo="0/0.jpg";
      if (id!=0){
        if (el.categoryId==id) 
          return <Item key={el.id} item={el} photo={photo}/>
        else return null;
      } 
      else return <Item key={el.id} item={el} photo={photo}/>;
    })
    if (content.length == 0) content = <div className="non-content">В данной категории нет товаров</div>
  }
  console.log(content);
  return (
    <div className="products-cards">
      {content}
    </div>
  )
}
export default Items;