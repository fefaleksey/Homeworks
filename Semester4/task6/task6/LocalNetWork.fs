namespace LNW

open System
module solve =

    type IGenerator = 
        abstract member GetNumber : float
    /// <summary>
    /// Random number generator
    /// </summary>
    type RandomGenerator() =
        let _random = new Random()
        /// <summary>
        /// Get new random number
        /// </summary>
        /// <returns>New random number</returns>
        interface IGenerator with 
            member this.GetNumber = 
                _random.NextDouble()
    /// <summary>
    /// Not randomly number generator for tests
    /// </summary>
    type DefinedGenerator(arrayOfRandom : double[]) =
        let _arrayOfRandom = arrayOfRandom
        let mutable _pointer = -1;
        
        /// <summary>
        /// Get new random number
        /// </summary>
        /// <returns>New random number</returns>
        interface IGenerator with 
            member this.GetNumber =
                _pointer <- _pointer + 1
                if _pointer = _arrayOfRandom.Length then _pointer <- 0
                _arrayOfRandom.[_pointer]
    
    /// <summary>
    /// Operation system
    /// </summary>
    type OS = {
        name : string; 
        probabilityOfInfection : double
    }
    type Computer (os : OS, isInfected : bool, random : IGenerator) = 
        let mutable infected = isInfected
        member computer.Infected
            with get() = infected
        member c.TryToInfect =
            let value = random.GetNumber
            infected <- (os.probabilityOfInfection >= value)   
    type Network(computers : array<Computer>, matrix : array<array<bool>>) =
        let mutable computers = computers
        let mutable indexInfected = List.empty
        let updateInfected (ls : list<int>) (i : int) =
            if (computers.[i].Infected) then (i :: ls) else ls
        do
            for i in [0..computers.Length - 1] do
                indexInfected <- updateInfected indexInfected i
        /// <summary>
        /// Next step
        /// </summary>
        member n.MakeStep = 
            for i in [0..indexInfected.Length - 1] do
                    for j in [0..computers.Length - 1] do
                        if (not computers.[j].Infected && matrix.[indexInfected.[i]].[j]) then computers.[j].TryToInfect
            for k in [0..computers.Length - 1] do
                indexInfected <- updateInfected indexInfected k
        /// <summary>
        /// Get state
        /// </summary>
        member n.State =
            let mutable s = "Infected"
            for i in [0..computers.Length - 1] do
                if (computers.[i].Infected) then
                    s <- s + " " + (i + 1).ToString()
            s