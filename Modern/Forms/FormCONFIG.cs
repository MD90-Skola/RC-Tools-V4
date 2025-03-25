using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Modern.Forms
{
    public partial class FormCONFIG : Form
    {
        public FormCONFIG()
        {
            InitializeComponent();
        }


        // LOAD FORM



        private void FormCONFIG_Load(object sender, EventArgs e)
        {
            checkedListBox1.DrawItem += checkedListBox1_DrawItem;
            checkedListBox1.MouseDown += checkedListBox1_MouseDown;
            checkedListBox1.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBox1.ItemHeight = 48;












            List<string> apps = FunctionBloatWare.GetBloatwareList();




            foreach (string app in apps)
            {
                checkedListBox1.Items.Add(app);
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            List<string> selected = new List<string>();

            foreach (string item in checkedListBox1.CheckedItems)
            {
                selected.Add(item);
            }

            if (selected.Count > 0)
            {
                FunctionBloatWare.RemoveBloatware(selected);
                MessageBox.Show("Valda appar försöker nu tas bort.");
            }
            else
            {
                MessageBox.Show("Välj minst en app att ta bort.");
            }
        }

        //////////////////////////////////////////////////////////
        ///////////////    FORM DESIGN     ///////////////////////
        /////////////////////////////////////////////////////////




        private void checkedListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int index = checkedListBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                bool current = checkedListBox1.GetItemChecked(index);
                checkedListBox1.SetItemChecked(index, !current);
            }
        }








        private void checkedListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= checkedListBox1.Items.Count)
                return;

            e.DrawBackground();

            bool isChecked = checkedListBox1.GetItemChecked(e.Index);
            string text = checkedListBox1.Items[e.Index].ToString();

            // Rita checkbox
            CheckBoxState state = isChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
            Size checkBoxSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);

            // Position för checkbox
            int checkboxX = e.Bounds.Left + 10;
            int checkboxY = e.Bounds.Top + (e.Bounds.Height - checkBoxSize.Height) / 2;
            CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(checkboxX, checkboxY), state);

            // Position för text
            Rectangle textRect = new Rectangle(
                checkboxX + checkBoxSize.Width + 10,
                e.Bounds.Top,
                e.Bounds.Width - checkboxX - checkBoxSize.Width - 20,
                e.Bounds.Height
            );

            TextRenderer.DrawText(
                e.Graphics,
                text,
                e.Font,
                textRect,
                e.ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            e.DrawFocusRectangle();
        }




        /// //////////////////////////////////////////////////////



        // delete button tar bort alla appar
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selected = new List<string>();

            foreach (string item in checkedListBox1.CheckedItems)
            {
                selected.Add(item);
            }

            if (selected.Count > 0)
            {
                FunctionBloatWare.RemoveBloatware(selected);
                MessageBox.Show("Valda appar försöker nu tas bort.");
            }
            else
            {
                MessageBox.Show("Välj minst en app att ta bort.");
            }
        }



        private bool allSelected = false;


        private void button2_Click(object sender, EventArgs e)
        {

            allSelected = !allSelected;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, allSelected);
            }

            // Ändra knapptext för att ge visuell feedback (valfritt)
            button2.Text = allSelected ? "Avmarkera" : "Välj alla";


        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}