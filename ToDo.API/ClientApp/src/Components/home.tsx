import React from 'react';
import ToDoElement from '../Models/todoelement'
import {connect} from "react-redux";
import { AppState } from '../store';
import { ThunkDispatch } from 'redux-thunk';
import { AppActions } from '../Types/todoAction';
import { bindActionCreators } from 'redux';
import {fetchToDos} from '../Actions/toDoActions';
import AddToDo from "./addToDo";
import SingleToDo from "./singleToDo";
import MessageHolder from "./messageHolder"


interface HomePageProps{}
interface HomePageState{}

type Props = HomePageProps & LinkStateProp & LinkDispatchProps

class Home extends React.Component<Props,HomePageState>{


        componentDidMount() {
            this.props.startFetchToDos();
        }

        render(){
            const items = this.props.toDos.map((item,i)=>
            <SingleToDo todo={item} key={i} > </SingleToDo>
       );

            return (
       <div className="card text-center">
                <div className="card-header">
                    <MessageHolder/>
                    <AddToDo /> 
                </div>
                <div className="card-body">

                <ul className="list-group">
                    {items}
                </ul>
                 
                </div>
                <div className="card-footer text-muted">
                Your ToDo list
                </div>
      </div>
                  
            )
        }
} 


       

interface LinkStateProp{
    toDos : ToDoElement[]
}
interface LinkDispatchProps{
    startFetchToDos: () =>void;
}

const mapStateToProps = (state:AppState) : LinkStateProp =>({
  toDos : state.toDo.toDos,
});


const mapeDispatchToProps = (dispatch: ThunkDispatch<any,any,AppActions>)  :  LinkDispatchProps =>({
    startFetchToDos: bindActionCreators(fetchToDos,dispatch)
});

export default connect(mapStateToProps,mapeDispatchToProps)(Home);