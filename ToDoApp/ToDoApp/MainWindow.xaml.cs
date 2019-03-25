using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Classes;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        Login login = new Login();
        ToDoController TDC = new ToDoController();
        SchoolTakenController STC = new SchoolTakenController();
        NotitieController NC = new NotitieController();
        DataTable userData;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Navigatie
        private void ImgToDo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Visible;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Hidden;
            Grid.SetRow(imgPointer, 2);
        }

        private void ImgSchool_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Visible;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Hidden;
            Grid.SetRow(imgPointer, 4);
        }

        private void ImgNotitie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Visible;
            gridMuziek.Visibility = Visibility.Hidden;
            Grid.SetRow(imgPointer, 6);
        }

        private void ImgMuziek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Visible;
            Grid.SetRow(imgPointer, 8);
        }

        private void VbToDo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Visible;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Hidden;
            Grid.SetRow(imgPointer, 2);
        }

        private void VbSchool_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Visible;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Hidden;
            Grid.SetRow(imgPointer, 4);
        }

        private void VbNotities_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Visible;
            gridMuziek.Visibility = Visibility.Hidden;
            Grid.SetRow(imgPointer, 6);
        }

        private void VbMuziek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Visible;
            Grid.SetRow(imgPointer, 8);
        }

        private void ImgLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridLogin.Visibility = Visibility.Visible;
        }

        private void TbLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridLogin.Visibility = Visibility.Visible;
        }

        private void BtAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            gridLogin.Visibility = Visibility.Hidden;
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();            
        }

        private void TbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtLogin_Click(this, new RoutedEventArgs());
            }
        }

        private void PbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtLogin_Click(this, new RoutedEventArgs());
            }
        }

        void Login()
        {

            DataTable dt = login.Inloggen(tbUsername.Text, pbPassword.Password);
            userData = dt;

            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];

                gridLogin.Visibility = Visibility.Hidden;
                textUsername.Text = dr["naam"].ToString();

                DataTable todoData = TDC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDo.DataContext = todoData.DefaultView;

                DataTable todoDataSchool = STC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDoSchool.DataContext = todoDataSchool.DefaultView;

                DataTable todoDataNotitie = NC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDoNotitie.DataContext = todoDataNotitie.DefaultView;
            }
            else
            {
                MessageBox.Show("Gebruikersnaam of wachtwoord is niet correct");
            }
        }

        private void BtOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];

                string userID = dr["ID"].ToString();

                int rowsaffected = TDC.taakOpslaan(tbTaakOmschrijving.Text, tbDatum.Text, userID);

                if (rowsaffected > 0)
                {
                    MessageBox.Show("Taak is toegevoegd");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de taak aanmaken");
                }

                dgToDo.DataContext = null;

                DataTable todoData = TDC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDo.DataContext = todoData.DefaultView;
                
            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }

            
        }

        private void BtAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            gdTaakToevoegen.Visibility = Visibility.Hidden;
            dgToDo.Visibility = Visibility.Visible;
            btTaakVerwijderen.Visibility = Visibility.Visible;
            btVoltooien.Visibility = Visibility.Visible;
        }

        private void btTaakToevoegen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gdTaakToevoegen.Visibility = Visibility.Visible;
            dgToDo.Visibility = Visibility.Hidden;
            btTaakVerwijderen.Visibility = Visibility.Collapsed;
            btVoltooien.Visibility = Visibility.Collapsed;
        }

        private void BtTaakVerwijderen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];
                DataRowView row = (DataRowView)dgToDo.SelectedItems[0];
                string ID = row["ID"].ToString();

                int affectedrows = TDC.taakVerwijderen(ID);

                if (affectedrows > 0)
                {
                    MessageBox.Show("Taak is verwijderd");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de taak verwijderen");
                }

                dgToDo.DataContext = null;

                DataTable todoData = TDC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDo.DataContext = todoData.DefaultView;

            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }
        }

        private void btVoltooien_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];
                DataRowView row = (DataRowView)dgToDo.SelectedItems[0];
                string ID = row["ID"].ToString();

                int affectedrows = TDC.taakVoltooien(ID);

                if (affectedrows > 0)
                {
                    MessageBox.Show("Taak is voltooid");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de taak voltooien");
                }

                dgToDo.DataContext = null;

                DataTable todoData = TDC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDo.DataContext = todoData.DefaultView;
            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }
        }

        private void btOpslaanSchool_Click(object sender, RoutedEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];

                string userID = dr["ID"].ToString();

                int rowsaffected = STC.taakOpslaan(tbTaakOmschrijvingSchool.Text, tbVak.Text, tbDatumSchool.Text, userID);

                if (rowsaffected > 0)
                {
                    MessageBox.Show("Taak is toegevoegd");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de taak aanmaken");
                }

                dgToDoSchool.DataContext = null;

                DataTable todoData = STC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDoSchool.DataContext = todoData.DefaultView;

            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }
        }

        private void btTaakToevoegenSchool_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gdTaakToevoegenSchool.Visibility = Visibility.Visible;
            dgToDoSchool.Visibility = Visibility.Hidden;
            btTaakVerwijderenSchool.Visibility = Visibility.Collapsed;
            btVoltooienSchool.Visibility = Visibility.Collapsed;
        }

        private void btTaakVerwijderenSchool_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];
                DataRowView row = (DataRowView)dgToDoSchool.SelectedItems[0];
                string ID = row["ID"].ToString();

                int affectedrows = STC.taakVerwijderen(ID);

                if (affectedrows > 0)
                {
                    MessageBox.Show("Taak is verwijderd");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de taak verwijderen");
                }

                dgToDoSchool.DataContext = null;

                DataTable todoData = STC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDoSchool.DataContext = todoData.DefaultView;

            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }
        }

        private void btVoltooienSchool_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];
                DataRowView row = (DataRowView)dgToDoSchool.SelectedItems[0];
                string ID = row["ID"].ToString();

                int affectedrows = STC.taakVoltooien(ID);

                if (affectedrows > 0)
                {
                    MessageBox.Show("Taak is voltooid");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de taak voltooien");
                }

                dgToDoSchool.DataContext = null;

                DataTable todoData = STC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDoSchool.DataContext = todoData.DefaultView;
            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }
        }

        private void btAnnulerenSchool_Click(object sender, RoutedEventArgs e)
        {
            gdTaakToevoegenSchool.Visibility = Visibility.Hidden;
            dgToDoSchool.Visibility = Visibility.Visible;
            btTaakVerwijderenSchool.Visibility = Visibility.Visible;
            btVoltooienSchool.Visibility = Visibility.Visible;
        }

        private void btOpslaanNotitie_Click(object sender, RoutedEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];

                string userID = dr["ID"].ToString();

                int rowsaffected = NC.taakOpslaan(tbTaakOmschrijvingNotitie.Text, userID);

                if (rowsaffected > 0)
                {
                    MessageBox.Show("Notitie is toegevoegd");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de notitie aanmaken");
                }

                dgToDoNotitie.DataContext = null;

                DataTable todoData = NC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDoNotitie.DataContext = todoData.DefaultView;

            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }
        }

        private void btTaakToevoegenNotitie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gdTaakToevoegenNotitie.Visibility = Visibility.Visible;
            dgToDoNotitie.Visibility = Visibility.Hidden;
            btTaakVerwijderenNotitie.Visibility = Visibility.Collapsed;
        }

        private void btAnnulerenNotitie_Click(object sender, RoutedEventArgs e)
        {
            gdTaakToevoegenNotitie.Visibility = Visibility.Hidden;
            dgToDoNotitie.Visibility = Visibility.Visible;
            btTaakVerwijderenNotitie.Visibility = Visibility.Visible;
        }

        private void btTaakVerwijderenNotitie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (userData != null)
            {
                DataRow dr = userData.Rows[0];
                DataRowView row = (DataRowView)dgToDoNotitie.SelectedItems[0];
                string ID = row["ID"].ToString();

                int affectedrows = NC.taakVerwijderen(ID);

                if (affectedrows > 0)
                {
                    MessageBox.Show("Taak is verwijderd");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met de taak verwijderen");
                }

                dgToDoNotitie.DataContext = null;

                DataTable todoData = NC.laadData(Int32.Parse(dr["ID"].ToString()));
                dgToDoNotitie.DataContext = todoData.DefaultView;

            }
            else
            {
                MessageBox.Show("U bent niet ingelogd");
            }
        }
    }
}
