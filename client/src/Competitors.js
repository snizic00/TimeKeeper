import React,{Component} from 'react';
import {variables} from './Variables.js'; 

export class Competitors extends Component{


    constructor(props){

        super(props);

        this.state={
            competitors:[],
            modalTitle:"",
            Id:0,
            Name:"",
            StartNo:"",
            TeamId:"",
            BicycleId:""
        }
    }

    refreshList(){
        fetch(variables.API_URL+'competitors')
        .then(response=>response.json())
        .then(data=>{
            this.setState({competitors:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    changeName =(e)=>{
        this.setState({Name:e.target.value});
    }

    changeStartNo =(e)=>{
        this.setState({StartNo:e.target.value});
    }

    changeTeamId =(e)=>{
        this.setState({TeamId:e.target.value});
    }

    changeBicycleId =(e)=>{
        this.setState({BicycleId:e.target.value});
    }



    addClick(){
        this.setState({
            modalTitle:"Add Competitor",
            Id:0,
            Name:"",
            StartNo:"",
            TeamId:"",
            BicycleId:""
        });
    }
    editClick(com){
        this.setState({
            modalTitle:"Edit Competitor",
            Id:com.Id,
            Name:com.Name,
            StartNo:com.StartNo,
            TeamId:com.TeamId,
            BicycleId:com.BicycleId
        });
    }

    createClick(){
        fetch(variables.API_URL+'competitors/male',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Name:this.state.Name,
                StartNo:this.state.StartNo,
                TeamId:this.state.TeamId,
                BicycleId:this.state.BicycleId
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    deleteClick(StartNo){

        fetch(variables.API_URL+'competitors/'+ StartNo,{
            method:'DELETE',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        })
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })

    }

    render(){
        const {
            competitors,
            modalTitle,
            Id,
            Name,
            StartNo,
            TeamId,
            BicycleId           
        }=this.state;

        return(
            
            <div>

                <button type="button"
                className="btn btn-primary m-2 float-end"
                data-bs-toggle="modal"
                data-bs-target="#exampleModal"
                onClick={()=>this.addClick()}>
                    Add Male Competitor
                </button>
                <table className='table table-striped'>
                <thead>
                <tr>
                    <th>
                        Id
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        StartNo
                    </th>
                    <th>
                        TeamId
                    </th>
                    <th>
                        BicycleId
                    </th>
                    {/* <th>
                        Category
                    </th> */}
                    <th>
                        Options
                    </th>
                </tr>
                </thead>
                    <tbody>
                    {competitors.map(com=>
                        <tr>
                            <td>{com.Id}</td>
                            <td>{com.Name}</td>
                            <td>{com.StartNo}</td>
                            <td>{com.TeamId}</td>
                            <td>{com.BicycleId}</td>
                            <td>
                                <button type="button"
                                className="btn btn-light mr-1"
                                data-bs-toggle="modal"
                                data-bs-target="#exampleModal"
                                onClick={()=>this.editClick(com)}
                                >
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                                    <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                                    </svg>
                                </button>

                                <button type="button"
                                className="btn btn-light mr-1"
                                onClick={()=>this.deleteClick(com.StartNo)}
                                >
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                    <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                                    </svg>
                                </button>
                            </td>





                        </tr>)}
                    </tbody>
                </table>

<div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
<div className="modal-dialog modal-lg modal-dialog-centered">
<div className="modal-content">
   <div className="modal-header">
       <h5 className="modal-title">{modalTitle}</h5>
       <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"
       ></button>
   </div>

   <div className="modal-body">
       <div className="input-group mb-3">
        <span className="input-group-text">Name</span>
        <input type="text" className="form-control"
        value={Name}
        onChange={this.changeName}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">StartNo</span>
        <input type="text" className="form-control"
        value={StartNo}
        onChange={this.changeStartNo}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">TeamId</span>
        <input type="text" className="form-control"
        value={TeamId}
        onChange={this.changeTeamId}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">BicycleId</span>
        <input type="text" className="form-control"
        value={BicycleId}
        onChange={this.changeBicycleId}/>
       </div>

        {Id==0?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.createClick()}
        >Create</button>
        :null}

        {Id!=0?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.updateClick()}
        >Update</button>
        :null}

   </div>

</div>
</div> 
</div>


</div>
        )
    }
}