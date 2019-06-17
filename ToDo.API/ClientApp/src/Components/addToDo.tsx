import * as React from 'react';
import {connect} from 'react-redux';
import { AppState } from '../store';
import { ThunkDispatch } from 'redux-thunk';
import { AppActions } from '../Types/todoAction';
import {addToDoRequest} from '../Actions/toDoActions';
import { bindActionCreators } from 'redux';



interface AddToDoProps{}
interface AddToDoState{
    name:string;
}

type Props = AddToDoProps & LinkDispatchProps;



class AddToDo extends React.Component<Props,AddToDoState>{


   
   
    state:AddToDoState ={
        name : ""
    }
    formSubmit = (e: React.FormEvent) =>{
        e.preventDefault();
        this.props.addToDoRequest(this.state.name);
    }

    handleChange = (event: React.FormEvent<HTMLInputElement>) => {
        this.setState({
             name:event.currentTarget.value
        });
    }


    render(){
        return (
            <form className="form-inline justify-content-center" onSubmit={this.formSubmit}>
                <div className="input-group mb-2 mr-sm-2 mb-sm-0">
                <input type="text" className="form-control" id="name" placeholder="Task name"   onChange={this.handleChange}/>
                </div>
                <button type="submit" className="btn btn-primary my-2 my-sm-0">Add task</button>
            </form>
        )
    }
} 

interface LinkDispatchProps{
    addToDoRequest: (name: string) =>void;
}


const mapeDispatchToProps = (dispatch: ThunkDispatch<any,any,AppActions>, ownProps : AddToDoProps)  :  LinkDispatchProps =>({
    addToDoRequest: bindActionCreators(addToDoRequest,dispatch)
});

export default connect((state:AppState)=>{return state} ,mapeDispatchToProps)(AddToDo);
