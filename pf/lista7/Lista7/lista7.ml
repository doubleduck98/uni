(* SZYMON ZIENKIEWICZ *)
(* ZADANIE 4 *)
(* NIEDOKOŃCZONE *)
module type DICTIONARY =
  sig
    type key (* type of keys *)
    type 'a t (* type of dictionaries *)
    exception DuplicatedKey of key (* error in insert *)
    val empty: unit -> 'a t (* empty dictionary *)
    val lookup: 'a t -> key -> 'a option
    val insert: 'a t -> key * 'a -> 'a t
    val delete: 'a t -> key -> 'a t
    val update: 'a t -> key * 'a -> 'a t (* not necessary *)
  end;;

type ordering = LT | EQ | GT;;

module type ORDER =
  sig
    type t
    val compare: t -> t -> ordering
  end;;

module Comp : ORDER =
    struct
      type t

module Slownik(Key: ORDER) : DICTIONARY with type key = Key.t =
    struct
      type key = Key.t

      type 'a t = (key * 'a) list

      exception DuplicatedKey of key

      let empty() = []

      let rec lookup dict key =
        match (dict, key) with
          ([], sk) -> None
        | (k, v)::d, sk ->
          if k = sk then Some v
          else lookup (d, sk)

      let insert dict new_pair =
        let comp p1 p2 =
          if fst p1 < fst p2
            then -1
          else if fst p1 = fst p2
            then 0
          else 1 in
        let eq pair =
          fst pair = fst new_pair in
        if List.exists eq dict 
          then raise (DuplicatedKey (fst new_pair))
          else List.sort comp (new_pair :: dict)

      let rec delete = function
          ([], k) -> []
        | ((k, v)::d, sk) -> 
          if k = sk then d
          else (k, v)::delete(d, k)

      let rec update = function
          ([], k) -> []
        | ((k, v)::d, (sk, nv)) ->
          if k = sk then (sk, nv)::d
          else (k, v)::update(d, (sk, nv))

    end;;