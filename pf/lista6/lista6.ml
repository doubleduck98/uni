(* SZYMON ZIENKIEWICZ *)
(* ZADANIE 1 *)
let zgadnij ()=
  let warunek = ref true in
  let liczba = Random.int 101 in
  while !warunek do
    let i = read_int () in
    if liczba = i 
      then begin
        warunek := false;
        print_string "Zgadles. Brawo!";
        print_newline();
      end
    else if liczba < i
      then begin
        print_string "Moja jest mniejsza.";
        print_newline ();
      end
    else begin
      print_string "Moja jest większa.";
      print_newline();
    end
  done;;

zgadnij ();;

(* ZADANIE 2 *)
type 'a bt = Empty | Node of 'a * 'a bt * 'a bt;;

let t = Node(1, Node(2, Empty, Node(3, Empty, Empty)), Empty);;
let tt = Node(1, Node(2, Node(4, Empty, Empty), Empty), Node(3, Node(5, Empty, Node(6, Empty, Empty)), Empty));;

let printBT tree =
  let kropki n =
    for i = 0 to n do
      print_string ".."
    done; in
  let rec prnt tree i =
    begin
      match tree with
        Empty ->
          kropki (i-1);
          print_string "||";
      | Node(v, l, r) ->
          prnt r (i+1);
          print_newline();
          kropki (i-1);
          print_int v;
          print_newline();
          prnt l (i+1);
    end
  in prnt tree 0; 
  print_newline();;

printBT t;;
printBT tt;;
printBT Empty;;

