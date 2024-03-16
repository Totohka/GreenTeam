import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";

export const getAllItems = createAsyncThunk(
    'items/getAllItems',
    async () => {
        let response = await axios.get("http://localhost:5067/api/Product/all");//8082 8084//192.168.0.15:8083
        console.log ("Taken response", response);
        return response.data
    }
)


export const itemsSlice = createSlice({
    name: 'items',
    initialState: {
        data: [],
        status: 'idle',
        error: null
    },
    reducers: {
        setItems: (state, action) => {
            state.data = action.payload;
        }
    },
    extraReducers(builder) {
        builder
          .addCase(getAllItems.pending, (state, action) => {
            state.status = 'loading'
          })
          .addCase(getAllItems.fulfilled, (state, action) => {
            state.status = 'succeeded'
            // Add any fetched utems to the array
            state.data = action.payload
          })
          .addCase(getAllItems.rejected, (state, action) => {
            state.status = 'failed'
            state.error = action.error.message
          })
    }
})
export const {setItems} = itemsSlice.actions;
export default itemsSlice.reducer;
// export const selectItems = state => state.items.data;