var obj = {
    licznik: 1,
    get ile() {
        return this.licznik;
    },
    set ustaw(x) {
        this.licznik = x;
    },
    opis: function () {
        console.log(this.licznik);
    }
}

obj.opis();
console.log(obj.licznik);
obj.ustaw = 15;
console.log(obj.ile);


Object.defineProperty(obj, 'nazwa', {
    get() { return this.value; },
    set(nowaNazwa) { value = nowaNazwa; }
})

Object.defineProperty(obj, 'xd', {
    /*true if and only if the type of this property descriptor 
    may be changed and if the property may be deleted from the corresponding object.*/
    configurable: true,
    /*true if and only if this property shows up during enumeration
    of the properties on the corresponding object.*/
    enumerable: true,
    /*true if and only if the value associated with the
    property may be changed with an assignment operator.*/
    writable: true,
    value: 5
})

obj.nowaNazwa = 'essa';
console.log(obj.nowaNazwa);
console.log(obj.xd)

//TODO: dla metody jeszcze