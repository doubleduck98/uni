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