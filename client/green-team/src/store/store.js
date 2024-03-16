import { configureStore } from '@reduxjs/toolkit'
import choicesSlice from '../features/choices/choicesSlice'
import itemsSlice from './itemsSlice'
import binSlice from './binSlice';

let store = configureStore({
  reducer: {
    choices:  choicesSlice,
    items: itemsSlice,
    bin: binSlice
  },
})
export default store;