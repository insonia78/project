/*
  - The application is using only the main processor not sure how to do multi web worker 
  - In this case . The css in minimized to reflect the min requiremnts 
  - The object that does the bussiness logic is imported from the node js version
    the ajax call would be in the bussiness logic and handled there 
  - There are no unit testing do to the requirements of the application 
  
*/


import React, { Component } from "react";
import internet1 from "../src/internet1";
import internet2 from "../src/internet2";
import "./App.css";
import WebAddress from "./WebAddress/WebAddress";


class App extends Component {
  state = {
    arrayOfvalues : [internet1, internet2]
  }
  render() {
    let addresses = null;
    addresses = (
      <div>
       { 
        this.state.arrayOfvalues.map( (address) =>
        {return <WebAddress file={JSON.stringify(address.pages)} />})
       }
      </div>
    );
    return <div className="App">{addresses}</div>;
  }
}

export default App;
