import React from 'react';

const validation = (props) =>
{    
    let _text = 'string to short';
    if(props.inputLength > 5)
       _text='string to long';
    return (
      <div>
          <p>{_text}</p>
      </div>  
             
    );
};
export default validation;