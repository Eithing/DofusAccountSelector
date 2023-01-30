using System.Windows.Forms;

namespace AccountSelector
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListViewMain = new System.Windows.Forms.ListView();
            this.CB_AddAccount = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PseudoLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.BasBtn = new System.Windows.Forms.Button();
            this.HautBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DroiteBtn = new System.Windows.Forms.Button();
            this.GaucheBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CBChoixClasse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ListViewMain
            // 
            this.ListViewMain.AllowColumnReorder = true;
            this.ListViewMain.AllowDrop = true;
            this.ListViewMain.BackColor = System.Drawing.Color.White;
            this.ListViewMain.CheckBoxes = true;
            this.ListViewMain.FullRowSelect = true;
            this.ListViewMain.HideSelection = false;
            this.ListViewMain.Location = new System.Drawing.Point(12, 12);
            this.ListViewMain.Name = "ListViewMain";
            this.ListViewMain.Size = new System.Drawing.Size(200, 420);
            this.ListViewMain.TabIndex = 1;
            this.ListViewMain.UseCompatibleStateImageBehavior = false;
            this.ListViewMain.View = System.Windows.Forms.View.Details;
            this.ListViewMain.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewMain_ItemChecked);
            this.ListViewMain.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListViewMain_ItemDrag);
            this.ListViewMain.SelectedIndexChanged += new System.EventHandler(this.ListViewMain_SelectedIndexChanged);
            this.ListViewMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListViewMain_DragDrop);
            this.ListViewMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListViewMain_DragEnter);
            this.ListViewMain.DragOver += new System.Windows.Forms.DragEventHandler(this.ListViewMain_DragOver);
            // 
            // CB_AddAccount
            // 
            this.CB_AddAccount.FormattingEnabled = true;
            this.CB_AddAccount.Location = new System.Drawing.Point(218, 12);
            this.CB_AddAccount.Name = "CB_AddAccount";
            this.CB_AddAccount.Size = new System.Drawing.Size(121, 21);
            this.CB_AddAccount.TabIndex = 2;
            this.CB_AddAccount.Text = "Ajout d\'un compte";
            this.CB_AddAccount.SelectionChangeCommitted += new System.EventHandler(this.CB_AddAccount_SelectionChangeCommitted);
            this.CB_AddAccount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CB_AddAccount_MouseDown);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Maroon;
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DeleteButton.Location = new System.Drawing.Point(218, 291);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(121, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Supprimer";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PseudoLabel
            // 
            this.PseudoLabel.AutoSize = true;
            this.PseudoLabel.Location = new System.Drawing.Point(218, 248);
            this.PseudoLabel.Name = "PseudoLabel";
            this.PseudoLabel.Size = new System.Drawing.Size(35, 13);
            this.PseudoLabel.TabIndex = 5;
            this.PseudoLabel.Text = "label1";
            this.PseudoLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "perso suiv.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "perso prec.";
            // 
            // NextBtn
            // 
            this.NextBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.NextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextBtn.Location = new System.Drawing.Point(280, 51);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(76, 23);
            this.NextBtn.TabIndex = 8;
            this.NextBtn.Text = "?";
            this.NextBtn.UseVisualStyleBackColor = false;
            this.NextBtn.Enter += new System.EventHandler(this.NextBtn_Enter);
            // 
            // PrevBtn
            // 
            this.PrevBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.PrevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevBtn.Location = new System.Drawing.Point(280, 75);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(76, 23);
            this.PrevBtn.TabIndex = 9;
            this.PrevBtn.Text = "?";
            this.PrevBtn.UseVisualStyleBackColor = false;
            this.PrevBtn.Enter += new System.EventHandler(this.NextBtn_Enter);
            // 
            // BasBtn
            // 
            this.BasBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.BasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BasBtn.Location = new System.Drawing.Point(280, 128);
            this.BasBtn.Name = "BasBtn";
            this.BasBtn.Size = new System.Drawing.Size(76, 23);
            this.BasBtn.TabIndex = 13;
            this.BasBtn.Text = "?";
            this.BasBtn.UseVisualStyleBackColor = false;
            this.BasBtn.Enter += new System.EventHandler(this.NextBtn_Enter);
            // 
            // HautBtn
            // 
            this.HautBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.HautBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HautBtn.Location = new System.Drawing.Point(280, 104);
            this.HautBtn.Name = "HautBtn";
            this.HautBtn.Size = new System.Drawing.Size(76, 23);
            this.HautBtn.TabIndex = 12;
            this.HautBtn.Text = "?";
            this.HautBtn.UseVisualStyleBackColor = false;
            this.HautBtn.Enter += new System.EventHandler(this.NextBtn_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "BAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "HAUT";
            // 
            // DroiteBtn
            // 
            this.DroiteBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.DroiteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DroiteBtn.Location = new System.Drawing.Point(280, 175);
            this.DroiteBtn.Name = "DroiteBtn";
            this.DroiteBtn.Size = new System.Drawing.Size(76, 23);
            this.DroiteBtn.TabIndex = 17;
            this.DroiteBtn.Text = "?";
            this.DroiteBtn.UseVisualStyleBackColor = false;
            this.DroiteBtn.Enter += new System.EventHandler(this.NextBtn_Enter);
            // 
            // GaucheBtn
            // 
            this.GaucheBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.GaucheBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GaucheBtn.Location = new System.Drawing.Point(280, 151);
            this.GaucheBtn.Name = "GaucheBtn";
            this.GaucheBtn.Size = new System.Drawing.Size(76, 23);
            this.GaucheBtn.TabIndex = 16;
            this.GaucheBtn.Text = "?";
            this.GaucheBtn.UseVisualStyleBackColor = false;
            this.GaucheBtn.Enter += new System.EventHandler(this.NextBtn_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "DROITE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "GAUCHE";
            // 
            // CBChoixClasse
            // 
            this.CBChoixClasse.FormattingEnabled = true;
            this.CBChoixClasse.Location = new System.Drawing.Point(218, 264);
            this.CBChoixClasse.Name = "CBChoixClasse";
            this.CBChoixClasse.Size = new System.Drawing.Size(121, 21);
            this.CBChoixClasse.TabIndex = 19;
            this.CBChoixClasse.Text = "Choix Classe";
            this.CBChoixClasse.Visible = false;
            this.CBChoixClasse.SelectionChangeCommitted += new System.EventHandler(this.CBChoixClasse_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(368, 450);
            this.Controls.Add(this.CBChoixClasse);
            this.Controls.Add(this.DroiteBtn);
            this.Controls.Add(this.GaucheBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BasBtn);
            this.Controls.Add(this.HautBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PrevBtn);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PseudoLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CB_AddAccount);
            this.Controls.Add(this.ListViewMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView ListViewMain;
        private ComboBox CB_AddAccount;
        private Button DeleteButton;
        private Label PseudoLabel;
        private Label label2;
        private Label label3;
        private Button NextBtn;
        private Button PrevBtn;
        private Button BasBtn;
        private Button HautBtn;
        private Label label4;
        private Label label5;
        private Button DroiteBtn;
        private Button GaucheBtn;
        private Label label6;
        private Label label7;
        private ComboBox CBChoixClasse;
    }
}

