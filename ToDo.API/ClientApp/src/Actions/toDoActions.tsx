import ToDoElement from '../Models/todoelement';
import {AppActions} from '../Types/todoAction';
import  {ToDoActions} from '../Types/todoAction';
import { Dispatch, Action } from 'redux';
import { AppState } from '../store';
import axios from 'axios';
import todoelement from '../Models/todoelement';
import { ThunkAction } from 'redux-thunk';


export const StartFetch = (): AppActions => ({
    type:ToDoActions.FETCH_REQUEST
});
export const RequestSuccess = (todos: ToDoElement[]): AppActions => ({
    type:ToDoActions.FETCH_SUCCESS,
    todos
});
export const RequestError = (error: string): AppActions => ({
    type:ToDoActions.FETCH_ERROR,
    error
});

export const AddToDoRequest = (todo : ToDoElement) :AppActions =>({
    type:ToDoActions.ADD_TODO,
    todo
})

export const RemoveToDo = (todo : ToDoElement) :AppActions =>({
    type:ToDoActions.REMOVE_TODO,
    todo
})

export const RenameToDo = (todo:ToDoElement,newName: string) :AppActions =>({
    type:ToDoActions.RENAME_TODO,
    todo,
    newName
})

export const DoneToDo = (todo:todoelement,newName:string,done:boolean): AppActions => ({
    type:ToDoActions.DONE_TODO,
    todo,
    newName,
    done
})

type ThunkResult<R> = ThunkAction<R, AppState, undefined, any>;


export const markAsDoneRequest = (todo:todoelement,tittle:string,done:boolean) =>{
    return(dispatch:Dispatch<AppActions>,getState:()=>AppState)  =>{
        dispatch(
            StartFetch()
        );
        axios.put('/api/todo/'+todo.id,{tittle:tittle,done:done}).then(res=>{
            dispatch(DoneToDo(todo,tittle,done));
            return Promise.resolve();
        },err=>{
            RequestError(err.response.data)
            return Promise.reject();
        })
    }
}


export const renameToDo = (todo: todoelement,tittle:string)=>{
    return(dispatch:Dispatch<AppActions>,getState:()=>AppState)  =>{

        dispatch(
            StartFetch()
        );

        axios.put('/api/todo/'+todo.id,{tittle:tittle,done:todo.done}).then(res=>{
            dispatch(RenameToDo(todo,tittle));
            return Promise.resolve();
        },err=>{
            RequestError(err.response.data)
            return Promise.reject();
        })
    }
}



export const removeToDoRequest = (todo : todoelement) =>{
    return (dispatch:Dispatch<AppActions>,getState:()=>AppState)=>{

        dispatch(
            StartFetch()
        );

        axios.delete('/api/todo/'+todo.id).then(res=>{
            dispatch(RemoveToDo(todo));
        },err=>{
            RequestError(err.response.data)
        })

    }
}

export const addToDoRequest = (tittle:string,priority: number)=>{
    return(dispatch : Dispatch<AppActions>,getState: ()=> AppState)=>{
        dispatch(
            StartFetch()
        );
        axios.post<ToDoElement>('/api/todo', { tittle: tittle, priority: priority }).then(res => {
            dispatch(
                AddToDoRequest(res.data)
            );
        },err=>{
            dispatch(
                RequestError(err.response.data)
            );
        })
    } 
}

  
export const fetchToDos = () => {
    return(dispatch : Dispatch<AppActions>,getState: ()=> AppState)=>{
        dispatch(
            StartFetch()
        );
         axios.get<ToDoElement[]>('/api/todo').then(res=>{
            dispatch(
                RequestSuccess(res.data)
            );
        },err=>{
            dispatch(
                RequestError(err.response.data)
            );
        })
    }
}
