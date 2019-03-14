﻿using System;
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
        }

        private void ImgSchool_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Visible;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Hidden;
        }

        private void ImgNotitie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Visible;
            gridMuziek.Visibility = Visibility.Hidden;
        }

        private void ImgMuziek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Visible;
        }

        private void VbToDo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Visible;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Hidden;
        }

        private void VbSchool_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Visible;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Hidden;
        }

        private void VbNotities_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Visible;
            gridMuziek.Visibility = Visibility.Hidden;
        }

        private void VbMuziek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridToDo.Visibility = Visibility.Hidden;
            gridSchool.Visibility = Visibility.Hidden;
            gridNotities.Visibility = Visibility.Hidden;
            gridMuziek.Visibility = Visibility.Visible;
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

                DataTable todoData = TDC.laadData(1);
                dgToDo.DataContext = todoData;
            }
            else
            {
                MessageBox.Show("Gebruikersnaam of wachtwoord is niet correct");
            }
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (userData.Rows.Count != 0)
            {
                DataRow dr = userData.Rows[0];

                db.ExecuteStringQuery($"INSERT INTO `tododb`.`to-do taak` (`Omschrijving`, `Datum`, `GebruikerID`, `Voltooid`) VALUES ('{tbTaakOmschrijving.Text}', '{tbDatum.Text}', '1', b'0');");
            }

            
        }
    }
}