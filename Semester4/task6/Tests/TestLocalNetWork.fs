module TestsLocalNetWork
open System
open Xunit
open LNW
open solve

let randomArray = [|0.3; 0.2|]
let numberGenerator = new DefinedGenerator(randomArray)

[<Fact>]
let ``OneComputerTest``() =
    let listOfOS = [{name = "Linux"; probabilityOfInfection = 0.3}]
    let arrayOfComputers = [|new Computer(listOfOS.[0], true, numberGenerator)|]
    let connectionMatrix = [|[|true|]|]
    let network = new Network(arrayOfComputers, connectionMatrix)
    let s = network.State
    Assert.Equal("Infected 1", s);
    
[<Fact>]
let ``TwoComputerTest``() =
    let listOfOS = [{name = "Linux"; probabilityOfInfection = 0.25}; 
                    {name = "Windows"; probabilityOfInfection = 0.75}]
    let arrayOfComputers = [|new Computer(listOfOS.[0], false, numberGenerator);
                             new Computer(listOfOS.[1], true, numberGenerator)|]
    let connectionMatrix = [|([|false; true|]); ([|true; false|])|]
    let network = new Network(arrayOfComputers, connectionMatrix)
    let s = network.State
    Assert.Equal("Infected 2", s)
    
[<Fact>]
let ``MakeStepTest``() =
    let listOfOS = [{name = "Windows"; probabilityOfInfection = 0.75};
                    {name = "Linux"; probabilityOfInfection = 0.25}]
    let arrayOfComputers = [|new Computer(listOfOS.[0], false, numberGenerator);
                             new Computer(listOfOS.[1], true, numberGenerator)|]
    let connectionMatrix = [|([|false; true|]); ([|true; false|])|]
    let network = new Network(arrayOfComputers, connectionMatrix)
    network.MakeStep
    let s = network.State
    Assert.Equal("Infected 1 2", s)  

[<Fact>]
let ``ThreeComputerTest``() =
    let listOfOS = [{name = "Linux"; probabilityOfInfection = 0.25};
                    {name = "Windows"; probabilityOfInfection = 0.75};
                    {name = "Mac"; probabilityOfInfection = 0.5}]
    let arrayOfComputers = [|new Computer(listOfOS.[0], false, numberGenerator); new Computer(listOfOS.[1], true, numberGenerator);
                            new Computer(listOfOS.[2], false, numberGenerator)|]
    let connectionMatrix = [|([|false; true; false|]); ([|true; false; true|]);
                            ([|false; true; false|])|]
    let network = new Network(arrayOfComputers, connectionMatrix)
    let s1 = network.State
    Assert.Equal("Infected 2", s1)
    network.MakeStep
    let s2 = network.State
    Assert.Equal("Infected 2 3", s2)
    network.MakeStep
    let s3 = network.State
    Assert.Equal("Infected 1 2 3", s3)
    