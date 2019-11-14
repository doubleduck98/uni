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
  foldBT (fun x (l, r) -> Node(f x, l, r)) Empty tree;;

mapBT (fun v -> 2*v) (Node(2, Node (4, Empty, Node (6, Empty, Empty)), Empty));;
mapBT (fun v -> 2*v) t;;
mapBT (fun v -> 5) tt;;

(* ZADANIE 5 *)
type 'a tree = L of 'a | N of 'a tree * 'a tree;;

let store tree =
  let rec str = function
      L(x), xs -> Some x::xs
    | N(l, r), xs -> str(l, str(r, None::xs))
  in str (tree, []);;

let d = N(L 1, N(L 2, L 3));;
let dd = N(N(L 1, N(L 4,L 5)), L 3);;
let ddd = N(N(N(L 1,L 2),N(L 3, L 4)),N(N(L 5, L 6),N(L 7, L 8)));;

store d;;
store dd;;
store ddd;;

(* ZADANIE 6 *)
let load lista =
  let rec ld lst stos =
    match lst with
      [] -> if List.length stos = 1 then List.hd stos else failwith "Load"
    | Some x::xs -> ld xs (L x :: stos)
    | None::xs ->
      match stos with
        r::l::tl -> ld xs (N(l, r) :: tl)
      | [] | [_] -> failwith "Load"
  in ld lista [];;

load (store d);;
load (store dd);;
load (store ddd);;
load [None; None];;
load [Some 1; Some 2; None; Some 3];;