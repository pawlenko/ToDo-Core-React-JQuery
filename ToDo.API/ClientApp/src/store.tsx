import { createStore, applyMiddleware } from 'redux';
import { combineReducers } from 'redux';
import {toDoReducer} from './Reducers/todo';
import { compose } from 'redux'; 
import thunkMiddleware from "redux-thunk";


const composeEnhancers = (window as any).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;




const rootReducer = combineReducers({
    toDo:toDoReducer
});

export type AppState = ReturnType<typeof rootReducer>

export default function configureStore() {
  const middlewares = [thunkMiddleware];
  const middleWareEnhancer = applyMiddleware(...middlewares);

  const store = createStore(
    rootReducer,
    composeEnhancers(middleWareEnhancer)
  );

  return store;
}

