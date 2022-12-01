using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;

namespace RevitAddin5
{
    public partial class Form1 : Forms.Form
    {
        public Document doc;
        public Form1(Document _doc)
        {
            InitializeComponent();

            doc = _doc;

            comboBox1.Items.Add("Doors");
            comboBox1.Items.Add("Walls");
            comboBox2.Items.Add("Doors");
            comboBox2.Items.Add("Walls");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string selectCategory = comboBox1.SelectedItem as string;
            List<string> paramNames = new List<string>();

            FilteredElementCollector collector = new FilteredElementCollector(doc);

            if (selectCategory == "Doors")
            {
                collector.OfCategory(BuiltInCategory.OST_Doors);         
            }
            else if(selectCategory == "Walls")
            {
                collector.OfCategory(BuiltInCategory.OST_Walls);
            }

            if(collector.Count() > 0)
            {
                paramNames = GetParameterNamesFromType(collector.ToList());

                if (paramNames.Count > 0)
                {
                    foreach (string name in paramNames)
                        listBox1.Items.Add(name);

                }
            }
        }

        private List<string> GetParameterNamesFromType(List<Element> elemList)
        {
            List<string> paramNames = new List<string>();

            foreach (Element element in elemList)
            {
                foreach (Parameter curParam in element.Parameters)
                {
                    if (paramNames.Contains(curParam.Definition.Name) == false)
                        paramNames.Add(curParam.Definition.Name);
                }
            }

            paramNames.Sort();

            return paramNames;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            string selectCategory = comboBox2.SelectedItem as string;
            List<string> paramNames = new List<string>();

            FilteredElementCollector collector = new FilteredElementCollector(doc);

            if (selectCategory == "Doors")
            {
                collector.OfCategory(BuiltInCategory.OST_Doors);
            }
            else if (selectCategory == "Walls")
            {
                collector.OfCategory(BuiltInCategory.OST_Walls);
            }

            if (collector.Count() > 0)
            {
                paramNames = GetParameterNamesFromType(collector.ToList());

                if (paramNames.Count > 0)
                {
                    foreach (string name in paramNames)
                        listBox2.Items.Add(name);

                }
            }
        }
    }
}
