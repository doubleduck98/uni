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

module StringOrder : ORDER with type t = string =
    struct
      type t = string

      let compare a b =
        if a < b then  LT
        else if a = b then EQ
        else GT
    end;;

module IntOrder : ORDER with type t = int =
    struct
      type t = int

      let compare a b =
        if a < b then  LT
        else if a <> b then EQ
        else GT
    end;;
    
module FloatOrder : ORDER with type t = float =
    struct
      type t = float

      let compare a b =
        if a < b then  LT
        else if a = b then EQ
        else GT
    end;;

module CharOrder : ORDER with type t = char =
    struct
      type t = char

      let compare a b =
        if a < b then  LT
        else if a = b then EQ
        else GT
    end;;


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
        else lookup d sk

    let rec insert dict new_pair =
      if dict = [] then [new_pair]
      else
        match Key.compare (fst(List.hd dict)) (fst(new_pair)) with
            LT -> new_pair::dict
          | GT -> (List.hd dict)::insert (List.tl dict) new_pair
          | EQ -> raise (DuplicatedKey (fst new_pair))

    let rec delete dict key =
      match (dict, key) with
        ([], k) -> []
      | ((k, v)::d, sk) -> 
        if k = sk then d
        else (k, v)::delete d sk

    let rec update dict new_pair =
      match (dict, new_pair) with
        ([], k) -> []
      | ((k, v)::d, (sk, nv)) ->
        if k = sk then (sk, nv)::d
        else (k, v)::update d new_pair

  end;;

module StringDict = Slownik(StringOrder);;
let d = StringDict.empty();;
let ( <| ) d (k,x) = StringDict.insert d (k,x);;

let d = d <| ("jp", 997) <| ("essa", 4);;
StringDict.lookup d "jp";;