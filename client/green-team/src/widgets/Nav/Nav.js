import { useDispatch, useSelector } from "react-redux";
import "./Nav.css";
import { getAllCategories } from "../../store/categoriesSlice";
import { NavLink } from "react-router-dom";
import { useEffect } from "react";
import Category from "../Category/Category";

function Nav(){
    const dispatch = useDispatch();
    let categories = useSelector((state)=>state.categories.data);
    let catsStatus = useSelector((state)=>state.categories.status);
    let catsError = useSelector((state)=>state.categories.error);

    useEffect(()=>{
        console.log ("Try taken response");
        if (catsStatus === 'idle') {
            dispatch(getAllCategories())
          }
    }, [catsStatus, dispatch])
    
    let content=<div>Content</div>;

    if (catsStatus === 'loading') {
        content = <div>"Loading..."</div> 
      } else if (catsStatus === 'succeeded') {
        console.log(categories);
        content = categories.map(category=>(
          <Category key={category.id} category={category}/>
        ));
        content.unshift(<Category key= {0} category={{id: '', name:"Все товары"}}/>)
      } else if (catsStatus === 'failed') {
        content = <div>{catsError}</div>
      };
      
    return(
        <div id="nav" className="nav">
            <div>
                {content}
            </div>
            <NavLink className="aboutUs" to="/about">
                <button >Подробнее о нас</button>
            </NavLink>
        </div>
    )
}
export default Nav;