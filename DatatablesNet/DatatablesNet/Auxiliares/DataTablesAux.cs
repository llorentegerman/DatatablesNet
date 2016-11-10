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
}