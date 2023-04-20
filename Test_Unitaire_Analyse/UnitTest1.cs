using Analyse;
using System.Data;
using System.Windows;

namespace Test_Unitaire_Analyse
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {            
            Assert.Pass();
        }


        [STAThread]
        [Test]
        public void Test_Recherche_Employes()
        {
            string nom1 = "Bob Smith";
            string nom2 = "Jack Davis";
            List<string> list = new List<string>();
            list.Add(nom1);
            list.Add(nom2);

            string jour = "Mercredi";

            TimeSpan duree = new TimeSpan(0, 30, 0);

            DataTable resultatRecherche = new DataTable();
            resultatRecherche.Columns.Add("Nom", typeof(string));
            resultatRecherche.Columns.Add("Jour", typeof(string));
            resultatRecherche.Columns.Add("HeureDebut", typeof(string));
            resultatRecherche.Columns.Add("HeureFin", typeof(string));

            var row1 = resultatRecherche.NewRow();
            row1[0] = "Jack Davis";
            row1[1] = "Mercredi";
            row1[2] = "12:00";
            row1[3] = "16:00";

            resultatRecherche.Rows.Add(row1);

            var row2 = resultatRecherche.NewRow();
            row2[0] = "Bob Smith";
            row2[1] = "Mercredi";
            row2[2] = "10:00";
            row2[3] = "13:00";

            resultatRecherche.Rows.Add(row2);

            var row3 = resultatRecherche.NewRow();
            row3[0] = "Bob Smith et Jack Davis";
            row3[1] = "Mercredi";
            row3[2] = "12:00";
            row3[3] = "13:00";

            resultatRecherche.Rows.Add(row3);

            Thread thread = new Thread(() =>
            {
                MainWindow model = new MainWindow();
                Assert.That(resultatRecherche, Is.EqualTo(model.RechercheEmploye(list, jour, duree)));
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

        }
    }
}