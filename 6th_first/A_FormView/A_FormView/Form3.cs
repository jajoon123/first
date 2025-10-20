using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_FormView
{
    //이 코드는 폼(Form)의 크기(Width, Height)를 점점 키워주는 애니메이션 효과를 만드는 거
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string SetText
        {
            set { this.Text = value; }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e) //타이머의 Tick 이벤트 핸들러야.
        {
            if (this.Size.Width >= 300 && this.Size.Height >= 300) //현재 폼의 가로(Width)와 세로(Height)가 300 이상인지 확인하는 조건.
            {
                this.Timer.Enabled = false; //조건을 만족하면 타이머를 끔 → 폼 커지는 동작 멈춤
            }
            else
            {
                this.Size += new Size(10, 10); //현재 폼의 크기에 가로 10, 세로 10 픽셀씩 더함.
            }
        }
    }
}
