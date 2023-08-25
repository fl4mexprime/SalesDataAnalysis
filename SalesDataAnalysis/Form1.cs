using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
            if (_input.Company.Length == 0)
                throw new Exception("Input file missing or empty");

            if (_action.Actions.Length == 0)
                throw new Exception("Action file missing or empty");

            if (string.IsNullOrWhiteSpace(_resultPath))
                throw new Exception("No result path was not given");

            var xml = new ResultXml
            {
                Result = new List<ResultModel>()
            };

            try
            {
                // Go through all actions and handle each one using a matching function
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

                // Write result file to _resultPath
                using var writer = new StreamWriter(_resultPath);
                var serializedXml = XmlHelper.Serialize(xml);
                writer.Write(serializedXml);

                MessageBox.Show($@"File was saved at {_resultPath}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        private void txt_input_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath;
            
            try
            {
                filePath = FileHelper.OpenFileDialog();

                _input = XmlHelper.Deserialize<InputXml>(filePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while reading file, are you sure it is in the right format?", exception.Message);
                return;
            }

            txt_input_file.Text = filePath;
        }
        private void txt_action_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath;

            try
            {
                filePath = FileHelper.OpenFileDialog();

                _action = XmlHelper.Deserialize<ActionXml>(filePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while reading file, are you sure it is in the right format?", exception.Message);
                return;
            }
            
            txt_action_file.Text = filePath;
        }
        private void txt_result_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var filePath = FileHelper.ChoosePathDialog();
                txt_result_file.Text = filePath;
                _resultPath = $"{filePath}\\result.xml";
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to write file", exception.Message);
            }
        }
    }
}