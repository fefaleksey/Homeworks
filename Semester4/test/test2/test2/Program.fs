module test2

// --------------------- 1 --------------------------
let supermap list (funcList : ('a -> 'b) list)= 
    let rec concatStep value funcList rez =
        match funcList with
        | head :: tail -> concatStep value tail ( (head value) :: rez)
        | [] -> rez
    let rec solve list funcList rez = 
        match list with
        | head :: tail -> solve tail funcList (concatStep head funcList rez)
        | [] -> rez
    solve list funcList [] |> List.rev
    
// --------------------- 2 --------------------------

open System

type Queue(queueList, priorityList) =
    let queue = queueList
    let priorities = priorityList
    
    let maxPrioriry _ = 
        let rec find list max=
            match list with
            | head :: tail -> if head > max then find tail head else find tail max
            | [] -> max
        if queue = [] then failwith("queue is empty") else find (List.tail priorities) (List.head priorities)
    
    let delete _ =
        let priority = maxPrioriry()
        let rec concat list1 list2 = 
            match list1 with
            | h :: t -> concat t (h :: list2)
            | [] -> list2
        let rec get queueList prioritiesList newQueue newPriorities =
            match prioritiesList with
            | head :: tail -> 
                if head = priority then Queue(concat (List.tail queueList) newQueue, concat tail newPriorities) 
                else get (List.tail queueList) tail (List.head queueList :: newQueue) (head :: newPriorities)
            | [] -> failwith("queue error") //it's impossible
        get (List.rev queue) (List.rev priorities) [] []
    
    let get _ =
        let priority = maxPrioriry()
        let rec get queueList prioritiesList newQueue newPriorities =
            match prioritiesList with
            | head :: tail -> 
                if head = priority then List.head queueList
                else get (List.tail queueList) tail (List.head queueList :: newQueue) (head :: newPriorities)
            | [] -> failwith("queue error") //it's impossible
        get (List.rev queue) (List.rev priorities) [] []
    
    /// <summary>delete max priority element</summary>
    ///<returns>The New Queue</returns>
    ///<exception cref="failwith">Something went wrong</exception>
    member this.DeleteMaxPriorityElement = delete()
    
    /// <summary>delete max priority element</summary>
    ///<returns>The New Queue</returns>
    ///<exception cref="failwith">queue is empty</exception>
    member this.GetMaxPriorityElement = get()
    
    /// <summary>Add new element</summary>
    ///<param name="value">New value</param>
    ///<param name="priority">New priority</param>
    ///<returns>New Queue</returns>
    member this.Add (value : IComparable) priority = Queue(value :: queue, priority :: priorities)
    
[<EntryPoint>]
let main argv =
    0 
