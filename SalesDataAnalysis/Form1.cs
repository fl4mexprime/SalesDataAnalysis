using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using SalesDataAnalysis.Enums;
using SalesDataAnalysis.Extensions;
using SalesDataAnalysis.Handlers;
using SalesDataAnalysis.Helpers;
using SalesDataAnalysis.Models.action;
using SalesDataAnalysis.Models.Input;
using SalesDataAnalysis.Models.Result;

namespace SalesDataAnalysis
{
    public partial class Form1 : Form
    {
        private InputXml _input;
        private ActionXml _action;
        private string _resultPath = "";

        public Form1()
        {
            InitializeComponent();
        }
        private void btn_analyse_Click(object sender, EventArgs e)
        {
            var xml = new ResultXml
            {
                Result = new List<ResultModel>()
            };

            foreach (var action in _action.Actions)
            {
                var result = _input.Company.Where(company => Regex.IsMatch(company.Name, action.Filter));

                var res = action.Function.ToEnum<Function>() switch
                {
                    Function.Sum => ActionsHandler.Sum(result, action),
                    Function.Max => ActionsHandler.Max(result, action),
                    Function.Min => ActionsHandler.Min(result, action),
                    Function.Average => ActionsHandler.Average(result, action),
                    _ => throw new Exception("Function not implemented")
                };
                
                xml.Result.Add(res);
            }

            if (string.IsNullOrWhiteSpace(_resultPath))
                throw new Exception("No result path was given");

            using var writer = new StreamWriter(_resultPath);
            
            // Adding empty namespace to omit xmlns being set on root element
            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("","");
            
            new XmlSerializer(typeof(ResultXml)).Serialize(writer, xml, nameSpace);
        }
        private void txt_input_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filePath = FileHelper.OpenFileDialog();
            txt_input_file.Text = filePath;

            using var reader = new StreamReader(filePath);
            
            var action = (InputXml) new XmlSerializer(typeof(InputXml)).Deserialize(reader);
            _input = action;
        }
        private void txt_action_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filePath = FileHelper.OpenFileDialog();
            txt_action_file.Text = filePath;

            using var reader = new StreamReader(filePath);
            var action = (ActionXml) new XmlSerializer(typeof(ActionXml)).Deserialize(reader);
            _action = action;
        }
        private void txt_result_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filePath = FileHelper.ChoosePathDialog();
            txt_result_file.Text = filePath;
            _resultPath = $"{filePath}\\result.xml";
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