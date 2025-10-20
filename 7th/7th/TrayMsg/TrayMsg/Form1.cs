using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayMsg //TextBox는 사용자가 글자를 입력할 수 있는 컨트롤
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.MsgText = this.txtMsg.Text; //Form1에 있는 TextBox(txtMsg) 의 텍스트를 가져와→ Form2의 MsgText라는 프로퍼티(속성)에 전달함.
            frm2.ShowDialog();
        }
    }
}
