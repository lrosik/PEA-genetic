using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace Projekt3
{
    public partial class FormMain : Form
    {
        private int _populationSize = 10;
        private int _time = 10;

        private double lastDist = Double.MaxValue;
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
                FormMain = this,
                CrossoverProbability = 0.8,
                MutationProbability = 0.01,
                Matrix = Parser.MakeMatrix(),
                SolutionVertices = new List<int>(),
                Population = new List<List<int>>(),
                PopulationSize = _populationSize
            };

            for (int i = 0; i < Graph.Matrix.Count; i++)
            {
                Graph.SolutionVertices.Add(i);
            }
            //Graph.Shuffle(Graph.SolutionVertices);
            
        }

        public void AddToListBox(double bestDist, int gen, int mutationType)
        {
            if (bestDist < lastDist)
            {
                lastDist = bestDist;
                if(mutationType == 0)
                    listBoxInvert.Items.Insert(0, bestDist + "           gen: " + gen);
                else if (mutationType == 1)
                    listBoxSwap.Items.Insert(0, bestDist + "           gen: " + gen);
                this.Refresh();
            }}

        private void buttonRun_Click(object sender, EventArgs e)
        {
            _populationSize = int.Parse(textBoxPopulationSize.Text);
            _time = int.Parse(textBoxTime.Text);

            if (comboBoxMutationType.SelectedIndex == 0)
            {
                listBoxInvert.Items.Clear();
                lastDist = Double.MaxValue;
                Graph.RunGeneticAlgorithm(_populationSize, _time, 0);
            }
            else if(comboBoxMutationType.SelectedIndex == 1)
            {
                listBoxSwap.Items.Clear();
                lastDist = Double.MaxValue;
                Graph.RunGeneticAlgorithm(_populationSize, _time, 1);
            }
        }
    }
}
