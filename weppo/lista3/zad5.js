function sum() {
    let res = 0;
    for(let i = 0; i < arguments.length; i++)
        res += arguments[i];
    return res
}

function sum2(...args) {
    let res = 0;
    for(let i = 0; i < args.length; i++)
        res += args[i];
    return res
}

console.log(sum(1, 2, 3));
console.log(sum2(1, 2, 3));