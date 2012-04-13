module CaculateLibrary.StorageModule
open System.IO
open System.Text.RegularExpressions
open System.Xml.Linq
open System.Linq
type  Storage={ID:System.Guid;Code:string;FreeSpace:int;UserName:string;UserAccount:string;Capacity:int;Area:string}




let WriteToFile (fileName:string) (content:string) =
    if not (File.Exists(fileName)) then File.Create(fileName)|>ignore
    use file=new FileStream(fileName,FileMode.Append,FileAccess.Write)
    use tw=new StreamWriter(file)
    tw.WriteLine(content)


let GetXName x = XName.Get(x)

let SetAttributeValue (xe:XElement) name value =
    xe.SetAttributeValue((GetXName name),value)

let GetAttributeValue (xe:XElement) name =
    xe.Attribute(GetXName name).Value

let AddStorage (items:Storage array) (fileName:string) =
    let target= items|>Array.map (fun m ->
        let xe=new XElement((GetXName "Storage"))
        SetAttributeValue xe "ID" m.ID
        SetAttributeValue xe "Code" m.Code
        SetAttributeValue xe "FreeSpace" m.FreeSpace
        SetAttributeValue xe "UserName" m.UserName
        SetAttributeValue xe "UserAccount" m.UserAccount
        SetAttributeValue xe "Capacity" m.Capacity
        SetAttributeValue xe "Area" m.Area
        xe
          )
    let root= XElement.Load(fileName)
    target|>Array.iter root.Add
    root.Save(fileName)



let GetStorage (fileName:string)=
    let root=XElement.Load(fileName)
    root.Descendants()|>Seq.map (fun m ->{ID=System.Guid.Parse(m.Attribute(GetXName "ID").Value);Code=m.Attribute(GetXName "Code").Value;FreeSpace=System.Int32.Parse(m.Attribute(GetXName "FreeSpace").Value);UserName=m.Attribute(GetXName "UserName").Value;UserAccount=m.Attribute(GetXName "UserAccount").Value;Capacity=System.Int32.Parse(m.Attribute(GetXName "Capacity").Value);Area=m.Attribute(GetXName "Area").Value})

let GetStorageByCondition (fileName:string,area:string,code:string,userName:string,userAccount:string,freeSpace:int)=
    let mutable items= GetStorage fileName
    if not (System.String.IsNullOrEmpty(area)) then items <-items |> Seq.filter (fun (m:Storage) ->Regex.IsMatch(m.Area,area,RegexOptions.IgnoreCase))
    if not (System.String.IsNullOrEmpty(code)) then items <- items |> Seq.filter (fun (m:Storage) -> Regex.IsMatch(m.Code,code,RegexOptions.IgnoreCase) )
    if not (System.String.IsNullOrEmpty(userName)) then items <- items |> Seq.filter (fun (m:Storage) -> Regex.IsMatch(m.UserName,userName,RegexOptions.IgnoreCase) )
    if not (System.String.IsNullOrEmpty(userAccount)) then items <- items |> Seq.filter (fun (m:Storage) ->Regex.IsMatch(m.UserAccount,userAccount,RegexOptions.IgnoreCase) )
    if freeSpace <> -1 then items <- items |> Seq.filter (fun (m:Storage) ->m.FreeSpace=freeSpace )
    items





let sa=[for i in 1..10 -> {ID=System.Guid.NewGuid();Code="Storage"+i.ToString();FreeSpace=i; UserName="UserName"+i.ToString();UserAccount="UserAccount"+i.ToString();Capacity=42;Area="Area"+i.ToString()}]



let GetStorageByCode fileName id =
    GetStorage fileName |> Seq.find (fun m -> m.ID= id)


let GetAllAreas fileName  =
    GetStorage fileName |> Seq.map (fun m->m.Area) |> Seq.distinct

let GetStorageByArea fileName area =
    GetStorage fileName |> Seq.filter (fun m -> m.Area=area)


let DelStorage (fileName:string) (goodsFileName:string) id =
    let root=XElement.Load(fileName)
    let target= root.Descendants()|>Seq.find (fun m -> m.Attribute(GetXName "ID").Value=id)
    target.Remove()
    let goodsRoot = XElement.Load(goodsFileName)
    let goodsTarget =goodsRoot.Descendants()|>Seq.filter (fun m ->
         GetAttributeValue m "StorageId"|>fun x -> x=id
         )
    List.ofSeq goodsTarget |>List.iter (fun m -> m.Remove())
    root.Save(fileName)
    goodsRoot.Save(goodsFileName)
