import * as React from 'react'
import todoelement from '../Models/todoelement';
import {removeToDoRequest,renameToDo,markAsDoneRequest} from '../Actions/toDoActions';
import { AppActions } from '../Types/todoAction';
import { ThunkDispatch } from 'redux-thunk';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { AppState } from '../store';


interface AddToDoProps{
    todo:todoelement;
}

interface SingleToDoState{
    editMode:boolean;
    tempName:string
}

type Props = AddToDoProps & LinkDispatchProps;


class SingleToDo extends React.Component<Props,SingleToDoState>{


    state:SingleToDoState ={
        editMode : false,
        tempName : this.props.todo.tittle
    }

    onRemoveClick = () =>{
        this.props.removeToDoRequest(this.props.todo);
    }


    onEditClick = () => {
        this.toggleEditState();

        if(this.state.editMode)
            this.setState({
                tempName : this.props.todo.tittle
            })
    }

    toggleEditState = () =>{
        this.setState({
            editMode : !this.state.editMode
        })
    }


    onInputChange = (event: React.FormEvent<HTMLInputElement>) =>{
        this.setState({
            tempName : event.currentTarget.value
        })
    }


    onFormSubmit = (event: React.FormEvent) =>{
        event.preventDefault();
        this.toggleEditState();
        this.props.renameToDoRequest(this.props.todo,this.state.tempName);
    }

    onDoneClick = () =>{
        this.props.markAsDoneRequest(this.props.todo,this.props.todo.tittle,!this.props.todo.done);
    }


   render(){
       return(
        <React.Fragment>



        <li className={"list-group-item d-flex justify-content-between align-items-center " + (this.props.todo.done ? ' doneToDo' : '')}>
            {
                this.state.editMode === false &&
                     this.props.todo.tittle
            }

            {
                this.state.editMode === true &&
                        <form className="form-inline justify-content-center" onSubmit={this.onFormSubmit}>
                            <div className="input-group mb-2 mr-sm-2 mb-sm-0">
                            <input type="text" className="form-control" id="tittle" placeholder="New task name"  value = {this.state.tempName}  onChange={this.onInputChange}/>
                            </div>
                            <button type="submit" className="btn btn-primary my-2 my-sm-0">Rename Task </button>
                        </form>
            }

           <div className="align-items-right">
                <span className="badge badge-success">    
                    <i className={"fas " + (this.props.todo.done ? ' fa-undo' : ' fa-check')}onClick={this.onDoneClick} ></i>
                </span>
                <span className="badge badge-primary">    
                    <i className="fas fa-edit " onClick={this.onEditClick} ></i>
                </span>
                <span className="badge badge-danger">
                    <i className="fas fa-trash-alt " onClick={this.onRemoveClick} ></i>
                </span>    
        </div>
      </li>
      </React.Fragment>
       )
   }
}

interface LinkDispatchProps{
    removeToDoRequest: (todo:todoelement) =>void;
    renameToDoRequest: (todo:todoelement,newName:string) =>void;
    markAsDoneRequest: (todo:todoelement,newName:string,done:boolean)=>void;
}


const mapeDispatchToProps = (dispatch: ThunkDispatch<any,any,AppActions>, ownProps : AddToDoProps)  :  LinkDispatchProps =>({
    removeToDoRequest: bindActionCreators(removeToDoRequest,dispatch),
    renameToDoRequest: bindActionCreators(renameToDo,dispatch),
    markAsDoneRequest: bindActionCreators(markAsDoneRequest,dispatch)
});

export default connect((state:AppState)=>{return state } ,mapeDispatchToProps)(SingleToDo);