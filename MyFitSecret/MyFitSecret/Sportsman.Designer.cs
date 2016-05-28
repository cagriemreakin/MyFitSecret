namespace MyFitSecret
{
    partial class Sportsman
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.workoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myfitsecretDataSet = new MyFitSecret.myfitsecretDataSet();
            this.workoutTableAdapter = new MyFitSecret.myfitsecretDataSetTableAdapters.workoutTableAdapter();
            this.foodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myfitsecretDataSet1 = new MyFitSecret.myfitsecretDataSet();
            this.foodTableAdapter = new MyFitSecret.myfitsecretDataSetTableAdapters.foodTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.workoutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myfitsecretDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myfitsecretDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(273, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cardio Workouts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(444, 461);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(350, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 46);
            this.button4.TabIndex = 3;
            this.button4.Text = "Weight Training Videos";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // workoutBindingSource
            // 
            this.workoutBindingSource.DataMember = "workout";
            this.workoutBindingSource.DataSource = this.myfitsecretDataSet;
            // 
            // myfitsecretDataSet
            // 
            this.myfitsecretDataSet.DataSetName = "myfitsecretDataSet";
            this.myfitsecretDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // workoutTableAdapter
            // 
            this.workoutTableAdapter.ClearBeforeFill = true;
            // 
            // foodBindingSource
            // 
            this.foodBindingSource.DataMember = "food";
            this.foodBindingSource.DataSource = this.myfitsecretDataSet1;
            // 
            // myfitsecretDataSet1
            // 
            this.myfitsecretDataSet1.DataSetName = "myfitsecretDataSet";
            this.myfitsecretDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // foodTableAdapter
            // 
            this.foodTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(33, 155);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(273, 46);
            this.button5.TabIndex = 8;
            this.button5.Text = "Show your Body Progress";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(350, 231);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(257, 46);
            this.button6.TabIndex = 9;
            this.button6.Text = "Enter Daily Burned";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(350, 157);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(257, 42);
            this.button7.TabIndex = 10;
            this.button7.Text = "Enter your Body Measurements";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(33, 231);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(273, 46);
            this.button8.TabIndex = 11;
            this.button8.Text = "Enter Consumed Food";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(273, 46);
            this.button2.TabIndex = 12;
            this.button2.Text = "Update Body Weight";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Sportsman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 509);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "Sportsman";
            this.Text = "Sportsman";
            this.Load += new System.EventHandler(this.Sportsman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workoutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myfitsecretDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myfitsecretDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private myfitsecretDataSet myfitsecretDataSet;
        private System.Windows.Forms.BindingSource workoutBindingSource;
        private myfitsecretDataSetTableAdapters.workoutTableAdapter workoutTableAdapter;
        private myfitsecretDataSet myfitsecretDataSet1;
        private System.Windows.Forms.BindingSource foodBindingSource;
        private myfitsecretDataSetTableAdapters.foodTableAdapter foodTableAdapter;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button2;
    }
}