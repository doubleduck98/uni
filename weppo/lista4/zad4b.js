module.exports = { b };

const a = require('./zad4a.js')

function b(n) {
    if (n >= 0) {
        console.log('tutaj b!');
        a.a(n - 1);
    }
    return;
}