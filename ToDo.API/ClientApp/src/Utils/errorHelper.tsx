export default function GetErrorDescription(error:String):String {
    switch(error){
        case "TITTLE_IS_REQUIRED" :
        return "PLEASE PROVIDE TITTLE"
        case "NOT_EXIST" :
        return "SELECTED ITEM NOT EXIST"
        default:
        return "UNKNOWN ERROR"
    }
}