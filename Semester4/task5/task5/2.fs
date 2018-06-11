namespace Solve
    module task2 = 
        let func x l = 
            List.map (fun y -> y * x) l
        
        let func'1 x = 
            List.map (fun y -> y * x)
         
        let func'2 x =
            List.map ((*) x)
        
        let func'3 =
            List.map << (*)