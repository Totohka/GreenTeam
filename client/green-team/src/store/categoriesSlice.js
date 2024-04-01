import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";

export const getAllCategories = createAsyncThunk(
  'items/getAllCategories',
  async () => {
      let response = await axios.get("http://25.32.11.98:8083/api/Category/all");//8082/token 8084/user /192.168.0.15:8083/Prod localhost:5067
      console.log ("Taken response", response);
      return response.data
  }
)


export const categoriesSlice = createSlice({
    name: 'categories',
    initialState: {
        data: [],
        status: 'idle',
        error: null
    },
    reducers: {
        setCategories: (state, action) => {
            state.data = action.payload;
        }
    },
    extraReducers(builder) {
        builder
          .addCase(getAllCategories.pending, (state, action) => {
            state.status = 'loading'
          })
          .addCase(getAllCategories.fulfilled, (state, action) => {
            state.status = 'succeeded'
            // Add any fetched utems to the array
            state.data = action.payload
          })
          .addCase(getAllCategories.rejected, (state, action) => {
            state.status = 'failed'
            state.error = action.error.message
          })
          
    }
})
export const {setCategories} = categoriesSlice.actions;
export default categoriesSlice.reducer;
// export const selectItems = state => state.items.data;