const fs = require('fs');

fs.readFile('./lista4/tekst.txt', (err, data) => {
    // relative path zaleznie gdzie vscode odpale, process.cwd()
    if (err) throw err;
    console.log(data.toString());
});