import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

// Define our single API slice object
export const apiSlice = createApi({
  // The cache reducer expects to be added at `state.api` (already default - this is optional)
  reducerPath: 'api',
  // All of our requests will have URLs starting with '/fakeApi'
  baseQuery: fetchBaseQuery(),
  // The "endpoints" represent operations and requests for this server
  endpoints: builder => ({
    // The `getPosts` endpoint is a "query" operation that returns data
    getAllItems: builder.query({
      // The URL for the request is '/fakeApi/posts'
      query: () => 'http://25.32.11.98:8083/api/Product/all'
    }),
    getItem: builder.query({
        query: id => ({
            url: 'http://25.32.11.98:8083/api/Product',
            method: 'GET',
            // Include the entire post object as the body of the request
            body: id
        })
    }),
    getPhotos: builder.query({
        query: () => 'http://25.32.11.98:8083/api/Image/all'
    })
  })
})


// Export the auto-generated hook for the `getPosts` query endpoint
export const { useGetAllItemsQuery, useGetItemQuery, useGetPhotosQuery } = apiSlice