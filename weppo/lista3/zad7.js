function fib() {
    var mem = [0, 1];
    return {
        next: function () {
            mem = [mem[1], mem[0] + mem[1]];
            return {
                value: mem[0],
                done: false
            }
        }
    }
}

function* fib() {
    var mem = [0, 1];
    while (true) {
        yield mem[0];
        mem = [mem[1], mem[0] + mem[1]];
    }
}

var _it = fib();
for (var _result; _result = _it.next(), !_result.done;) {
    if (_result.value > 1000)
        break;
    console.log(_result.value);
}

for (var i of fib()) {
    if (i > 50)
        break;
    console.log(i);
}