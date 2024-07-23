using Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCad.Plugin
{
    public class Ribbon
    {
        public static void CreateRibbon()
        {
            // Get the AutoCAD Ribbon
            RibbonControl ribbonControl = ComponentManager.Ribbon;

            // Check if our tab already exists
            RibbonTab ribbonTab = ribbonControl.FindTab("MyPluginTab");
            if (ribbonTab == null)
            {
                // Create a new ribbon tab
                ribbonTab = new RibbonTab
                {
                    Title = "My Plugin",
                    Id = "MyPluginTab"
                };
                ribbonControl.Tabs.Add(ribbonTab);
            }

            // Create a new ribbon panel
            RibbonPanelSource ribbonPanelSource = new RibbonPanelSource
            {
                Title = "My Commands"
            };
            RibbonPanel ribbonPanel = new RibbonPanel
            {
                Source = ribbonPanelSource
            };
            ribbonTab.Panels.Add(ribbonPanel);

            // Create a new ribbon button
            RibbonButton ribbonButton = new RibbonButton
            {
                Name = "Hello Button",
                ShowText = true,
                Text = "Say Hello",
                CommandHandler = new RelayCommand(ExecuteHelloCommand)
            };

            // Add the button to the ribbon panel
            ribbonPanelSource.Items.Add(ribbonButton);
        }

        private static void ExecuteHelloCommand(object obj)
        {
            // Execute the hello command defined in MyCommands class
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc != null)
            {
                doc.SendStringToExecute("hello ", true, false, false);
            }
        }

        // Simple relay command implementation for handling ribbon button commands
        private class RelayCommand : System.Windows.Input.ICommand
        {
            private readonly Action<object> _execute;
            private readonly Func<object, bool> _canExecute;

            public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

            public void Execute(object parameter) => _execute(parameter);

            public event EventHandler CanExecuteChanged;

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this,EventArgs.Empty)
            }
        }
    }
}
