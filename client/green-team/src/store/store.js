import { configureStore } from '@reduxjs/toolkit'
import choicesSlice from '../features/choices/choicesSlice'
import itemsSlice from './itemsSlice'
import binSlice from './binSlice';
import categoriesSlice from './categoriesSlice';
import userSlice from './userSlice';
import { apiSlice } from './apiSlice';

let store = configureStore({
  reducer: {
    choices:  choicesSlice,
    items: itemsSlice,
    bin: binSlice,
    categories: categoriesSlice,
    user: userSlice,
    [apiSlice.reducerPath]: apiSlice.reducer
  },
  middleware: getDefaultMiddleware =>
    getDefaultMiddleware().concat(apiSlice.middleware)
})
export default store;