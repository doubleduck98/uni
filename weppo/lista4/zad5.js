const readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
    terminal: false
});

console.log('jak sie nazywasz?')

rl.on('line', function (line) {
    console.log('witaj ' + line);
    rl.close();
});

// https://nodejs.org/api/readline.html#readline_event_close