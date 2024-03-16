import { createSlice } from "@reduxjs/toolkit";

export const binSlice = createSlice({
    name:'bin',
    initialState:{
        items:[],
        summ:0.0
    },
    reducers:{
        addItemToBin:(state, action)=>{
            let item = new Object();
            item = {...action.payload};
            item.count=1;
            item.subsum=item.price;
            state.items=state.items.concat(item);
            state.summ+=item.price;
        },
        incrementCount: (state, action) => {
            let id= action.payload;
            state.items=state.items.map((item)=>{
                if (item.id==id){
                    item.count+=1;
                    item.subsum+=item.price;
                    state.summ+=item.price;
                }
                return item;
            })
        },
        decrementCount: (state,action)=>{
            let id= action.payload;
            state.items=state.items.map((item)=>{
                if (item.id==id && item.count!=1){
                    item.count-=1;
                    item.subsum-=item.price;
                    state.summ-=item.price;
                }
                return item;
            })
        },
    }
})
export const {addItemToBin, incrementCount, decrementCount} = binSlice.actions;
export default binSlice.reducer;