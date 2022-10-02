const { Console } = require('console');
const fs = require('fs');

const readFile = (path) => {
    fs.readFile(path, 'utf-8', (err, data) => {
        if (err) console.log(err);
        else console.log(data);
    })
}

const writeFile = (path, data) => {
    fs.writeFile(path, data, 'utf-8', (err) => {
        if (err) console.log(err);
    })
}

const appendFile = (path, data) => {
    fs.appendFile(path, ',\n' + data, 'utf-8', (err) => {
        if (err) console.log(err);
    })
}

const deleteFile = (path) => {
    fs.unlink(path, (err) => {
        if (err) console.log(err);
    })
}

module.exports = {
    readFile: readFile,
    writeFile: writeFile,
    appendFile: appendFile,
    deleteFile: deleteFile
}