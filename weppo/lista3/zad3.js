function forEach(a, f) {
    for (let i = 0; i < a.length; i++) {
        f(a[i]);
    }
}

function map(a, f) {
    for (let i = 0; i < a.length; i++) {
        a[i] = f(a[i]);
    }
}

function filter(a, f) {
    res = Array();
    for (let i = 0; i < a.length; i++) {
        if (f(a[i]))
            res.push(a[i]);
    }
    return res;
}

var a = [1, 2, 3, 4];
forEach(a, _ => { console.log(_); });
console.log(filter(a, _ => _ < 3));
map(a, _ => _ * 2);
console.log(a);
map(a, function (x) {
    return x/2;
})
console.log(a)