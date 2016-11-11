using DatatablesNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatatablesNet.Controllers
{
    public class DatatablesController : Controller
    {
        #region LocalData

        private List<Contacto> Contactos = new List<Contacto>() {new Contacto() { Id = 1, Nombre = "Airi", Apellido = "Satou", Telefono = "32002071", Email = "Airi@Satou.com", Direccion = "Avellaneda, 555", Localidad = "Buenos Aires" },
            new Contacto() { Id = 2, Nombre = "Angelica", Apellido = "Ramos", Telefono = "26765017", Email = "Angelica@Ramos.com", Direccion = "Yrigoyen, 1452", Localidad = "Barcelona" },
            new Contacto() { Id = 3, Nombre = "Ashton", Apellido = "Cox", Telefono = "42460538", Email = "Ashton@Cox.com", Direccion = "Avellaneda, 613", Localidad = "Luis Beltran" },
            new Contacto() { Id = 4, Nombre = "Bradley", Apellido = "Greer", Telefono = "74537046", Email = "Bradley@Greer.com", Direccion = "Calle 31, 1118", Localidad = "Londres" },
            new Contacto() { Id = 5, Nombre = "Brenden", Apellido = "Wagner", Telefono = "60714340", Email = "Brenden@Wagner.com", Direccion = "Calle 50, 80", Localidad = "New York" },
            new Contacto() { Id = 6, Nombre = "Brielle", Apellido = "Williamson", Telefono = "44213830", Email = "Brielle@Williamson.com", Direccion = "Avellaneda, 959", Localidad = "Sidney" },
            new Contacto() { Id = 7, Nombre = "Bruno", Apellido = "Nash", Telefono = "82460418", Email = "Bruno@Nash.com", Direccion = "Calle 31, 483", Localidad = "Tokio" },
            new Contacto() { Id = 8, Nombre = "Caesar", Apellido = "Vance", Telefono = "40021652", Email = "Caesar@Vance.com", Direccion = "Avellaneda, 205", Localidad = "Rio de Janeiro" },
            new Contacto() { Id = 9, Nombre = "Cara", Apellido = "Stevens", Telefono = "28715131", Email = "Cara@Stevens.com", Direccion = "Yrigoyen, 1900", Localidad = "Roma" },
            new Contacto() { Id = 10, Nombre = "Cedric", Apellido = "Kelly", Telefono = "24642528", Email = "Cedric@Kelly.com", Direccion = "Yrigoyen, 1050", Localidad = "Berlin" },
            new Contacto() { Id = 11, Nombre = "Charde", Apellido = "Marshall", Telefono = "04852857", Email = "Charde@Marshall.com", Direccion = "Roque Senz Pena, 959", Localidad = "Buenos Aires" },
            new Contacto() { Id = 12, Nombre = "Colleen", Apellido = "Hurst", Telefono = "21458442", Email = "Colleen@Hurst.com", Direccion = "Yrigoyen, 296", Localidad = "Barcelona" },
            new Contacto() { Id = 13, Nombre = "Dai", Apellido = "Rios", Telefono = "57045826", Email = "Dai@Rios.com", Direccion = "Avellaneda, 1583", Localidad = "Luis Beltran" },
            new Contacto() { Id = 14, Nombre = "Donna", Apellido = "Snider", Telefono = "80124234", Email = "Donna@Snider.com", Direccion = "Calle 31, 137", Localidad = "Londres" },
            new Contacto() { Id = 15, Nombre = "Doris", Apellido = "Wilder", Telefono = "16611728", Email = "Doris@Wilder.com", Direccion = "Yrigoyen, 1424", Localidad = "New York" },
            new Contacto() { Id = 16, Nombre = "Finn", Apellido = "Camacho", Telefono = "08706385", Email = "Finn@Camacho.com", Direccion = "Roque Senz Pena, 1985", Localidad = "Sidney" },
            new Contacto() { Id = 17, Nombre = "Fiona", Apellido = "Green", Telefono = "50100387", Email = "Fiona@Green.com", Direccion = "Calle 50, 121", Localidad = "Tokio" },
            new Contacto() { Id = 18, Nombre = "Garrett", Apellido = "Winters", Telefono = "74454307", Email = "Garrett@Winters.com", Direccion = "Calle 50, 1124", Localidad = "Rio de Janeiro" },
            new Contacto() { Id = 19, Nombre = "Gavin", Apellido = "Cortez", Telefono = "10470628", Email = "Gavin@Cortez.com", Direccion = "Roque Senz Pena, 87", Localidad = "Roma" },
            new Contacto() { Id = 20, Nombre = "Gavin", Apellido = "Joyce", Telefono = "31011238", Email = "Gavin@Joyce.com", Direccion = "Yrigoyen, 370", Localidad = "Berlin" },
            new Contacto() { Id = 21, Nombre = "Gloria", Apellido = "Little", Telefono = "63180647", Email = "Gloria@Little.com", Direccion = "Calle 50, 874", Localidad = "Buenos Aires" },
            new Contacto() { Id = 22, Nombre = "Haley", Apellido = "Kennedy", Telefono = "74853434", Email = "Haley@Kennedy.com", Direccion = "Calle 31, 1124", Localidad = "Barcelona" },
            new Contacto() { Id = 23, Nombre = "Hermione", Apellido = "Butler", Telefono = "37723125", Email = "Hermione@Butler.com", Direccion = "Avellaneda, 1782", Localidad = "Luis Beltran" },
            new Contacto() { Id = 24, Nombre = "Herrod", Apellido = "Chandler", Telefono = "86506646", Email = "Herrod@Chandler.com", Direccion = "Calle 31, 1470", Localidad = "Londres" },
            new Contacto() { Id = 25, Nombre = "Hope", Apellido = "Fuentes", Telefono = "28807332", Email = "Hope@Fuentes.com", Direccion = "Yrigoyen, 1940", Localidad = "New York" },
            new Contacto() { Id = 26, Nombre = "Howard", Apellido = "Hatfield", Telefono = "88341857", Email = "Howard@Hatfield.com", Direccion = "Calle 31, 1815", Localidad = "Sidney" },
            new Contacto() { Id = 27, Nombre = "Jackson", Apellido = "Bradshaw", Telefono = "14160627", Email = "Jackson@Bradshaw.com", Direccion = "Roque Senz Pena, 1118", Localidad = "Tokio" },
            new Contacto() { Id = 28, Nombre = "Jena", Apellido = "Gaines", Telefono = "57137136", Email = "Jena@Gaines.com", Direccion = "Avellaneda, 1623", Localidad = "Rio de Janeiro" },
            new Contacto() { Id = 29, Nombre = "Jenette", Apellido = "Caldwell", Telefono = "26571642", Email = "Jenette@Caldwell.com", Direccion = "Yrigoyen, 1498", Localidad = "Roma" },
            new Contacto() { Id = 30, Nombre = "Jennifer", Apellido = "Acosta", Telefono = "06124358", Email = "Jennifer@Acosta.com", Direccion = "Roque Senz Pena, 1373", Localidad = "Berlin" },
            new Contacto() { Id = 31, Nombre = "Jennifer", Apellido = "Chang", Telefono = "85478722", Email = "Jennifer@Chang.com", Direccion = "Calle 31, 1306", Localidad = "Buenos Aires" },
            new Contacto() { Id = 32, Nombre = "Jonas", Apellido = "Alexander", Telefono = "23502256", Email = "Jonas@Alexander.com", Direccion = "Yrigoyen, 806", Localidad = "Barcelona" },
            new Contacto() { Id = 33, Nombre = "Lael", Apellido = "Greer", Telefono = "76331761", Email = "Lael@Greer.com", Direccion = "Calle 31, 1498", Localidad = "Luis Beltran" },
            new Contacto() { Id = 34, Nombre = "Martena", Apellido = "Mccray", Telefono = "45246426", Email = "Martena@Mccray.com", Direccion = "Avellaneda, 1209", Localidad = "Londres" },
            new Contacto() { Id = 35, Nombre = "Michael", Apellido = "Bruce", Telefono = "24467755", Email = "Michael@Bruce.com", Direccion = "Yrigoyen, 1118", Localidad = "New York" },
            new Contacto() { Id = 36, Nombre = "Michael", Apellido = "Silva", Telefono = "41054238", Email = "Michael@Silva.com", Direccion = "Avellaneda, 455", Localidad = "Sidney" },
            new Contacto() { Id = 37, Nombre = "Michelle", Apellido = "House", Telefono = "42035653", Email = "Michelle@House.com", Direccion = "Avellaneda, 552", Localidad = "Tokio" },
            new Contacto() { Id = 38, Nombre = "Olivia", Apellido = "Liang", Telefono = "26334343", Email = "Olivia@Liang.com", Direccion = "Yrigoyen, 1430", Localidad = "Rio de Janeiro" },
            new Contacto() { Id = 39, Nombre = "Paul", Apellido = "Byrd", Telefono = "26315767", Email = "Paul@Byrd.com", Direccion = "Yrigoyen, 1526", Localidad = "Roma" },
            new Contacto() { Id = 40, Nombre = "Prescott", Apellido = "Bartlett", Telefono = "71043262", Email = "Prescott@Bartlett.com", Direccion = "Calle 31, 268", Localidad = "Berlin" },
            new Contacto() { Id = 41, Nombre = "Quinn", Apellido = "Flynn", Telefono = "06540655", Email = "Quinn@Flynn.com", Direccion = "Roque Senz Pena, 1555", Localidad = "Buenos Aires" },
            new Contacto() { Id = 42, Nombre = "Rhona", Apellido = "Davidson", Telefono = "33236230", Email = "Rhona@Davidson.com", Direccion = "Yrigoyen, 892", Localidad = "Barcelona" },
            new Contacto() { Id = 43, Nombre = "Sakura", Apellido = "Yamamoto", Telefono = "44313080", Email = "Sakura@Yamamoto.com", Direccion = "Avellaneda, 926", Localidad = "Luis Beltran" },
            new Contacto() { Id = 44, Nombre = "Serge", Apellido = "Baldwin", Telefono = "28712570", Email = "Serge@Baldwin.com", Direccion = "Yrigoyen, 1804", Localidad = "Londres" },
            new Contacto() { Id = 45, Nombre = "Shad", Apellido = "Decker", Telefono = "18146567", Email = "Shad@Decker.com", Direccion = "Roque Senz Pena, 1833", Localidad = "New York" },
            new Contacto() { Id = 46, Nombre = "Shou", Apellido = "Itou", Telefono = "14722183", Email = "Shou@Itou.com", Direccion = "Roque Senz Pena, 1113", Localidad = "Sidney" },
            new Contacto() { Id = 47, Nombre = "Sonya", Apellido = "Frost", Telefono = "47023788", Email = "Sonya@Frost.com", Direccion = "Avellaneda, 1583", Localidad = "Tokio" },
            new Contacto() { Id = 48, Nombre = "Suki", Apellido = "Burks", Telefono = "80224484", Email = "Suki@Burks.com", Direccion = "Calle 31, 104", Localidad = "Rio de Janeiro" },
            new Contacto() { Id = 49, Nombre = "Tatyana", Apellido = "Fitzpatrick", Telefono = "64623074", Email = "Tatyana@Fitzpatrick.com", Direccion = "Calle 50, 983", Localidad = "Roma" },
            new Contacto() { Id = 50, Nombre = "Thor", Apellido = "Walton", Telefono = "54603408", Email = "Thor@Walton.com", Direccion = "Calle 50, 1079", Localidad = "Berlin" },
            new Contacto() { Id = 51, Nombre = "Tiger", Apellido = "Nixon", Telefono = "50662174", Email = "Tiger@Nixon.com", Direccion = "Calle 50, 195", Localidad = "Buenos Aires" },
            new Contacto() { Id = 52, Nombre = "Timothy", Apellido = "Mooney", Telefono = "71303674", Email = "Timothy@Mooney.com", Direccion = "Calle 31, 478", Localidad = "Barcelona" },
            new Contacto() { Id = 53, Nombre = "Unity", Apellido = "Butler", Telefono = "77111507", Email = "Unity@Butler.com", Direccion = "Calle 31, 1674", Localidad = "Luis Beltran" },
            new Contacto() { Id = 54, Nombre = "Vivian", Apellido = "Harrell", Telefono = "74027310", Email = "Vivian@Harrell.com", Direccion = "Calle 31, 920", Localidad = "Londres" },
            new Contacto() { Id = 55, Nombre = "Yuri", Apellido = "Berry", Telefono = "64253307", Email = "Yuri@Berry.com", Direccion = "Calle 50, 949", Localidad = "New York" },
            new Contacto() { Id = 56, Nombre = "Zenaida", Apellido = "Frank", Telefono = "48652887", Email = "Zenaida@Frank.com", Direccion = "Avellaneda, 1827", Localidad = "Sidney" },
            new Contacto() { Id = 57, Nombre = "Zorita", Apellido = "Serrano", Telefono = "48533302", Email = "Zorita@Serrano.com", Direccion = "Avellaneda, 1924", Localidad = "Tokio" },


        };

        #endregion
        
        // GET: Datatables
        public ActionResult Index()
        {   
            return View(Contactos);
        }

        // GET: Datatables/Ejemplo2
        public ActionResult Ejemplo2()
        {
            return View(Contactos);
        }

        // GET: Datatables/Ejemplo3
        public ActionResult Ejemplo3()
        {
            return View(Contactos);
        }

        // GET: Datatables/Ejemplo4
        public ActionResult Ejemplo4()
        {
            return View(Contactos);
        }
    }
}