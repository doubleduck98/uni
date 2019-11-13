var Tree = function (v, l, r) {
    this.val = v;
    this.left = l;
    this.right = r;
}

function* treeGen(tree) {
    if (tree == null)
        return;
    if (tree.left != null)
        yield* treeGen(tree.left);
    if (tree.val != null)
        yield tree.val;
    if (tree.left != null)
        yield* treeGen(tree.right);
}

let root = treeGen(
    new Tree(1,
        new Tree(2,
            new Tree(3, null, null),
            null),
        new Tree(2, null, null)));

for (var e of root) {
    console.log(e);
}