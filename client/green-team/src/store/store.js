import { configureStore } from '@reduxjs/toolkit'
import choicesSlice from '../features/choices/choicesSlice'

export default configureStore({
  reducer: {
    choices:  choicesSlice
  },
})