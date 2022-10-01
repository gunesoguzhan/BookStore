const fileOperations = require('./fileOperations.js');

fileOperations.writeFile('./employee.json', '{"name": "Employee 1 Name", "salary": 2000}');
fileOperations.appendFile('./employee.json', '{"name": "Employee 2 Name", "salary": 2300}');
fileOperations.readFile('./employee.json');
// fileOperations.deleteFile('./employee.json');
