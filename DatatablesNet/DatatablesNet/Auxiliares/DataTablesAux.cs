using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DatatablesNet.Auxiliares
{
    public static class DataTablesAux
    {
        public static string ColumnsFromModel(Type modelType, List<string> ColumnsOrder = null)
        {
            PropertyInfo[] props = modelType.GetProperties(); //Obtengo todos los atributos de la clase

            int cantidadDeColumnas = props.Count();

            if (ColumnsOrder == null)
                ColumnsOrder = new List<string>();
            else
                cantidadDeColumnas = ColumnsOrder.Count;

            string[] listHeaderDefinition = new string[cantidadDeColumnas];

            for(int i= 0; i < props.Count(); i++)
            {
                PropertyInfo prop = props[i];
                string attributeName = prop.Name;

                //Asumo que todos los atributos estan decorados por "Display", el cual
                //utilizamos para definir cual sera el texto de esa columna.
                DisplayAttribute displayAttribute = prop.GetCustomAttributes(typeof(DisplayAttribute), false).First() as DisplayAttribute;
                string displayName = displayAttribute.Name; //Lo extraigo.

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

                int position = ColumnsOrder.FindIndex(c => c.ToLower().Trim().Equals(attributeName.ToLower().Trim()));
                if (position < 0)
                {
                    position = i;
                }
                listHeaderDefinition[position] = "\t\t{ \"aTargets\": ["+ position + "], \"name\": \"" + attributeName + "\", \"title\": \"" + displayName + "\", \"type\": \"" + sTipo + "\", \"data\": \"" + attributeName + "\" }";
            }

            string headerDefinition = String.Join(",\n", listHeaderDefinition);            

            return headerDefinition;
        }

    }
}