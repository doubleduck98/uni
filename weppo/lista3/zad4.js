function createFs1(n) { // tworzy tablicę n funkcji
    var fs = []; // i-ta funkcja z tablicy ma zwrócić i
    for (let i = 0; i < n; i++) {
        fs[i] =
            function () {
                return i;
            };
    };
    return fs;
}

var myfs = createFs1(10);
console.log(myfs[0]()); // zerowa funkcja miała zwrócić 0
console.log(myfs[2]()); // druga miała zwrócić 2
console.log(myfs[7]());

function createFs2(n) {
    var fs = [];

    function fn(i) {
        return function () {
            return i;
        }
    }

    for (var i = 0; i < n; i++) {
        fs[i] = fn(i);
    };
    return fs;
}

var myfs = createFs2(10);
console.log(myfs[0]());
console.log(myfs[2]());
console.log(myfs[7]());