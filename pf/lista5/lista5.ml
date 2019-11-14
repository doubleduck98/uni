(* SZYMON ZIENKIEWICZ *)
type 'a llist = LNil | LCons of 'a * (unit -> 'a llist);;
type 'a lBT = LEmpty | LNode of 'a * ('a lBT Lazy.t) * ('a lBT Lazy.t);;

let rec lfrom k = LCons(k, fun() -> lfrom (k+1));;

let rec toLazyList = function [] -> LNil | x::xs -> LCons(x, function () -> toLazyList xs);;

let lhd = function LNil -> failwith "lhd" | LCons (x, _) -> x;;

let rec ltake = function
    (0, _) -> []
  | (_, LNil) -> []
  | (n, LCons(x,xf)) -> x::ltake(n-1, xf());;

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


