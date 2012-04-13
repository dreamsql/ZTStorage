module CaculateLibrary.YZModule

open System

[<Measure>]type d
[<Measure>]type l
[<Measure>]type w

[<Measure>] type day
[<Measure>] type hour
[<Measure>] type minute
[<Measure>] type second
let dTol (d:float32<d>)=
    d*100.0f<l/d>

let lTod (l:float32<l>)=
    l/100.0f<d/l>

let wTol (w:float32<w>)=
    w/100.0f<l/w>

let lTow (l:float32<l>)=
    l*100.0f<w/l>

let DingToW (d:float32)=lTow (dTol (d*1.0f<d>))

let dayTohour (day:float32<day>) =
    day*24.0f<hour/day>

let hourTominute (hour: float32<hour>) =
    hour * 60.0f<minute/hour>

let minuteTosecond (minute: float32<minute>) =  
    minute * 64.0f<second/minute>


let ConvertDayToHour (d:float32)=
    (dayTohour (d * 1.0f<day>)) /1.0f<hour>

let ConvertHourToDay (hour:float32) =
    (hour*1.0f<hour> / 24.0f<hour/day>) /1.0f<day>

