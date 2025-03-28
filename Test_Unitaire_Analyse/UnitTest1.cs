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
        /// <summary>
        /// Test la fonction RechercheEmploye lorsque les param�tres de recherche sont valides
        /// </summary>
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
        /// <summary>
        ///ce  Test la fonction RechercheEmploye lorsque les param�tres de recherche sont invalides
        /// </summary>
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
        /// <summary>
        /// ce test vise � tester l'ajout d'un employ� � la base de donn�es en v�rifiant que l'employ� est bien ajout�, qu'il a le bon ID et que sa disponibilit� est correctement enregistr�e.
        /// </summary>
        [Test]
        public void AjoutEmployeDBTest()
        {
            // Arrange
            var nom = "John";
            var dispo = new Disponibilite(TimeOnly.FromDateTime(DateTime.Now), TimeOnly.FromDateTime(DateTime.Now), "Lundi");
            var employe = new Employe(nom, new List<Disponibilite>() { dispo });

            // Act


            // Assert
            Assert.That(MainWindow.AjoutEmployeDB(employe), Is.EqualTo(MainWindow.getIdEmployeDB(nom)));
            Assert.IsTrue(MainWindow.Employes.Any(e => e.Nom == nom));
            Assert.IsTrue(MainWindow.Employes.Last().Disponibilites.Any(d => d.Jour == "Lundi" && d.HeureDebut == dispo.HeureDebut && d.HeureFin == dispo.HeureFin));

            MainWindow.SupprimerEmployeDB(nom);
        }
        /// <summary>
        /// ce test vise � tester la suppression d'un employ� de la base de donn�es en v�rifiant que la confirmation de suppression est correcte et en testant un cas o� l'employ� n'existe pas dans la base de donn�es.
        /// </summary>
        [Test]
        public void TestSupprimerEmployeDB()
        {
            // Cr�er un nom d'employ� pour le test
            string nom = "John";
            Employe empTest = new Employe(nom);

            MainWindow.AjoutEmployeDB(empTest);

            // Appeler la fonction � tester
            bool confirmation = MainWindow.SupprimerEmployeLocal(nom);

            // V�rifier que la confirmation est correcte
            Assert.That(confirmation, Is.EqualTo(true));

            // Test non-fonctionnel : l'employ� n'existe pas dans la base de donn�es
            // Cr�er un nom d'employ� qui n'existe pas dans la base de donn�es
            string nomInexistant = "Jane ";

            // Appeler la fonction � tester
            bool confirmationInexistante = MainWindow.SupprimerEmployeLocal(nomInexistant);

            // V�rifier que la confirmation est correcte
            Assert.That(confirmationInexistante, Is.EqualTo(false));

        }


    }
}