using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using AugustPaper;


/*Name: ObjectOrientedProgramming CA2 
Author: Eunan Murray 
Date Created: 07/12/23 
Purpose: This application manages and displays the performance of sports teams and players, enabling the tracking and updating of their game results and points. It provides a user interface for viewing and manipulating team and player data.*/


namespace TeamApp
{
    public partial class MainWindow : Window
    {
        private List<Team> allTeams = new List<Team>();


        public MainWindow()
        {
            // Setting up the window, loading team data, and displaying sorted teams

            InitializeComponent();
            LoadTeamsData();
            SortTeamsAndDisplay();
        }

        private void LoadTeamsData()
        {
            // Clear existing members from all teams
            foreach (var team in allTeams)
            {
                team.Members.Clear();
            }

            // Generate new members
            var generator = new RandomMemberGenerator();
            List<Member> randomMembers = generator.GenerateRandomMembers(); // Adjust the number of members if needed

            // Reinitialize teams
            var teamSenior = new Team("Senior");
            var team18 = new Team("Under 18");
            var team16 = new Team("Under 16");
            var team14 = new Team("Under 14");

            // Allocate members to teams based on age
            teamSenior.Members.AddRange(randomMembers.Where(member => member.Age >= 18));
            team18.Members.AddRange(randomMembers.Where(member => member.Age >= 16 && member.Age < 18));
            team16.Members.AddRange(randomMembers.Where(member => member.Age >= 14 && member.Age < 16));
            team14.Members.AddRange(randomMembers.Where(member => member.Age < 14));

            // Update the allTeams list
            allTeams = new List<Team> { teamSenior, team18, team16, team14 };

            SortTeamsAndDisplay();
        }

        private void SortTeamsAndDisplay()
        {
            // Sorts the teams and then displays them in the list box
            DisplayTeamsInListBox();
        }

        private void DisplayTeamsInListBox()
        {
            // Clears the list box and displays all team names
            lstAllTeam.Items.Clear();
            foreach (var team in allTeams)
            {
                lstAllTeam.Items.Add(team.Name);
            }
        }

        private void SelectTeam(object sender, SelectionChangedEventArgs e)
        {

            // Handles the selection of a team and displays its players
            if (lstAllTeam.SelectedItem == null) return;

            var selectedTeamName = lstAllTeam.SelectedItem.ToString();
            var selectedTeam = allTeams.FirstOrDefault(t => t.Name == selectedTeamName);

            lstAllSwimmers.Items.Clear();
            if (selectedTeam != null)
            {
                foreach (var member in selectedTeam.Members)
                {
                    lstAllSwimmers.Items.Add(member.ToString());
                }
            }
        }

        // Event handler for the Randomize button click
        private void btnRandomize_Click(object sender, RoutedEventArgs e)
        {
            LoadTeamsData();
            // Optionally, update any UI elements that display member or team information
        }

    }
}
