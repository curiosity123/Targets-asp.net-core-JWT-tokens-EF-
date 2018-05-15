﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TargetsClient.ToolWindow
{
    public class ToolWindowViewModel : Bindable
    {

        User user;

        public ToolWindowViewModel()
        {

        }

        public ToolWindowViewModel(User u)
        {
            user = u;
        }


        private string title = "";

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChangedEvent("Title");
            }

        }




        private string description = "";

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChangedEvent("Description");
            }

        }


        private bool projChecked = true;

        public bool ProjChecked
        {
            get { return projChecked; }
            set
            {
                projChecked = value;
                RaisePropertyChangedEvent("ProjChecked");
            }
        }


        private bool stepChecked = false;

        public bool StepChecked
        {
            get { return stepChecked; }
            set
            {
                stepChecked = value;
                RaisePropertyChangedEvent("StepChecked");
            }
        }



        public List<Project> PrjList
        {
            get {
                if (user != null)
                    return user.Projects;
                else
                    return new List<Project>();
            }
        }


        private Project selectedProject;

        public Project SelectedProject
        {
            get { return selectedProject; }
            set { selectedProject = value;
                RaisePropertyChangedEvent("SelectedProject");
            }
        }




        public ICommand CmdAdd { get { return new RelayCommand(x => CanAdd(x), x => Add(x)); } }

        private bool CanAdd(object x)
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description))
                return true;


            return false;
        }

        private void Add(object x)
        {

            if (ProjChecked)
                user.Projects.Add(new Project() { Title = Title, Description = Description });
            else
                user.Projects[user.Projects.IndexOf(SelectedProject)].Steps.Add(new Step() { Title = Title, Description = Description });

        }
    }
}