namespace SalesDataAnalysis
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txt_input = new System.Windows.Forms.Label();
      this.txt_action = new System.Windows.Forms.Label();
      this.txt_result = new System.Windows.Forms.Label();
      this.txt_input_file = new System.Windows.Forms.LinkLabel();
      this.txt_action_file = new System.Windows.Forms.LinkLabel();
      this.txt_result_file = new System.Windows.Forms.LinkLabel();
      this.btn_analyse = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txt_input
      // 
      this.txt_input.Location = new System.Drawing.Point(12, 9);
      this.txt_input.Name = "txt_input";
      this.txt_input.Size = new System.Drawing.Size(100, 23);
      this.txt_input.TabIndex = 0;
      this.txt_input.Text = "Input";
      // 
      // txt_action
      // 
      this.txt_action.Location = new System.Drawing.Point(12, 32);
      this.txt_action.Name = "txt_action";
      this.txt_action.Size = new System.Drawing.Size(100, 23);
      this.txt_action.TabIndex = 1;
      this.txt_action.Text = "Action";
      // 
      // txt_result
      // 
      this.txt_result.Location = new System.Drawing.Point(12, 55);
      this.txt_result.Name = "txt_result";
      this.txt_result.Size = new System.Drawing.Size(100, 23);
      this.txt_result.TabIndex = 2;
      this.txt_result.Text = "Result";
      // 
      // txt_input_file
      // 
      this.txt_input_file.Location = new System.Drawing.Point(263, 9);
      this.txt_input_file.Name = "txt_input_file";
      this.txt_input_file.Size = new System.Drawing.Size(100, 23);
      this.txt_input_file.TabIndex = 3;
      this.txt_input_file.TabStop = true;
      this.txt_input_file.Text = "No file";
      // 
      // txt_action_file
      // 
      this.txt_action_file.Location = new System.Drawing.Point(263, 32);
      this.txt_action_file.Name = "txt_action_file";
      this.txt_action_file.Size = new System.Drawing.Size(100, 23);
      this.txt_action_file.TabIndex = 4;
      this.txt_action_file.TabStop = true;
      this.txt_action_file.Text = "No file";
      // 
      // txt_result_file
      // 
      this.txt_result_file.Location = new System.Drawing.Point(263, 55);
      this.txt_result_file.Name = "txt_result_file";
      this.txt_result_file.Size = new System.Drawing.Size(100, 23);
      this.txt_result_file.TabIndex = 5;
      this.txt_result_file.TabStop = true;
      this.txt_result_file.Text = "No file";
      // 
      // btn_analyse
      // 
      this.btn_analyse.Location = new System.Drawing.Point(151, 98);
      this.btn_analyse.Name = "btn_analyse";
      this.btn_analyse.Size = new System.Drawing.Size(75, 23);
      this.btn_analyse.TabIndex = 6;
      this.btn_analyse.Text = "Analyse";
      this.btn_analyse.UseVisualStyleBackColor = true;
      this.btn_analyse.Click += new System.EventHandler(this.btn_analyse_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(375, 133);
      this.Controls.Add(this.btn_analyse);
      this.Controls.Add(this.txt_result_file);
      this.Controls.Add(this.txt_action_file);
      this.Controls.Add(this.txt_input_file);
      this.Controls.Add(this.txt_result);
      this.Controls.Add(this.txt_action);
      this.Controls.Add(this.txt_input);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
    }
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.LinkLabel linkLabel2;
    private System.Windows.Forms.LinkLabel linkLabel3;
    private System.Windows.Forms.Button btn_analyse;

    #endregion
  }
}

