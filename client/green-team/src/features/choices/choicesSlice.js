import { createSlice } from '@reduxjs/toolkit'

export const choiceSlice = createSlice({
    name: 'count',
    initialState: {
        img: "",
        name: "",
        price: 0.0,
        count: 0
    },
    reducers: {
        increment: state => {
            state.count+=1
        },
        decrement: state=>{
            if (state.count==0)
                state.count=0;
            else state.count-=1
        },
        changeCountByAmount: (state, action) => {
            state.count=action.payload
        }
    }
});
export const {increment, decrement, changeCountByAmount} = choiceSlice.actions;
export const selectCount = state => state.choices.count;
export default choiceSlice.reducer;