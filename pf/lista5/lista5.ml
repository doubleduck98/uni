(* SZYMON ZIENKIEWICZ *)
type 'a llist = LNil | LCons of 'a * (unit -> 'a llist);;
type 'a lBT = LEmpty | LNode of 'a * ('a lBT Lazy.t) * ('a lBT Lazy.t);;

let rec lfrom k = LCons(k, fun() -> lfrom (k+1));;

let rec toLazyList = function [] -> LNil | x::xs -> LCons(x, function () -> toLazyList xs);;

let lhd = function LNil -> failwith "lhd" | LCons (x, _) -> x;;

let rec ltake = function
    (0, _) -> []
  | (_, LNil) -> []
  | (n, LCons(x,fx)) -> x::ltake(n-1, fx());;

(* ZADANIE 1 *)
let fibonacci =
  let rec fib prev current =
      let next = prev + current in
      LCons(prev, function() -> fib current next)
  in fib 0 1;;


ltake(10, fibonacci);;
ltake(0, fibonacci);;
ltake(1, fibonacci);;

(* ZADANIE 2 *)
let lrepeat f llista = 
  let rec lrep = function
    LCons(x, fx), element, 0 -> lrep(fx(), element+1, f (element+1))
  | LCons(x, fx) as ll, element, times -> LCons(x, function () -> lrep (ll, element, times-1))
  | LNil, _, _ -> LNil
in let x = lhd llista
in lrep (llista, x, f x);;

ltake(10, lrepeat (fun x -> 2) (lfrom 0));;
ltake(7, lrepeat (fun x -> x * 2) (lfrom 0));;
ltake(7, lrepeat (fun x-> x) (toLazyList [1; 2; 3]));;
ltake(997, lrepeat (fun x -> 5) (LCons(0, fun () -> LNil)));;

(* ZADANIE 3 *)
let sublist xs ll =
  let rec sbl = function    
      (_, LNil, _) -> LNil
    | ([], ll, _) -> ll
    | (h::t, LCons(x, fx), i) -> 
      if h = i
        then sbl(t, fx(), i+1)
        else LCons(x, function() -> sbl(h::t, fx(), i+1))
  in sbl(List.sort compare xs, ll, 0);;
                                   
ltake(10, sublist [1;4;7;2] (lfrom 10));;  
ltake(10, sublist [] (lfrom 10));;  
ltake(10, sublist [9; 8; 1; 0] (lfrom 1));;

(* ZADANIE 4 *)
let rec toLBST xs =
  let rec ins2LBST = function
    (k, LNode(x, l, r)) -> 
      if k < x then LNode(x, lazy(ins2LBST(k, Lazy.force l)), r)
      else LNode(x, l, lazy(ins2LBST(k, Lazy.force r)))
  | (k, LEmpty) -> LNode(k, lazy LEmpty, lazy LEmpty)
  in match xs with
    h::t -> ins2LBST(h, toLBST t)
  | [] -> LEmpty;;

let lbst = toLBST [9; 9; 7];;
let lbstt = toLBST [];;
let lbsttt = toLBST[-5; -4 ; 2; 1];;
let lbstttt = toLBST[4; 6; 5; 2; 3; 1];;

let inorder lbt =
  let rec ino = function
      (LEmpty, xs) -> xs
    | (LNode(x, l, r), xs) -> ino(Lazy.force l, x::ino(Lazy.force r, xs))
  in ino(lbt, []);;

inorder (lbst);;
inorder (lbstt);;
inorder (lbsttt);;
inorder (lbstttt);;