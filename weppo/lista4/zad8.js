const fs = require('fs');
const util = require('util');

// callbacki
fs.readFile('./lista4/8a.txt', function (err, dataA) {
    readB(dataA);
});

function readB(dataA) {
    fs.readFile('./lista4/8b.txt', function (err, dataB) {
        console.log('callbacki:')
        console.log(dataA.toString());
        console.log(dataB.toString());
    });
}


// Promise
function promise(path) {
    return new Promise((result, rejected) => {
        fs.readFile(path, (err, data) => {
            if (err)
                rejected(err);
            result(data);
        });
    });
}

promise('./lista4/8a.txt')
    .then(dataA => {
        promise('./lista4/8b.txt')
            .then(dataB => {
                console.log('promise:')
                console.log(dataA.toString());
                console.log(dataB.toString());
            });
    });

// util.promisify
const rf = util.promisify(fs.readFile);
rf('./lista4/8a.txt')
    .then(dataA => {
        rf('./lista4/8b.txt')
            .then(dataB => {
                console.log('promisify:');
                console.log(dataA.toString())
                console.log(dataB.toString())
            })
            .catch(error => {
                console.log(error);
            });
    })
    .catch(error => {
        console.log(error);
    });

// fs.promises
const fspr = require('fs').promises;
fspr.readFile('./lista4/8a.txt')
    .then(dataA => {
        fspr.readFile('./lista4/8b.txt')
            .then(dataB => {
                console.log('fs.promises:');
                console.log(dataA.toString())
                console.log(dataB.toString())
            })
            .catch(error => {
                console.log(error);
            });
    })
    .catch(error => {
        console.log(error);
    });

// async/await
async function foo() {
    let a = await promise('./lista4/8a.txt');
    let b = await promise('./lista4/8b.txt');

    console.log('async/await:');
    console.log(a.toString());
    console.log(b.toString());
}

foo();