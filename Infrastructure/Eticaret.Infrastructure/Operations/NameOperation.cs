namespace Infrastructure.StaticServices;

public class NameOperation
{
    public static string ChracterRegulatory(string name)
    {
        string replaceList = 
            @"<>£#$½§{[]}\|!'^+%&/()=?@∑€®₺¥üiöπ
             ¨~`æ´¬¨∆^ğƒ∂ßæΩ≈√∫~µ≤≥÷Ω≈√∫~µ≤≥÷
             ₺ğƒ^∆¨|&ı:";
        
        name = replaceList.Aggregate(name, (current, c) => current.Replace(c.ToString(), ""));

        return name;
   
    }
}