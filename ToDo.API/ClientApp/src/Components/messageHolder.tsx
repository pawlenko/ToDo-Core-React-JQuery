import * as React from 'react'
import { AppState } from '../store';
import { connect } from 'react-redux';
import GetErrorDescription from '../Utils/errorHelper';




interface MessageState{}
interface MesageProps{}

type Props  = LinkStateProp & MesageProps


class MessageHolder extends React.Component<Props,MessageState>{

    render(){

        const errors = this.props.errors.map((item)=>
            <div className="alert alert-danger alert-dismissible fade show" role="alert">
               {GetErrorDescription(item)}
            <button type="button" className="close" data-dismiss="alert" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
        );
        


        return(
            <React.Fragment>
                 {errors}
            </React.Fragment>
        )
    }
}


interface LinkStateProp {
    errors: String[]
}

const mapStateToProps = (state:AppState) : LinkStateProp =>({
    errors : state.toDo.errors
  });
 
export default connect(mapStateToProps)(MessageHolder);