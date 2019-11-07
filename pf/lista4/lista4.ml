(* SZYMON ZIENKIEWICZ *)
(* ZADANIE 1 *)

type 'a bt = Empty | Node of 'a * 'a bt * 'a bt;;

let t = Node(1, Node(2, Empty, Node(3, Empty, Empty)), Empty);;

let tt = Node(1, Node(2, Node(4, Empty, Empty), Empty), Node(3, Node(5, Empty, Node(6, Empty, Empty)), Empty));;

let rec sum = function
  Empty -> 0
| Node(v, left, right) -> v + sum left + sum right;;

sum t;;
sum tt;;

(* ZADANIE 2*)
let rec foldBT f acc tree = 
  match tree with
    Node(v, left, right) -> f v (foldBT f acc left, foldBT f acc right)
  | Empty -> acc;;

foldBT (fun x (l, r) -> x + l + r) 0 t;;
foldBT (fun x (l, r) -> x + l + r) 0 tt;;

(* ZADANIE 3*)
let sumBTfold tree =
  foldBT (fun x (l, r) -> x + l + r) 0 tree;;

sumBTfold t;;
sumBTfold tt;;

let inorderBTfold tree =
  foldBT (fun x (l, r) -> l @ x :: r) [] tree;;

inorderBTfold t;;
inorderBTfold tt;;

(* ZADANIE 4 *)
let mapBT f tree =
  foldBT

