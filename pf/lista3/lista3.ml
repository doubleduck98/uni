(* SZYMON ZIENKIEWICZ *)
(* ZADANIE 1 *)
let curry3 f x y z = f (x, y ,z);;
let curry3_ = 
  function f -> function x -> function y -> function z ->
  f (x, y, z);;
let uncurry3 f (x, y, z) = f x y z;;
let uncurry3_ =
  function f -> function (x, y, z) ->
  f x y z;;

(* ZADANIE 2 *)
let rec czyIstnieje1 f lista =
    match lista with
      [] -> false
    | h::t -> f h || czyIstnieje1 f t;;

czyIstnieje1 (function x -> x = 2) [1; 2; 3; 5];;
czyIstnieje1 (function x -> x = 'm') ['o'; 'c'; 'a'; 'm'; 'l'];;
czyIstnieje1 (function x -> x = 4) [1; 2; 3; 5];;
czyIstnieje1 (function x -> x = 71) [];;

let rec czyIstnieje2 f lista = 
  List.fold_left (fun x y -> x || f y) false lista;;

czyIstnieje2 (function x -> x = 2) [1; 2; 3; 5];;
czyIstnieje2 (function x -> x = 'm') ['o'; 'c'; 'a'; 'm'; 'l'];;
czyIstnieje2 (function x -> x = 4) [1; 2; 3; 5];;
czyIstnieje2 (function x -> x = 71) [];;

let rec czyIstnieje3 f lista =
  List.fold_right (fun x -> y || f x) lista false;;

czyIstnieje3 (function x -> x = 2) [1; 2; 3; 5];;
czyIstnieje3 (function x -> x = 'm') ['o'; 'c'; 'a'; 'm'; 'l'];;
czyIstnieje3 (function x -> x = 4) [1; 2; 3; 5];;
czyIstnieje3 (function x -> x = 71) [];;

(* ZADANIE 3 *)
let filter f lista =
  List.fold_right (fun x xs -> if f x then x::xs else xs) lista [];;

filter (function x -> x = 2) [1; 1; 1; 2; 1; 2];;
filter (function x -> x >= 5) [1; 2; 3; 4; 5; 6; 7; 8];;
filter (function x -> x = 2) [];; 
filter (function x -> x = 'e' || x = 's' || x = 'a') ['c'; 'b'; 'e'; 'm'; 's'; 'd'; 's'; 'v'; 'a'];;


(* ZADANIE 4 *)
let usun1 f lista =
  match lista with
    [] -> []
  | x::xs -> if f x then xs
             else x::(usun1 f xs);;

let usun2 f lista =
  let rec usn lst acc =
    match lst with
      [] -> List.rev acc
    | x::xs -> if f x then List.rev_append acc xs 
               else usn xs (x :: acc)
  in usn lista [];;

usun1 (function x -> x = 2) [1; 2; 3; 2; 5];;
usun1 (function x -> x = 2) [1; 3; 4; 5; 6; 7];;
usun1 (function x -> x = 'o') ['o'; 'c'; 'a'; 'm'; 'l'];;
usun1 (function x -> x = 71) [];;

usun2 (function x -> x = 2) [1; 2; 3; 2; 5];;
usun2 (function x -> x = 2) [1; 3; 4; 5; 6; 7];;
usun2 (function x -> x = 'o') ['o'; 'c'; 'a'; 'm'; 'l'];;
usun2 (function x -> x = 71) [];;

(* ZADANIE 5 *)
let merge f lista1 lista2 =
  let rec mrg l1 l2 res =
    match l1, l2 with
      [], [] -> List.rev res
    | xs, [] -> (List.rev res) @ xs
    | [], ys -> (List.rev res) @ ys
    | (x::xs as l1), (y::ys as l2) -> if f x y then mrg xs l2 (x::res)
                                      else mrg l1 ys (y::res)
  in mrg lista1 lista2 [];;

let rec split lista =
  match lista with
      [] -> [], []
    | [_] as t1 -> t1, []
    | h::t -> let t1, t2 = split t in h::t2, t1;;


let rec merge_sort f lista =
  match lista with
    [] -> []
  | [_] as list -> list
  | list -> let l1, l2 = split list 
in merge f (merge_sort f l1) (merge_sort f l2);;


merge_sort (fun x y -> x <= y) [6; 7; 0; 8; 3; 2; 4; 9; 5; 1];;
merge_sort (fun x y -> x <= y) [];;
merge_sort (fun x y -> x <= y) ['d'; 'b'; 'e'; 'a'; 'c'];;
merge_sort (fun (a, b) (c, d) -> a <= c) [(1, 1); (2, 0); (5, 0); (4, 0); (1, 2)];;
merge_sort (fun (a, b) (c, d) -> a = c) [(1, 1); (2, 0); (5, 0); (4, 0); (1, 2)];;