using System.Data.SqlClient;

namespace WS_Hotline.Framework.AccesDonnees
{
   public static class ReaderExtension
    {
       public static T SafeGeValue<T>(this SqlDataReader pReader, string pName)
       {
           int lIndex = pReader.GetOrdinal(pName);
           if (!pReader.IsDBNull(lIndex))
           {
               return (T)pReader.GetValue(lIndex);
           }

           return default(T);
       }
    }
}