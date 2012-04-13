module CaculateLibrary.GoodsModule
open CaculateLibrary.StorageModule
open System
open System.IO
open Microsoft.FSharp.Reflection
open System.Text.RegularExpressions
open System.Xml.Linq
open System.Linq
type GoodsUnit=
    |Zu of int
    |Ge of int
type Goods={ID:System.Guid;Code:string;Quantity:int;LeftDay:float32;StorageId:System.Guid;Name:string;Desc:string;Price:float32;CreateDate:DateTime}

let AddGoods (items: Goods array) (fileName:string) =
    let target= items|>Array.map (fun m ->
        let xe=new XElement((GetXName "Good"))
        xe.SetAttributeValue((GetXName "ID"),m.ID)
        xe.SetAttributeValue((GetXName "Code"),m.Code)
        xe.SetAttributeValue((GetXName "Quantity"),m.Quantity)
        xe.SetAttributeValue((GetXName "LeftDay"),m.LeftDay)
        xe.SetAttributeValue((GetXName "StorageId"),m.StorageId)
        xe.SetAttributeValue((GetXName "Name"),m.Name)
        xe.SetAttributeValue((GetXName "Desc"),m.Desc)
        xe.SetAttributeValue((GetXName "Price"),m.Price)
        xe.SetAttributeValue((GetXName "CreateDate"),m.CreateDate)
        xe
          )
    let root= XElement.Load(fileName)
    target|>Array.iter root.Add
    root.Save(fileName)


let GetGoods (fileName:string) =
    let root=XElement.Load(fileName)
    root.Descendants()|>Seq.map (fun m ->
         let currentLeftDay = DateTime.Now - DateTime.Parse(m.Attribute(GetXName "CreateDate").Value)
         let result =  YZModule.ConvertHourToDay (float32 currentLeftDay.TotalHours)
         let leftday= float32(System.Double.Parse(m.Attribute(GetXName "LeftDay").Value)) - result
         let id=Guid.Parse(m.Attribute(GetXName "ID").Value)
         let code=m.Attribute(GetXName "Code").Value
         let quantity=Int32.Parse(m.Attribute(GetXName "Quantity").Value)
         let leftDay=leftday
         let storageID=Guid.Parse(m.Attribute(GetXName "StorageId").Value)
         let name=m.Attribute(GetXName "Name").Value
         let desc=m.Attribute(GetXName "Desc").Value
         let price=float32(System.Double.Parse(m.Attribute(GetXName "Price").Value))
         let createDateTime=DateTime.Parse(m.Attribute(GetXName "CreateDate").Value)
         
         {ID=id;Code=code;Quantity=quantity;LeftDay=leftDay;StorageId=storageID;Name=name;Desc=desc;Price= price;CreateDate=createDateTime}
        )
    
let GetGoodsByCondition fileName storageFileName code (leftDay:float32) storageId area =
    let mutable items= GetGoods fileName
    if not (System.String.IsNullOrEmpty(code)) then items <- items |> Seq.filter (fun m -> Regex.IsMatch(m.Code,code,RegexOptions.IgnoreCase))
    if leftDay <> -1.0f then items <- items |> Seq.filter (fun m -> m.LeftDay=leftDay)
    if not (System.String.IsNullOrEmpty(area)) then items <- items |>Seq.filter (fun m ->GetStorageByArea storageFileName area |>Seq.exists (fun n ->n.ID=m.StorageId))
    elif not (storageId=Guid.Empty) then items <- items |> Seq.filter (fun m ->m.StorageId=storageId)
    items
     

let DelGoods (fileName:string)  id =
    let root=XElement.Load(fileName)
    let target= root.Descendants()|>Seq.find (fun m -> m.Attribute(GetXName "ID").Value=id)
    target.Remove()
    root.Save(fileName)
    
    