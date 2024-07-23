using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CommandClass(typeof(AutoCad.Plugin.MyCommands))]
namespace AutoCad.Plugin
{
    public class MyCommands
    {
        [CommandMethod("hello")]

        public void HelloWorld()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            ed.WriteMessage("Hello World! How are you?");
        }

        [CommandMethod("InitializeRibbon")]
        public void InitializeRibbon()
        {
            Ribbon.CreateRibbon();
        }

    }
}
