(*SZYMON ZIENKIEWICZ *)
(* ZADANIE 1 *)
let f1 (x, y) = 
  (x + y, x + y);;

let f2 (x, y) = 
  x +. y == x +. y;;

let f3 (x, y) =
    if y+y = 1
      then List.hd x :: []
      else List.hd x :: [];;

(* ZADANIE 2 *)
let ends lista =  
  let rec hlp2 l =
    if List.tl l = [] 
      then List.hd l
      else hlp2 (List.tl l) in
  if lista = [] then failwith("pusta lista!")
  else if (List.tl lista) = [] then (List.hd lista, List.hd lista)
  else ((List.hd lista), hlp2 (List.tl lista));;

ends [1; 2; 3; 4; 5];;
ends ["haha"; "hehe"; "hihi"];;
ends [];;
ends [52; 12; 4124; 8757853; 1; 12];;
ends [42];;

(* ZADANIE 3 *)
let isSorted list =
  let rec hlp3 lista last =
    if List.tl lista = [] then true
    else if last <= List.hd lista then hlp3 (List.tl lista) (List.hd lista)
    else false in
  if list = [] then true
  else if (List.tl list) = [] then true
  else hlp3 (List.tl list) (List.hd list);;

isSorted [1; 2; 3; 3; 5];;
isSorted [5; 4; 3; 2; 1];;
isSorted [1; 2; 4; 3; 5];;
isSorted [];;
isSorted [5];;
isSorted ["a"; "b"; "c"; "z"];;

(* ZADANIE 4 *)
let powers n e = 
  let rec pow x a =
    if a = 0 then 1
    else if a = 1 then x
    else x * pow x (a - 1) in 
  let rec hlp curr res =
    if curr < 0 then res
    else hlp (curr - 1) (pow n curr :: res) in
  hlp e [];;
    
powers 2 3;;    
powers 5 5;;    
powers 5 1;;    
powers 1 0;;
powers 3 16;;

(* ZADANIE 5 *)
let reverse lista =
  let rec hlp l res = 
    if l = [] then res
    else hlp (List.tl l) ((List.hd l) :: res) in
  hlp lista [];;

let split (lista,  x) =
  let rec hlp l low high =
    if l = [] then (reverse low), (reverse high)
    else if List.hd l <= x then hlp (List.tl l) (List.hd l :: low) high
    else hlp (List.tl l) low (List.hd l :: high) in
  hlp lista [] [];;

split (['a'; 's'; 'h'; 'g'], 'g');;
split ([1; 2; 3; 4; 5; 6], 4);;
split ([1; 1; 1; 1; 1; 1], 4);;
split ([5; 5; 5; 5; 5; 5], 4);;
split (['o'; 'c'; 'a'; 'm'; 'l'], 'h');;

(* ZADANIE 6 *)
let segments (lista, x) =
  let rec hlp l res i curr = 
    if l = [] then reverse (reverse i :: res)
    else if curr = 0 then hlp l (reverse i :: res) [] x
    else hlp (List.tl l) res (List.hd l :: i) (curr - 1) in
  hlp lista [] [] x;;

segments ([1; 2; 1; 2; 1; 2; 1], 2);;
segments ([1; 2; 3; 4; 5; 6; 7; 8; 9], 2);;
segments ([1; 2; 3; 1; 2; 3; 1; 2], 3);;
segments ([], 5);;
segments (['a'; 'b'; 'a'; 'b'; 'a'], 2);; 

(* ZADANIE 7 *)
let swap (lista, x) = 
  let rec hlp l a curr =
    if l = [] then lista
    else if curr = x then l @ (reverse a)
    else hlp (List.tl l) ((List.hd l) :: a) (curr + 1) in
  hlp lista [] 0;;

  swap (["a"; "b"; "5"; "6"], 2);;
  swap (["a"; "b"; "5"; "6"], 5);;
  swap (["a"; "b"; "5"; "6"], 0);;
  swap ([1; 2; 3; 4; 5; 6; 7], 5);;
  swap ([1; 2; 3; 4; 5; 6; 7], 1);;