import "./Admin.css"
function Admin(){
    return(
        <div id="admin" className="admin-block">
            <div className="admin-btn">
                <p><button className="btn-add-item">Добавить товар</button></p>
                <p><button className="btn-add-edit">Редактировать товар</button></p>
               <p><button className="btn-add-menu">Добавить пункт меню</button></p>
                <p> <button className="btn-add-delete">Удалить товар</button></p>
            </div>
            <div className="admin-input">
              <p>  <input className="input-edit-name" placeholder="Название"></input></p>
               <p> <input className="input-edit-price" placeholder="Цена"></input></p>
               <p>  <input className="input-edit-manufacturer" placeholder="Производитель"></input></p>
               <p>  <input className="input-edit-category" placeholder="Категория"></input></p>
               <p>  <input className="input-edit-about" placeholder="Описание"></input></p>
                
            </div>
            
            
        </div>
    )
}
export default Admin;