using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Projekt3
{
    public partial class FormMain : Form
    {
        private int _populationSize = 2;
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
            Graph.Shuffle(Graph.SolutionVertices);
            //Graph.SolutionVertices.Add(Graph.SolutionVertices[0]);
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            var list = Graph.RunGeneticAlgorithm(_populationSize);
            foreach (var item in list)
            {
                listBox.Items.Add(item);
            }
            var path1 = Graph.WritePath(Graph.SolutionVertices);
            //Graph.Shuffle(Graph.SolutionVertices);
            //var path2 = Graph.WritePath(Graph.SolutionVertices);
            //Graph.Shuffle(Graph.SolutionVertices);
            //var path3 = Graph.WritePath(Graph.SolutionVertices);

            MessageBox.Show(path1);
            //for (int i = 0; i < _populationSize; i++)
            //{
            //    Graph.Population.Add(Graph.Shuffle(Graph.SolutionVertices));
            //}

        }
    }
}
