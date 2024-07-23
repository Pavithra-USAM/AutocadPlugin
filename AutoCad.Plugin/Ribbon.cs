using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Customization;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RibbonPanelSource = Autodesk.Windows.RibbonPanelSource;


namespace AutoCad.Plugin
{
    public class Ribbon
    {
        public static void CreateRibbon()
        {
            // Get the AutoCAD Ribbon
            Autodesk.Windows.RibbonControl ribbonControl = ComponentManager.Ribbon;

            // Check if our tab already exists
            RibbonTab ribbonTab = new RibbonTab


            {
                Title = "My Plugin",
                Id = "MyPluginTab"
            };
            ribbonControl.Tabs.Add(ribbonTab);


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
            Autodesk.Windows.RibbonButton ribbonButton = new Autodesk.Windows.RibbonButton
            {
                Name = "Hello Button",
                ShowText = true,
                Text = "Say Hello",

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
       


    }
}

