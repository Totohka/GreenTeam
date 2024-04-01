import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";


export const getUser = createAsyncThunk(
  'user/getUser',
  async(user)=>{
    const responce = await axios.get("http://25.32.11.98:8082/Auth", user, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
      return responce.data;
  }
)
export const userSlice = createSlice({
    name:'user',
    initialState:{
        data:[],
        accessToken: '',
        status: '',
        error:''
    },
    reducers: {
        setAccessTokenUser:(state, action)=>{
            state.accessToken=action.payload;
            localStorage.setItem("token", action.payload);
        },
        setAccoutSetting:(state, action)=>{
            state.data=action.payload;
        },
        deleteUserInfo:(state)=>{
          state.accessToken='';
          localStorage.removeItem("token");
          state.data=[];
          state.status='';
          state.error='';
        }
    },
    extraReducers(builder) {
        builder
          .addCase(getUser.pending, (state, action) => {
            state.status = 'loading'
          })
          .addCase(getUser.fulfilled, (state, action) => {
            state.status = 'succeeded'
            state.accessToken = action.payload
          })
          .addCase(getUser.rejected, (state, action) => {
            state.status = 'failed'
            state.error = action.error.message
          })
    }
})
export const {setAccessTokenUser, setAccoutSetting, deleteUserInfo} = userSlice.actions;
export default userSlice.reducer;