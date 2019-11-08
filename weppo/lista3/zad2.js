function fib_rek(num) {
    if (num === 0) return 0;
    else if (num === 1) return 1;
    else return fib_rek(num - 1) + fib_rek(num - 2);
}

let cache = {};

function fib_mem(num) {
    if (num === 0) return 0;
    else if (num === 1) return 1;
    else {
        if (num in cache) return cache[num];
        else {
            let res = fib_mem(num - 1) + fib_mem(num - 2);
            cache[num] = res;
            return res;
        }
    }
}

function fn() {
    for (let i = 35; i <= 42; i++) {
        console.time("rec");
        fib_rek(i);
        console.timeEnd("rec");
    }
    for (let i = 35; i <= 42; i++) {
        console.time("mem");
        fib_mem(i);
        console.timeEnd("mem");
    }
}

fn();
