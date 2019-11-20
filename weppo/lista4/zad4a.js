module.exports = { test_a };
module.exports = { a }

const b = require('./zad4b.js')

function test_a() {
    return true;
}

function a() {
    console.log('tutaj a!')
    if (b.test_b()) {
        console.log('czesc b!')
    }
}