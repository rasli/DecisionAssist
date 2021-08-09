namespace DecisionAssist
{
    partial class dummy
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.qualityAttributeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qualityAttributeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.qAidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qAnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRQAimpactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityAttributeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityAttributeBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qAidDataGridViewTextBoxColumn,
            this.qAnameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dRQAimpactDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.qualityAttributeBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(667, 384);
            this.dataGridView1.TabIndex = 0;
            // 
            // qualityAttributeBindingSource
            // 
            this.qualityAttributeBindingSource.DataSource = typeof(DecisionAssist.QualityAttribute);
            // 
            // qualityAttributeBindingSource1
            // 
            this.qualityAttributeBindingSource1.DataSource = typeof(DecisionAssist.QualityAttribute);
            // 
            // qAidDataGridViewTextBoxColumn
            // 
            this.qAidDataGridViewTextBoxColumn.DataPropertyName = "QA_id";
            this.qAidDataGridViewTextBoxColumn.HeaderText = "QA_id";
            this.qAidDataGridViewTextBoxColumn.Name = "qAidDataGridViewTextBoxColumn";
            // 
            // qAnameDataGridViewTextBoxColumn
            // 
            this.qAnameDataGridViewTextBoxColumn.DataPropertyName = "QA_name";
            this.qAnameDataGridViewTextBoxColumn.HeaderText = "QA_name";
            this.qAnameDataGridViewTextBoxColumn.Name = "qAnameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // dRQAimpactDataGridViewTextBoxColumn
            // 
            this.dRQAimpactDataGridViewTextBoxColumn.DataPropertyName = "DR_QA_impact";
            this.dRQAimpactDataGridViewTextBoxColumn.HeaderText = "DR_QA_impact";
            this.dRQAimpactDataGridViewTextBoxColumn.Name = "dRQAimpactDataGridViewTextBoxColumn";
            // 
            // dummy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 384);
            this.Controls.Add(this.dataGridView1);
            this.Name = "dummy";
            this.Text = "dummy";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityAttributeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityAttributeBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource qualityAttributeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn qAidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qAnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRQAimpactDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource qualityAttributeBindingSource1;
    }
}