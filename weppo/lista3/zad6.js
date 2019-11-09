function generator(n) {
    return function createGenerator() {
        var _state = 0;
        return {
            next: function () {
                return {
                    value: _state,
                    done: _state++ >= n
                }
            }
        }
    }
}

var foo = {
    [Symbol.iterator]: generator(20)
};

var foo1 = {
    [Symbol.iterator]: generator(71)
};

var foo2 = {
    [Symbol.iterator]: generator(42)
}

for (var f of foo)
    console.log(f);

for (var f of foo1)
    console.log(f);

for (var f of foo2)
    console.log(f);