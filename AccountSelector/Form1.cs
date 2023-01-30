using AccountSelector.Model;
using FluentDragDrop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountSelector
{
    public partial class Form1 : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int HC_ACTION = 0;
        private const int WM_KEYDOWN = 0x0100;

        private delegate IntPtr KeyboardHookProcDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProcDelegate lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        private List<Account> accounts = new List<Account>();
        private List<Params> paramsList;

        private List<Process> processesList = new List<Process>();

        private int activeDofusWinFocus = 0;

        JsonGesture jsonGesture = new JsonGesture();
        public Form1()
        {
            SetHook();
            InitializeComponent();
            #region declare Img
            var imageList = new ImageList();
            imageList.Images.Add("Cra", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Cra.png"));
            imageList.Images.Add("Ecaflip", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Ecaflip.png"));
            imageList.Images.Add("Eliotrope", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Eliotrope.png"));
            imageList.Images.Add("Eniripsa", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Eniripsa.png"));
            imageList.Images.Add("Enutrof", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Enutrof.png"));
            imageList.Images.Add("Feca", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Feca.png"));
            imageList.Images.Add("ForgeLance", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\ForgeLance.png"));
            imageList.Images.Add("HupperMage", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\hupperMage.png"));
            imageList.Images.Add("Iop", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Iop.png"));
            imageList.Images.Add("Osamada", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Osamada.png"));
            imageList.Images.Add("Ouginak", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Ouginak.png"));
            imageList.Images.Add("Pandawa", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Pandawa.png"));
            imageList.Images.Add("Roublard", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Roublard.png"));
            imageList.Images.Add("Sacrieur", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Sacrieur.png"));
            imageList.Images.Add("Sadida", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Sadida.png"));
            imageList.Images.Add("Sram", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Sram.png"));
            imageList.Images.Add("Steamer", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Steamer.png"));
            imageList.Images.Add("Xelor", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Xelor.png"));
            imageList.Images.Add("Zobal", Image.FromFile(Application.StartupPath + "\\Ressources\\Images\\Zobal.png"));

            this.ListViewMain.SmallImageList = imageList;

            //declare dropDown Classe Selector
            this.CBChoixClasse.Items.Add("Cra");
            this.CBChoixClasse.Items.Add("Ecaflip");
            this.CBChoixClasse.Items.Add("Eliotrope");
            this.CBChoixClasse.Items.Add("Eniripsa");
            this.CBChoixClasse.Items.Add("Enutrof");
            this.CBChoixClasse.Items.Add("Feca");
            this.CBChoixClasse.Items.Add("ForgeLance");
            this.CBChoixClasse.Items.Add("HupperMage");
            this.CBChoixClasse.Items.Add("Osamada");
            this.CBChoixClasse.Items.Add("Ouginak");
            this.CBChoixClasse.Items.Add("Pandawa");
            this.CBChoixClasse.Items.Add("Roublard");
            this.CBChoixClasse.Items.Add("Sacrieur");
            this.CBChoixClasse.Items.Add("Sadida");
            this.CBChoixClasse.Items.Add("Sram");
            this.CBChoixClasse.Items.Add("Steamer");
            this.CBChoixClasse.Items.Add("Xelor");
            this.CBChoixClasse.Items.Add("Zobal");
            #endregion

            this.paramsList = jsonGesture.DeserializeParams();
            if(paramsList == null )
            {
                paramsList = new List<Params> { new Params { Name = "NextBtn", ButtonName = "" , VKValue = -1 },
                                            new Params { Name = "PrevBtn", ButtonName = "" , VKValue = -1 },
                                            new Params { Name = "HautBtn", ButtonName = "" , VKValue = -1 },
                                            new Params { Name = "BasBtn", ButtonName = "" , VKValue = -1 },
                                            new Params { Name = "GaucheBtn", ButtonName = "" , VKValue = -1 },
                                            new Params { Name = "DroiteBtn", ButtonName = "" , VKValue = -1 }};
            }

            foreach(var item in paramsList)
            {
                switch (item.Name)
                {
                    case "NextBtn":
                        this.NextBtn.Text = item.ButtonName;
                        break;
                    case "PrevBtn":
                        this.PrevBtn.Text = item.ButtonName;
                        break;
                    case "HautBtn":
                        this.HautBtn.Text = item.ButtonName;
                        break;
                    case "BasBtn":
                        this.BasBtn.Text = item.ButtonName;
                        break;
                    case "GaucheBtn":
                        this.GaucheBtn.Text = item.ButtonName;
                        break;
                    case "DroiteBtn":
                        this.DroiteBtn.Text = item.ButtonName;
                        break;
                }
            }

            ColumnHeader CheckColumn = new ColumnHeader();
            CheckColumn.Text = "";
            CheckColumn.Width = 200;
            this.ListViewMain.Columns.Add(CheckColumn);


            this.accounts = jsonGesture.DeserializeJsonObject();
            if(this.accounts != null)
            {
                foreach (var item in this.accounts)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Checked = item.IsActive;
                    lvItem.Text = item.Name;
                    lvItem.ImageKey = item.Image; // l'index de l'image à afficher dans la colonne d'image
                    this.ListViewMain.Items.Add(lvItem);

                    processesList.Add(Process.GetProcesses().Where(p => p.MainWindowTitle.Contains(item.Name)).FirstOrDefault());
                }
            }
        }

        private void ListViewMain_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.ListViewMain.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void ListViewMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListViewMain_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = this.ListViewMain.PointToClient(new Point(e.X, e.Y));
            ListViewItem targetItem = this.ListViewMain.GetItemAt(targetPoint.X, targetPoint.Y);
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            if (!draggedItem.Equals(targetItem) && targetItem != null)
            {
                int draggedIndex = draggedItem.Index;
                int targetIndex = targetItem.Index;

                if (draggedIndex < targetIndex)
                {
                    this.ListViewMain.Items.Insert(targetIndex + 1, (ListViewItem)draggedItem.Clone());
                    this.ListViewMain.Items.Remove(draggedItem);
                }
                else
                {
                    this.ListViewMain.Items.Insert(targetIndex, (ListViewItem)draggedItem.Clone());
                    this.ListViewMain.Items.Remove(draggedItem);
                }
            }

            jsonGesture.SerializeJsonObject(this.ListViewMain);
        }

        private void ListViewMain_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = this.ListViewMain.PointToClient(new Point(e.X, e.Y));
            ListViewItem targetItem = this.ListViewMain.GetItemAt(targetPoint.X, targetPoint.Y);

            if (targetItem != null)
            {
                // Dessinez une ligne de repère au-dessus de l'élément cible
                this.ListViewMain.Invalidate(targetItem.Bounds);
                targetItem.EnsureVisible();
            }
        }

        private void CB_AddAccount_MouseDown(object sender, MouseEventArgs e)
        {
            this.CB_AddAccount.Items.Clear();

            Process[] processlist = Process.GetProcesses();
            var dofusWin = processlist.Where(p => p.MainWindowTitle.Contains(" - Dofus"));

            bool QuitBoucle = false;
            foreach(var WinDofFinded in dofusWin)
            {
                QuitBoucle = false;
                foreach (ListViewItem alreadyCreat in this.ListViewMain.Items)
                {
                    if (WinDofFinded.MainWindowTitle.Contains(alreadyCreat.Text))
                        QuitBoucle = true;
                }
                if(!QuitBoucle)
                {
                    var pseudoList = WinDofFinded.MainWindowTitle.Split('-');
                    var pseudo = pseudoList[0];
                    this.CB_AddAccount.Items.Add(pseudo);
                }
            }
        }

        private void CB_AddAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Checked = true;
            item.Text = this.CB_AddAccount.SelectedItem?.ToString();
            item.ImageKey = ""; // l'index de l'image à afficher dans la colonne d'image
            this.ListViewMain.Items.Add(item);

            processesList.Add(Process.GetProcesses().Where(p => p.MainWindowTitle.Contains(item.Name)).FirstOrDefault());

            jsonGesture.SerializeJsonObject(this.ListViewMain);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListViewMain.Items.Remove(this.ListViewMain.SelectedItems[0]);
            processesList.Remove(Process.GetProcesses().Where(p => p.MainWindowTitle.Contains(this.ListViewMain.SelectedItems[0].Text)).FirstOrDefault());
            jsonGesture.SerializeJsonObject(this.ListViewMain);
        }

        private void ListViewMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ListViewMain.SelectedItems.Count > 0)
            {
                this.DeleteButton.Visible = true;
                this.CBChoixClasse.Visible = true;
                this.PseudoLabel.Visible = true;

                this.PseudoLabel.Text = this.ListViewMain.SelectedItems[0].Text;
                this.CBChoixClasse.Text = this.ListViewMain.SelectedItems[0].ImageKey;
            }
            else
            {
                this.DeleteButton.Visible = false;
                this.CBChoixClasse.Visible = false;
                this.PseudoLabel.Visible = false;
            }
            jsonGesture.SerializeJsonObject(this.ListViewMain);
        }

        private void CBChoixClasse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ListViewMain.SelectedItems[0].ImageKey = this.CBChoixClasse.SelectedItem.ToString();
            jsonGesture.SerializeJsonObject(this.ListViewMain);
        }

        private async void NextBtn_Enter(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Button)sender).KeyDown -= NextBtn_KeyDown;

            ((System.Windows.Forms.Button)sender).KeyDown += NextBtn_KeyDown;
            await Task.Delay(100);
        }

        private void NextBtn_KeyDown(object sender, KeyEventArgs e)
        {
            ((System.Windows.Forms.Button)sender).KeyDown -= NextBtn_KeyDown;
            ((System.Windows.Forms.Button)sender).Text = e.KeyData.ToString();
            var vkCode = e.KeyValue;

            var ButtonSelected = paramsList.Where(v => v.Name == ((System.Windows.Forms.Button)sender).Name).FirstOrDefault();
            ButtonSelected.VKValue = vkCode;
            ButtonSelected.ButtonName = e.KeyData.ToString();
            this.ListViewMain.Focus();
            jsonGesture.SerializeParams(paramsList);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int vkcode;

            switch (keyData)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    Control focusControl = null;
                    IntPtr focusHandle = GetFocus();
                    if (focusHandle != IntPtr.Zero)
                        focusControl = Control.FromHandle(focusHandle);
                    if (focusControl != null && focusControl is System.Windows.Forms.Button)
                    {
                        ((System.Windows.Forms.Button)focusControl).Text = keyData.ToString();
                        var ButtonSelected = paramsList.Where(v => v.Name == ((System.Windows.Forms.Button)focusControl).Name).FirstOrDefault();
                        if(keyData == Keys.Left)
                            ButtonSelected.VKValue = 37;
                        if (keyData == Keys.Right)
                            ButtonSelected.VKValue = 39;
                        if (keyData == Keys.Up)
                            ButtonSelected.VKValue = 38;
                        if (keyData == Keys.Down)
                            ButtonSelected.VKValue = 40;
                        ButtonSelected.ButtonName = keyData.ToString();
                        jsonGesture.SerializeParams(paramsList);
                    }
                    break;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public IntPtr hhook = IntPtr.Zero;

        public void SetHook()
        {
            // Créez une instance de la fonction de rappel
            KeyboardHookProcDelegate callback = KeyboardHookProc;

            // Enregistrez la fonction de rappel pour recevoir les notifications de touche enfoncée
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, new KeyboardHookProcDelegate(callback), IntPtr.Zero, 0);
        }

        public IntPtr KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == HC_ACTION)
            {
                KBDLLHOOKSTRUCT kbStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    //Vérifiez si la touche enfoncée est celle que vous souhaitez détecter
                    foreach (var cle in paramsList)
                    {
                        if (kbStruct.vkCode == cle.VKValue)
                        {
                            // make action
                            switch (cle.Name)
                            {
                                case "NextBtn":
                                    if (activeDofusWinFocus >= this.ListViewMain.Items.Count - 1)
                                        activeDofusWinFocus = 0;
                                    else
                                        activeDofusWinFocus++;

                                    var dofusWin = processesList.Where(p => p.MainWindowTitle.Contains(this.ListViewMain.Items[activeDofusWinFocus].Text)).FirstOrDefault();
                                    SetForegroundWindow(dofusWin.MainWindowHandle);
                                    break;
                                case "PrevBtn":
                                    if (activeDofusWinFocus <= 0)
                                        activeDofusWinFocus = this.ListViewMain.Items.Count - 1;
                                    else
                                        activeDofusWinFocus--;

                                    var dofusWin2 = processesList.Where(p => p.MainWindowTitle.Contains(this.ListViewMain.Items[activeDofusWinFocus].Text)).FirstOrDefault();
                                    SetForegroundWindow(dofusWin2.MainWindowHandle);
                                    break;
                                case "HautBtn":
                                    break;
                                case "BasBtn":
                                    break;
                                case "GaucheBtn":
                                    break;
                                case "DroiteBtn":
                                    break;
                            }
                            break;
                        }
                    }
                }
            }

            return CallNextHookEx(hhook, nCode, wParam, lParam);
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public KBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [Flags]
        internal enum KBDLLHOOKSTRUCTFlags : uint
        {
            LLKHF_EXTENDED = 0x01,
            LLKHF_INJECTED = 0x10,
            LLKHF_ALTDOWN = 0x20,
            LLKHF_UP = 0x80,
        }

        private void ListViewMain_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var proces = Process.GetProcesses().Where(p => p.MainWindowTitle.Contains(e.Item.Text)).FirstOrDefault();

            if (e.Item.Checked && !(processesList.Any(p => p.MainWindowHandle == proces.MainWindowHandle)))
            {
                processesList.Add(proces);
            }
            else if(!e.Item.Checked && processesList.Any(p => p.MainWindowHandle == proces.MainWindowHandle))
            {
                foreach(var proc in processesList)
                {
                    if(proc.MainWindowHandle == proces.MainWindowHandle)
                    {
                        processesList.Remove(proc);
                        break;
                    }
                }
            }
        }
    }
}
