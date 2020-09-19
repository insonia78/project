import React, { Component } from "react";
import PerformSearch from '../helper-object-class/performSearch.js';


const webAddress = (props) =>{
    let performSearch = new PerformSearch(JSON.parse(props.file));
    let data = performSearch.Init();
    let file = JSON.parse(props.file);
    return (<div className="Addresses">
           {
             file.map((f) =>
             { 
                return<div className="Task"> 
                       <p>Address:{f.address.toString()}</p>
                       <p>Links:{f.links.toString()}</p>
                      </div>;

             })           
            } 
           <p>Success:{JSON.stringify(data.Success)}</p>
           <p>Skyped:{JSON.stringify(data.Skyped)}</p>
           <p>Error:{JSON.stringify(data.Error)}</p>
           </div>);
   
}




export default webAddress;