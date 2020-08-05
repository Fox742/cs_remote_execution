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
        private SynchronizationContext _synchronizationContext;
        ClientEngine engine;

        public Form1()
        {
            InitializeComponent();
            _synchronizationContext = WindowsFormsSynchronizationContext.Current;
            engine = new ClientEngine(new WinFormsUIWrapper(this));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            engine.CompileExeciteService(textBox1.Text,textBox2.Text,richTextBox1.Text);
        }

        public void addTextToOutput( string whatToAdd )
        {
            _synchronizationContext.Post(
            (o) => richTextBox2.Text += whatToAdd, null);
        }

        public void clearOutput()
        {
            _synchronizationContext.Post(
                (o) => richTextBox2.Text = "", null);
        }

    }
}
