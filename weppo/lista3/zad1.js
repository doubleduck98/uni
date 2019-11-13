var obj1 = {
    x: 71,
    wypiszx: function () {
        console.log(this.x);
    },
    set ustawx(nx) {
        this.x = nx;
    },
    get zwrocx() {
        return this.x;
    }
}

console.log(obj1.zwrocx);
obj1.ustawx = 42;
obj1.wypiszx();

var obj2 = {}

obj2.a = 2;
obj2.fn = () => {
    console.log('jestem funkcja');
}
Object.defineProperty(obj2, 'property', {
    enumerable: true,
    value: 42,
    get wartosc(){
        return value;
    },
    set ustaw(nv){
        value = nv;
    }
});
console.log(obj2);