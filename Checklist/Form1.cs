using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checklist
{
    public partial class Form1 : Form
    {

        private List<string> taskList;

        public Form1()
        {
            InitializeComponent();
            taskList = new List<string>();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string task = txtTask.Text;
            decimal pomodoro = txtPomodoro.Value;

            if(task.Length == 0 || pomodoro <= 0)
            {
                MessageBox.Show("Preencha os campos para inserir uma tarefa!");
                return;
            }

            string taskItem = string.Format("{0} | {1} pomodoro(s)", task, pomodoro);

            taskList.Add(taskItem);
            UpdateList();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedValue == null)
            {
                MessageBox.Show("Selecione um item para remover!");
                return;
            }

            string item = lstTasks.SelectedValue.ToString();


            taskList.Remove(item);
            UpdateList();
        }

        private void UpdateList()
        {
            lstTasks.DataSource = null;
            lstTasks.DataSource = taskList;
        }
    }
}
