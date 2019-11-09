function* fib() {
    var mem = [0, 1];
    while (true) {
        yield mem[0];
        mem = [mem[1], mem[0] + mem[1]];
    }
}

function* take(it, top) {
    for (let i = 0; i < top; i++) {
        yield it.next().value
    }
}


for (let num of take(fib(), 5)) {
    console.log(num);
}