/*
  - the application is assuming that the http request are perfomed in the separate process
  - the application is using fork and comunicate via signal to the main process
    if this comunication beetween processes was not in place the process that would have finished first 
    would have displayed is results first 
  - The application lack's unit testing do to the scope and the time constrain to it 
   
*/

const fs  = require('fs');
const internet1 = require('./files/internet1.json');
const internet2 = require('./files/internet2.json');
const { fork } = require('child_process');

const forked = fork('./files/crawling-addresses-files/internet1.js');
forked.on('message', (msg) => {
console.log('Message from internet1\n', msg);
});
const forked1 = fork('./files/crawling-addresses-files/internet2.js');
forked1.on('message', (msg) => {
  console.log('Message from internet2\n', msg);
});

// will run independently 
const forked2 = fork('./files/crawling-addresses-files/internet1.js');
const forked3 = fork('./files/crawling-addresses-files/internet2.js');


  
  
     
 
