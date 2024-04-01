import { NavLink } from "react-router-dom";
import "./Category.css";

function Category({category}){
    return(
        <NavLink className="category" to={`/catalog/${category.id}`}>
            {category.name} 
        </NavLink>
    )
}
export default Category;