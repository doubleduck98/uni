const fs = require('fs');
const readline = require('readline');

var rl = readline.createInterface({
    input: fs.createReadStream('./lista4/logi.txt')
})

let ipmap = new Map();

rl.on('line', (input) => {
    let ip = input.split(' ')[0];
    if (ip in ipmap)
        ipmap[ip] += 1;
    else ipmap[ip] = 1;
});

rl.on('close', () => {
    rl.close();
    var sorted = Object.entries(ipmap).sort((a, b) => {
        return b[1] - a[1];
    });
    console.log(sorted[0]);
    console.log(sorted[1]);
    console.log(sorted[2]);
});
