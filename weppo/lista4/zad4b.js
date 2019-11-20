module.exports = { test_b };

const a = require('./zad4a.js')

function test_b() {
    return true;
}

function b () {
    console.log('tutaj b!')
    if(a.test_a()){
        console.log('czesc a!')
    }
}