namespace yXls_to_Grid
{
	partial class frmMain
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnRun = new System.Windows.Forms.Button();
			this.dtResult = new System.Windows.Forms.DataGridView();
			this.txtPath = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dtResult)).BeginInit();
			this.SuspendLayout();
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(623, 43);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(75, 23);
			this.btnRun.TabIndex = 0;
			this.btnRun.Text = "button1";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// dtResult
			// 
			this.dtResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtResult.Location = new System.Drawing.Point(252, 135);
			this.dtResult.Name = "dtResult";
			this.dtResult.RowTemplate.Height = 23;
			this.dtResult.Size = new System.Drawing.Size(240, 150);
			this.dtResult.TabIndex = 1;
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(81, 34);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(100, 21);
			this.txtPath.TabIndex = 2;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.dtResult);
			this.Controls.Add(this.btnRun);
			this.Name = "frmMain";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtResult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.DataGridView dtResult;
		private System.Windows.Forms.TextBox txtPath;
	}
}

