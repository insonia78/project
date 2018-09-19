const PerformCrawling  = require('../helper-object-class/performSearch');
const jsonFile = require('../../files/internet2.json');
const performCrawiling  = new PerformCrawling(jsonFile.pages);
process.send(performCrawiling.Init());

  