var Tree = function (v, l, r) {
    this.val = v;
    this.left = l;
    this.right = r;
}

let t =
    new Tree(1,
        new Tree(2,
            new Tree(3, null, null),
            null),
        new Tree(2, null, null));

console.log(t);