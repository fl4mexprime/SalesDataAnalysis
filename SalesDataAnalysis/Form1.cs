using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using SalesDataAnalysis.Helpers;
using SalesDataAnalysis.Models.Input;

namespace SalesDataAnalysis
{
    public partial class Form1 : Form
    {
        private InputXml _input;
        private XDocument _action = new XDocument();
        private XDocument _result = new XDocument();

        private string _resultPath = "";

        public Form1()
        {
            InitializeComponent();
        }
        private void btn_analyse_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void txt_input_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filePath = FileHelper.OpenFileDialog();
            txt_input_file.Text = filePath;

            using (var reader = new StreamReader(filePath))
            {
                var action = (InputXml) new XmlSerializer(typeof(InputXml)).Deserialize(reader);
                _input = action;
            }
        }
        private void txt_action_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filePath = FileHelper.OpenFileDialog();
            txt_action_file.Text = filePath;
            _action.Add(filePath);
        }
        private void txt_result_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filePath = FileHelper.ChoosePathDialog();
            txt_result_file.Text = filePath;
            _resultPath = filePath;
        }
        private void txt_input_Click(object sender, EventArgs e)
        {
            // do nothing
        }
        private void txt_action_Click(object sender, EventArgs e)
        {
            // do nothing
        }
        private void txt_result_Click(object sender, EventArgs e)
        {
            // do nothing
        }
    }
}