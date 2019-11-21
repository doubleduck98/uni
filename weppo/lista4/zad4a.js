module.exports = { a }

const b = require('./zad4b.js')

function a(n) {
    if (n >= 0) {
        console.log('tutaj a!')
        b.b(n - 1);
    }
    return;
}