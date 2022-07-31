
namespace todolist
{
    partial class TopForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.registerTransitionBT = new System.Windows.Forms.Button();
            this.removeBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(15, 100);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 21;
            this.dgv.Size = new System.Drawing.Size(950, 350);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // registerTransitionBT
            // 
            this.registerTransitionBT.Location = new System.Drawing.Point(15, 40);
            this.registerTransitionBT.Name = "registerTransitionBT";
            this.registerTransitionBT.Size = new System.Drawing.Size(80, 45);
            this.registerTransitionBT.TabIndex = 1;
            this.registerTransitionBT.Text = "登録";
            this.registerTransitionBT.UseVisualStyleBackColor = true;
            this.registerTransitionBT.Click += new System.EventHandler(this.registerTransitionBT_Click);
            // 
            // removeBT
            // 
            this.removeBT.Location = new System.Drawing.Point(105, 40);
            this.removeBT.Name = "removeBT";
            this.removeBT.Size = new System.Drawing.Size(80, 45);
            this.removeBT.TabIndex = 2;
            this.removeBT.Text = "削除";
            this.removeBT.UseVisualStyleBackColor = true;
            this.removeBT.Click += new System.EventHandler(this.removeBT_Click);
            // 
            // TopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.removeBT);
            this.Controls.Add(this.registerTransitionBT);
            this.Controls.Add(this.dgv);
            this.Name = "TopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button registerTransitionBT;
        private System.Windows.Forms.Button removeBT;
    }
}

