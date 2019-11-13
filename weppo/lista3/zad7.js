function fibIt() {
    var mem = [0, 1];
    return {
        next: function () {
            mem = [mem[1], mem[0] + mem[1]];
            return {
                value: mem[0],
                done: false,
            }
        }
    }
}
var it = fibIt();
for (var _result; _result = it.next(), !_result.done;) {
    if (_result.value > 50)
        break;
    console.log(_result.value);
}

//var it = { [Symbol.iterator]: fibIt }

/* for (var i of it) {
    if (i < 50)
        console.log(i);
    else break;
} */

//z gwiazdką tzn ze zwraca generator
function* fibGen() {
    var mem = [0, 1];
    while (true) {
        yield mem[0];
        mem = [mem[1], mem[0] + mem[1]];
    }
}

var gen = fibGen();
for (var _result; _result = gen.next(), !_result.done;) {
    if (_result.value > 50)
        break;
    console.log(_result.value);
}

for (var i of fibGen()) {
    if (i < 50)
        console.log(i);
    else break;
}