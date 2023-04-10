using ApplicationT3.Service.DTOs.Model;
using System.Reflection;

namespace ApplicationT3.Service.Helper
{
    public static class PropertyValues
    {
        public static ObjQueryResponse QueryStringModel<T>(this T obj)
        {
            List<string> fields = new List<string>();
            List<dynamic> values = new List<dynamic>();
            List<string> valuesConc = new List<string>();
            PropertyInfo[] lst = typeof(T).GetProperties();

            fields.Add($"" +string.Join(",", lst.Select(c => c.Name))+"");

            foreach (var item in lst)
            {
                if(item.PropertyType.Name.Equals("DateTime"))
                {
                    values.Add(Convert.ToDateTime(item.GetValue(obj)).ToString("MM/dd/yyyy hh:mm tt",
                                                   System.Globalization.CultureInfo.InvariantCulture));
                    continue;
                }  
                 values.Add(item.GetValue(obj));                
            }

            valuesConc.Add($"''" + string.Join("'',''", values) + "''");
            values.Clear();


            return new ObjQueryResponse
            {
                FieldsStr = String.Join(",", fields),
                ValuesStr = String.Join(",", valuesConc)
            };
        }

        public static string QueryStringConcatValues(this string objProperty, string objValues)
        {
            string responseConcatValues = string.Empty;
            string[] Properties = objProperty.Split(',');
            string[] Values = objValues.Split(',');

            for (int i = 0; i < Properties.Count(); i++)
            {
                if (Properties.ElementAt(i).ToString().ToUpper() != "id".ToUpper())
                    responseConcatValues += Properties.ElementAt(i) + " = " + Values.ElementAt(i)+ "";

                if (Properties.Count() - 1 == i)
                    responseConcatValues += " ";
                else
                    responseConcatValues += ",";
            }

            return responseConcatValues;
        }
    }
}
