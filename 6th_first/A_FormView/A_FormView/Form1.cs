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
    public partial class Form1 : Form
    {
        public Form1() //생성자 
        {
            InitializeComponent(); // Visual Studio 디자이너에서 설정한 버튼, 크기, 위치, 이벤트 연결 등을 자동으로 초기화.
        }

        private void btnModal_Click(object sender, EventArgs e) //Dialog() -> 대화상자
        {
            Form2 frm2 = new Form2(); //Form2 객체 생성 → 새 창 준비
            frm2.ShowDialog(); //이거로 하면 아래 코드가 적용이 안되고 form2에 text가 실행됨 //Form2를 모달 방식으로 띄움(이때 Form1은 잠김 상태 (버튼, 입력 등 사용 불가))
                               //Form2가 닫힐 때까지 아래 코드는 잠시 멈춤 Form2 창을 닫고 나서야→ frm2.SetText = this.btnModal.Text + " 실행"; 실행됨.
            frm2.SetText = this.btnModal.Text + " 실행"; //btnModal에 텍스트

        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(); //Form3 객체 생성 (인스턴스 또는 객체)
            frm3.Show(); // 이거는 아래께 적용됨 //orm3을 모달리스(비모달) 로 띄움 Form1을 계속 사용할 수 있음(둘 다 활성)
            frm3.SetText = this.btnModaless.Text + " 실행"; //바로 다음 줄 실행


        }


        //모달과 모달리스 차이점



        //모달(Modal) : 새 모달 창이 열렸을때 기존에 있던 창을 사용하지 못하는 방식 -> ShowDialog()

        // 새 창(Form)을 띄웠을 때, 그 창을 닫기 전까지 다른 창(부모 폼)을 조작할 수 없는 상태



        //모달리스(Modaless) : 어느 하나의 다이얼로그 창이 있어도 프로그램 제어권을 독점하지 않으므로 다른 작업을 할 수 있는 것이다. -> Show()

            //새 창을 띄워도 기존 창(부모 폼)을 계속 사용할 수 있는 상태


    }
}
