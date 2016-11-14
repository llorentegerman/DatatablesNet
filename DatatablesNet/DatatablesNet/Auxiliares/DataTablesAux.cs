using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DatatablesNet.Auxiliares
{
    public static class DataTablesAux
    {
        public static string ColumnsFromModel(Type modelType, List<string> ColumnsOrder = null)
        {
            PropertyInfo[] props = modelType.GetProperties(); //Obtengo todos los atributos de la clase

            int cantidadDeColumnas = ColumnsOrder == null ? props.Count() : ColumnsOrder.Count;
            
            string[] listHeaderDefinition = new string[cantidadDeColumnas];

            for(int i= 0; i < props.Count(); i++)
            {
                PropertyInfo prop = props[i];
                string attributeName = prop.Name;

                //Extraigo el DisplayAttribute, el cual utilizamos para definir cual sera el titulo a mostrar de esa columna.
                //En caso de que no tenga, utilizo como displayName el nombre del atributo.
                DisplayAttribute displayAttribute = prop.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

                string displayName = displayAttribute != null ? displayAttribute.Name : attributeName.ToLower(); //Lo extraigo.

                //Segun el tipo del atributo, lo mapeo a su correspondiente tipo en Datatables
                string sType = prop.PropertyType.ToString().ToLower();
                string sTipo = "string"; //Type por defecto.
                if (sType.IndexOf("int") >= 0 || sType.IndexOf("double") >= 0 || sType.IndexOf("float") >= 0 ||
                    sType.IndexOf("real") >= 0 || sType.IndexOf("single") >= 0)
                {
                    sTipo = "num";
                }
                else if (sType.IndexOf("date") >= 0)
                {
                    sTipo = "custom-date"; //Este es un tipo customizado, creado para que las fechas se adapten al formato dd/MM/yyyy
                }

                int position = i;   //Si no definí ColumnsOrder, entonces las columnas se mostraran en el orden en el que estan 
                                    //definidos los atributos.
                if (ColumnsOrder != null)
                {
                    position = ColumnsOrder.FindIndex(c => c.ToLower().Trim().Equals(attributeName.ToLower().Trim()));
                }
                if(position >= 0) //position sera < 0, solo si no inclui a esta columna dentro de "ColumnsOrder"
                    listHeaderDefinition[position] = "\t\t{ \"aTargets\": ["+ position + "], \"name\": \"" + attributeName + "\", \"title\": \"" + displayName + "\", \"type\": \"" + sTipo + "\", \"data\": \"" + attributeName + "\" }";
            }

            string headerDefinition = String.Join(",\n", listHeaderDefinition);            

            return headerDefinition;
        }
    }

    public class DataTablesRequest
    {
        public int draw;
        public int start;
        public int length;
        public string searchValue;
        public bool searchRegex;

        public List<int> orderColumn = new List<int>();
        public List<string> orderDir = new List<string>();

        public List<string> columnsData = new List<string>();
        public List<string> columnsName = new List<string>();

        public List<bool> columnsSearchable = new List<bool>();
        public List<bool> columnsOrderable = new List<bool>();

        public List<string> columnsSearchValue = new List<string>();
        public List<bool> columnsSearchRegex = new List<bool>();

        public static DataTablesRequest ExtractFormRequest(System.Collections.Specialized.NameValueCollection queryString)
        {
            DataTablesRequest retorno = new DataTablesRequest();

            retorno.draw = Int32.Parse(queryString["draw"]);
            retorno.start = Int32.Parse(queryString["start"]);
            retorno.length = Int32.Parse(queryString["length"]);
            retorno.searchValue = queryString["search[value]"];
            retorno.searchValue = retorno.searchValue.Replace("'", "''");
            retorno.searchRegex = bool.Parse(queryString["search[regex]"]);

            List<string> keysColumns = queryString.AllKeys.Where(k => k.ToLower().IndexOf("columns") == 0).ToList();
            foreach (string key in keysColumns)
            {
                var sIndex = System.Text.RegularExpressions.Regex.Match(key, @"\[([^]]*)\]").Groups[1].Value;
                int index = Int32.Parse(sIndex);
                string sNombre = key.Substring(key.IndexOf("]") + 1).Replace("[", "").Replace("]", "").ToLower();
                switch (sNombre)
                {
                    case "data": retorno.columnsData.Add(queryString[key]); break;
                    case "name": retorno.columnsName.Add(queryString[key]); break;
                    case "searchable": retorno.columnsSearchable.Add(bool.Parse(queryString[key])); break;
                    case "orderable": retorno.columnsOrderable.Add(bool.Parse(queryString[key])); break;
                    case "searchvalue": retorno.columnsSearchValue.Add(queryString[key]); break;
                    case "searchregex": retorno.columnsSearchRegex.Add(bool.Parse(queryString[key])); break;
                }

            }

            List<string> keysOrders = queryString.AllKeys.Where(k => k.ToLower().IndexOf("order") == 0).ToList();
            foreach (string key in keysOrders)
            {
                var sIndex = System.Text.RegularExpressions.Regex.Match(key, @"\[([^]]*)\]").Groups[1].Value;
                int index = Int32.Parse(sIndex);
                string sNombre = key.Substring(key.IndexOf("]") + 1).Replace("[", "").Replace("]", "").ToLower();
                switch (sNombre)
                {
                    case "column": retorno.orderColumn.Add(Int32.Parse(queryString[key])); break;
                    case "dir": retorno.orderDir.Add(queryString[key]); break;
                }

            }

            return retorno;
        }

    }

    public class DataTablesResponse
    {
        public int draw;
        public int recordsTotal;
        public int recordsFiltered;
        public IEnumerable<Object> data;
        public string error;
    }
}