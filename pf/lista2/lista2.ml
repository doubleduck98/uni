(* SZYMON ZIENKIEWICZ *)
(* ZADANIE 1 *)
let time f x =
  let t = Sys.time()
  and fx = f x
  in let _ = Printf.printf "Czas wykonania: %fs\n" (Sys.time() -. t)
    in fx;;

let rec fib_bad i =
  match i with
    0 -> 0
  | 1 -> 1
  | _ -> fib_bad (i-1) + fib_bad (i-2);;

let fib_good i =
  let rec fib j acc1 acc2 =
    if j = i then acc2
    else fib (j+1) (acc1 + acc2) acc1 in
  fib 0 1 0;;

time fib_good 42;;
time fib_bad 42;;

(* ZADANIE 2 *)
let root3 a =
  let epsilon = 1e-55 in
  let czy_dobra x =
    abs_float((x *. x *. x) -. a) <= abs_float(a) *. epsilon in
  let rec prw x =
    if czy_dobra x then x
    else prw (x +. (a /. (x *. x) -. x) /. 3.0) in
  prw a;;

root3 (-8.0);;
root3 27.0;;
root3 15.0;;

(* ZADANIE 3 *)
let (<->) (x1, y1, z1) (x2, y2, z2) =
  sqrt(
    (x1 -. x2) *. (x1 -. x2)
    +. (y1 -. y2) *. (y1 -. y2)
    +. (z1 -. z2) *. (z1 -. z2)
  );;

(1., 1., 1.) <-> (1., 1., 0.);;
(2., 5., 7.) <-> (1., 4., 6.);;
(0., 0., 0.) <-> (0., 0., 0.);;

(* ZADANIE 4 *)
let (<--) lista n =
  let rec ins low high =
    if high = [] then List.rev (n :: low)
    else if (List.hd high) > n then List.rev (n :: low) @ high
    else ins ((List.hd high) :: low) (List.tl high) in
  ins [] lista;;

[1; 2; 3; 4; 5] <-- 3;;
['a'; 'b'; 'd']  <-- 'c';;
[4; 5; 6; 7] <-- 1;;
[] <-- 71;;
[1; 2; 3] <-- 4;;
[-4.; -2.; -1.] <-- -3.;;