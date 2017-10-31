using Bellatrix.Core;
using Bellatrix.Services.Logger;
using Bellatrix.Services.Resolver.ReflectionResolver;
using System;
using System.Windows.Forms;

namespace Bellatrix.UI.Desktop.SampleApp
{
    public partial class Form1 : Form
    {
        private Logger logger;

        public Form1()
        {
            InitializeComponent();
            InitializeServices();
            Console.SetOut(new ControlWriter(txtConsole));
        }

        private void InitializeServices()
        {
            BellatrixApplication.Instance.Resolver = new ReflectionResolver();
            logger = new Logger();
        }

        private void btnLogMessage_Click(object sender, EventArgs e)
        {
            logger.Log(LogLevel.Success, "Sample message");
        }
    }
}