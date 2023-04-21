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
        public void Test_RechercheEmployesValide()
        {
            string nom1 = "Bob Smith";
            string nom2 = "Jack Davis";
            List<string> list = new List<string>();
            list.Add(nom2);
            list.Add(nom1);
            

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
            row3[0] = "Jack Davis et Bob Smith";
            row3[1] = "Mercredi";
            row3[2] = "12:00";
            row3[3] = "13:00";

            resultatRecherche.Rows.Add(row3);


            Assert.That(MainWindow.AreTablesTheSame(MainWindow.RechercheEmploye(list, jour, duree), resultatRecherche), Is.EqualTo(true));
            

        }

        [Test]
        public void Test_RechercheEmployesInvalide()
        {
            string nom1 = "Bob";
            string nom2 = "Jack Davis";
            List<string> list = new List<string>();
            list.Add(nom2);
            list.Add(nom1);


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
            row3[0] = "Jack Davis et Bob Smith";
            row3[1] = "Mercredi";
            row3[2] = "12:00";
            row3[3] = "13:00";

            resultatRecherche.Rows.Add(row3);


            Assert.That(MainWindow.AreTablesTheSame(MainWindow.RechercheEmploye(list, jour, duree), resultatRecherche), Is.EqualTo(false));


        }

        [Test]
        public void AjoutEmployeDBTest()
        {
            // Arrange
            var nom = "John";
            var dispo = new Disponibilite(TimeOnly.FromDateTime(DateTime.Now), TimeOnly.FromDateTime(DateTime.Now), "Lundi");
            var employe = new Employe(nom, new List<Disponibilite>() { dispo });

            // Act


            // Assert
            Assert.That(MainWindow.AutorisationInsertion(nom), Is.EqualTo(true));
            Assert.That(MainWindow.AjoutEmployeDB(employe), Is.EqualTo(MainWindow.getIdEmployeDB(nom)));
            Assert.IsTrue(MainWindow.Employes.Any(e => e.Nom == nom));
            Assert.IsTrue(MainWindow.Employes.Last().Disponibilites.Any(d => d.Jour == "Lundi" && d.HeureDebut == dispo.HeureDebut && d.HeureFin == dispo.HeureFin));
        }

        [Test]
        public void TestSupprimerEmployeDB()
        {
            // Créer un nom d'employé pour le test
            string nom = "John";

            // Appeler la fonction à tester
            bool confirmation = MainWindow.SupprimerEmployeLocal(nom);

            // Vérifier que la confirmation est correcte
            Assert.That(confirmation, Is.EqualTo(true));

            // Test non-fonctionnel : l'employé n'existe pas dans la base de données
            // Créer un nom d'employé qui n'existe pas dans la base de données
            string nomInexistant = "Jane ";

            // Appeler la fonction à tester
            bool confirmationInexistante = MainWindow.SupprimerEmployeLocal(nomInexistant);

            // Vérifier que la confirmation est correcte
            Assert.That(confirmationInexistante, Is.EqualTo(false));

        }


    }
}