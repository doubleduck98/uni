(* SZYMON ZIENKIEWICZ *)
module type QUEUE_FUN =
sig
  (* Module [QueueFun]: first-in first-out queues *)

  (* This module implements queues (FIFOs)in a functional way. *)

  type 'a t
        (* The type of queues containing elements of type ['a]. *)
  exception Empty of string
        (* Raised when [first] is applied to an empty queue. *)
  val create: unit -> 'a t
        (* Return a new queue, initially empty. *)
  val enqueue: 'a * 'a t -> 'a t
        (* [enqueue x q] adds the element [x] at the end of queue [q]. *)
  val dequeue: 'a t -> 'a t
        (* [dequeue q] removes the first element in queue [q] *)        
  val first: 'a t -> 'a
        (* [first q] returns the first element in queue [q] without removing  
           it from the queue, or raises [Empty] if the queue is empty.*) 
  val isEmpty: 'a t -> bool
        (* [isEmpty q] returns [true] if queue [q] is empty, 
           otherwise returns [false]. *)
end;;

(* ZADANIE 1  *)
module QueueA : QUEUE_FUN =
  struct
    type 'a t = EmptyQueue | Enqueue of 'a * 'a t
                                      
    exception Empty of string
                     
    let create() = EmptyQueue
                 
    let rec enqueue = function
        (x, EmptyQueue) -> Enqueue(x, EmptyQueue)
      | (x, Enqueue(y, q)) -> Enqueue(y, enqueue(x, q))
                      
    let dequeue = function
        EmptyQueue -> EmptyQueue
      | Enqueue(_, q) -> q
                       
    let first = function
        EmptyQueue -> raise (Empty "kolejka jest pusta")
      | Enqueue(x, _) -> x
                       
    let isEmpty q = 
      q = EmptyQueue
  end;;

QueueA.(isEmpty(enqueue(1, create())));;
QueueA.(isEmpty(create()));;
QueueA.(first(dequeue(enqueue(1, enqueue(2, create())))));;
QueueA.(first(enqueue(1, dequeue(enqueue(2, create())))));;

module QueueB : QUEUE_FUN =
  struct
    type 'a t = 'a list

    exception Empty of string

    let create() = []

    let enqueue(x, q) = q @ [x]

    let dequeue = function
        [] -> []
      | h::t -> t

    let first = function
        [] -> raise (Empty "kolejka jest pusta")
      | h::t -> h
      
    let isEmpty q = 
      q = []
  end;;

QueueB.(isEmpty(enqueue(1, create())));;
QueueB.(isEmpty(create()));;
QueueB.(first(dequeue(enqueue(1, enqueue(2, create())))));;
QueueB.(first(enqueue(1, dequeue(enqueue(2, create())))));;

module QueueC : QUEUE_FUN =
  struct
    type 'a t = 'a list * 'a list

    exception Empty of string

    let create() = [], []

    let rec enqueue = function
        (y, ([], [])) -> (y::[], [])
      | (y, ([], ys)) -> enqueue(y, (List.rev ys, []))
      | (y, (xs, ys)) -> (xs, y::ys)

    let rec dequeue = function
        ([], []) -> ([], [])
      | (x::[], ys) -> (List.rev ys, [])
      | (x::xs, ys) -> (xs, ys)
      | ([], ys) -> (List.rev ys, [])

    let first = function
        (y::xs, ys) -> y
      | ([], _) -> raise (Empty "kolejka jest pusta")

    let isEmpty q = 
      q = ([], [])
  end;;

QueueC.(isEmpty(enqueue(1, create())));;
QueueC.(isEmpty(create()));;
QueueC.(first(dequeue(enqueue(1, enqueue(2, create())))));;
QueueC.(first(enqueue(1, dequeue(enqueue(2, create())))));;
