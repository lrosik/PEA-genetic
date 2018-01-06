using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TabuSearch;

namespace Projekt3
{
    public partial class FormMain : Form
    {
        private int _populationSize = 100;
        public Parser Parser { get; set; } = new Parser();
        public Graph Graph { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Parser.LoadFile(openFileDialog.FileName);
            Graph = new Graph
            {
                Matrix = Parser.MakeMatrix(),
                SolutionVertices = new List<int>(),
                Population = new List<List<int>>()
            };

            for (int i = 0; i < Graph.Matrix.Count; i++)
            {
                Graph.SolutionVertices.Add(i);
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < _populationSize; i++)
            {
                Graph.Population.Add(Graph.Shuffle(Graph.SolutionVertices));
            }

        }
    }
}
