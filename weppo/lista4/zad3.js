var Foo = function () {
    console.log('tu foo');
}

Foo.prototype.Bar = function () {
    function Qux() {
        console.log('tu qux');
    }
    Qux();
    console.log('tu bar');
}

var x = new Foo();

x.Bar();
// x.Qux(); // error daje