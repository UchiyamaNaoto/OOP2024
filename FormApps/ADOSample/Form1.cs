using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202400DataSet.Books' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.booksTableAdapter.Fill(this.infosys202400DataSet.Books);
            // TODO: このコード行はデータを 'infosys202400DataSet.Authors' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        }

        private void booksBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.booksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202400DataSet);

        }

        private void button1_Click(object sender, EventArgs e) {
            this.booksTableAdapter.FillByYear(this.infosys202400DataSet.Books, (int)numericUpDown1.Value);
        }
    }
}
