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

    //Timer : 일정 시간마다 자동으로 코드를 반복 실행하는 컨트롤
    //Opacity : 창의 투명도 (0.0 = 완전 투명, 1.0 = 완전 불투명)
    //이 코드는 Timer를 이용해 Opacity를 0 → 1.0으로 천천히 증가시키는 구조
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); //Visual Studio가 자동으로 만든 UI 초기화 코드
        }

        private double o = 0.0; //변수 o는 현재 투명도를 퍼센트(%)로 나타내는 임시 변수 //private임

        public string SetText //Form2의 제목(Title bar 텍스트)을 바꾸는 프로퍼티
        {
            set { this.Text = value; } //Form1에서 frm2.SetText = "모달 실행"; 이렇게 부르면→ this.Text = "모달 실행"; 이 실행돼 창 상단 제목이 “모달 실행”으로 바뀜.
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.Timer.Enabled = true; //폼이 실행될 때(Form2_Load 이벤트) Timer를 켜는 코드 //즉, Form이 로드되자마자 Timer가 작동을 시작함

        }

        private void Timer_Tick(object sender, EventArgs e) //Interval = 100 (즉, 0.1초마다 한 번씩 실행)
        {
            if(o<100.0)
            {
                o += 3.5; //o(현재 퍼센트)를 3.5씩 증가시킴.
                double c = o; //opacity -> 투명도
                double f = c / 100; //0~100% 값을 0.0~1.0 사이의 실수로 바꿔줌. 
                this.Opacity = f;
            }
            else
            {
                this.Opacity = 1.0; //// 완전히 불투명하게 설정
                this.Timer.Enabled = false; //// 타이머 멈춤 (더 이상 Tick 이벤트 발생 안 함)
                o = 0.0; // // 다음 번을 위해 초기화

            }
        }
    }
}
