using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class mainForm : Form
    {
        string substringDirectory; // store last part of full path name
        private string substringFile;

        public mainForm()
        {
            InitializeComponent();

            inputTextBox.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (Directory.Exists(inputTextBox.Text))
            {
                directoryTreeView.Nodes.Add(inputTextBox.Text);

                PopulateTreeView(inputTextBox.Text, directoryTreeView.Nodes[0]);
            }
        }

        public void PopulateTreeView(
            string directoryValue, TreeNode parentNode)
        {
            string[] directoryArray =
                Directory.GetDirectories(directoryValue);

            try
            {
                string[] fileArray = Directory.GetFiles(directoryValue);
                if (fileArray.Length != 0)
                {
                    foreach (string file in fileArray)
                    {
                        substringFile = Path.GetFileName(file);
                        TreeNode myNode2 = new TreeNode(substringFile);
                        parentNode.Nodes.Add(myNode2);
                    }
                }
                if (directoryArray.Length != 0)
                {
                    foreach (string directory in directoryArray)
                    {
                        substringDirectory =
                            Path.GetFileNameWithoutExtension(directory);
                        TreeNode myNode = new TreeNode(substringDirectory);

                        parentNode.Nodes.Add(myNode);

                        PopulateTreeView(directory,myNode);
                    }
                }

            }
            catch (UnauthorizedAccessException)
            {
                parentNode.Nodes.Add("Acess denied");

            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            directoryTreeView.Nodes.Clear();

            if (Directory.Exists(inputTextBox.Text))
            {
                directoryTreeView.Nodes.Add(inputTextBox.Text);

                PopulateTreeView(inputTextBox.Text,directoryTreeView.Nodes[0]);
            }
            else
            {
                MessageBox.Show(inputTextBox.Text + " could not be found.", 
                    "Directory Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void directoryTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            inputTextBox.Text = e.Node.FullPath;
        }

        private void directoryTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (File.Exists(inputTextBox.Text))
            {
                //add logic to read in directory contents 
                string[] lines = File.ReadAllLines(inputTextBox.Text);
                viewRichTextBox.Lines = lines;
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(inputTextBox.Text))
            {
               //add logic to read in directory contents 
                string[] lines = System.IO.File.ReadAllLines(inputTextBox.Text);
                viewRichTextBox.Lines = lines;
            }
            
            else
            {
                MessageBox.Show(inputTextBox.Text + " could not be found.",
                    "File Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
    }
}
