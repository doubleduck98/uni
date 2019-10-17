function fib_rek(num) {
    if (num === 0) return 0;
    else if (num === 1) return 1;
    else return fib_rek(num - 1) + fib_rek(num - 2);
}

function fib_iter(num) {
    var nums = new Array(num + 1);
    nums[0] = 0;
    nums[1] = 1;
    for (var i = 2; i <= num; i++) {
        nums[i] = nums[i - 1] + nums[i - 2];
    }
    return nums[num];
}

function test_rek(n) {
    console.time("rek");
    console.log("test rek: " + n + ", " + fib_rek(n));
    console.timeEnd("rek");
}

function fn5() {
    for (var i = 10; i <= 40; i++) {
        console.time("iter");
        console.log("iter: " + i + ", " + fib_iter(i));
        console.timeEnd("iter");
        console.time("rek");
        console.log("rek: " + i + ", " + fib_rek(i));
        console.timeEnd("rek");
    }
}

test_rek(40)