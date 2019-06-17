import ToDoElement from '../Models/todoelement'


export enum ToDoActions {
    FETCH_REQUEST="FETCH_REQUEST",
    FETCH_SUCCESS="FETCH_SUCCESS",
    FETCH_ERROR="FETCH_ERROR",
    ADD_TODO = "ADD_TODO",
    REMOVE_TODO = "REMOVE_TODO",
    RENAME_TODO = "RENAME_TODO",
    DONE_TODO = "DONE_TODO"
}



export interface DoneToDo {
    type: typeof ToDoActions.DONE_TODO
    todo: ToDoElement,
    done: boolean,
    newName: string
}

export interface AddToDo {
    type: typeof ToDoActions.ADD_TODO
    todo: ToDoElement;
}

export interface RemoveToDo {
    type: typeof ToDoActions.REMOVE_TODO,
    todo: ToDoElement;
}

export interface RenameToDo{
    type: typeof ToDoActions.RENAME_TODO,
    todo: ToDoElement,
    newName: string
}

export interface RequestToDoFetch {
    type: typeof ToDoActions.FETCH_REQUEST
}


export interface RequestToDoSuccess {
    type: typeof ToDoActions.FETCH_SUCCESS,
    todos:ToDoElement[]
}

export interface RequestToDoError{
    type: typeof ToDoActions.FETCH_ERROR,
    error:string;
}

export type ToDoActionTypes = RequestToDoFetch | RequestToDoSuccess |  RequestToDoError | AddToDo | RemoveToDo | RenameToDo | DoneToDo;
export type AppActions = ToDoActionTypes;

