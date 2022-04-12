using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace week09_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView2.Nodes.Clear();

            TreeNode root = new TreeNode("Vehicle");
            root.ImageIndex = 5;
            root.SelectedImageIndex = 5;

            TreeNode node = new TreeNode("Car");
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            root.Nodes.Add(node);

            node = new TreeNode("Bicycle");
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            root.Nodes.Add(node);


            treeView2.Nodes.Add(root);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView view = sender as TreeView;
            textBox1.Text = view.SelectedNode.FullPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TreeNode parent = treeView2.SelectedNode;
            if (parent != null)
            {
                TreeNode node = new TreeNode(textBox2.Text);
                node.ImageIndex = parent.ImageIndex;
                node.SelectedImageIndex = parent.SelectedImageIndex;
                parent.Nodes.Add(node);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox3.Text))
            {
                TreeNode root = treeView3.Nodes.Add(textBox3.Text);
                populateDirectoryTree(textBox3.Text, root);
            }
        }

        private void populateDirectoryTree(string path, TreeNode parent)
        {
            try
            {
                string[] dirNames = Directory.GetDirectories(path);
                if (dirNames.Count() == 0)
                    return;

                

                foreach (var dir in dirNames)
                {
                    TreeNode node = parent.Nodes.Add(Path.GetFileNameWithoutExtension(dir));
                    populateDirectoryTree(dir, node);
                }
            }
            catch (UnauthorizedAccessException)
            {
                parent.Nodes.Add("Access Denied");
            }
            catch (Exception)
            {
                parent.Nodes.Add("Error!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var item = listView1.Items.Add(textBox4.Text);
            item.SubItems.Add(textBox5.Text);
            item.SubItems.Add(textBox6.Text);
        }
    }
}
