import ToDoElement from '../Models/todoelement'
import {ToDoActionTypes, ToDoActions} from '../Types/todoAction';



export interface ToDoState {
    toDos : ToDoElement[],
    errors : String[]
};

const initialState: ToDoState = {
    toDos : [],
    errors: []
};


export function  toDoReducer(state = initialState,action: ToDoActionTypes) : ToDoState{
    switch(action.type){
        case ToDoActions.ADD_TODO:
           return { ...state, toDos: [ action.todo, ...state.toDos ] }
        case ToDoActions.FETCH_REQUEST:
            return state;
        case ToDoActions.FETCH_SUCCESS:
            return { ...state, toDos: [ ...action.todos ] }
        case ToDoActions.FETCH_ERROR:
            return {...state,errors:[action.error,...state.errors]}
        case ToDoActions.REMOVE_TODO:
            return {...state,toDos:[...state.toDos.filter(x=>x !==action.todo)]}
        case ToDoActions.RENAME_TODO:
        return {...state,toDos:[...state.toDos.map((item) => {
            if(item.id === action.todo.id) {
                action.todo.tittle = action.newName;
              return item;
            }
            return item;
          })
]}
        case ToDoActions.DONE_TODO:

        return {...state,toDos:[...state.toDos.map((item) => {
            if(item.id === action.todo.id) {
                action.todo.done = action.done;
              return item;
            }
            return item;
          })
]}

         default :
            return state;

    }
}

