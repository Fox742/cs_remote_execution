using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendToServer();
        }

        private async void sendToServer()
        {
            label1.Text = await Task.Run(() => (new ExecutionService.iExecitionServiceClient().Compile("Hello")) );
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExecutionService.iExecitionServiceClient client = new ExecutionService.iExecitionServiceClient();
            label2.Text = client.Compile("Hello");
        }
    }
}
