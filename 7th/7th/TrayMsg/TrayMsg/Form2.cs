using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TrayMsg //테두리(창 프레임)가 없는 폼. None //이 Form2는 작고, 테두리 없는, 항상 위에 표시되는 알림창(트레이 메시지 창) 역할을 하도록 설정된 폼
{

    //이 코드는 오른쪽 아래에서 슬라이드-업으로 나타났다 잠깐 머물고 다시 슬라이드-다운으로 사라지는 “트레이 메시지” 창(Form2) 을 만드는 예제
    //System.Timers.Timer 로 주기적으로 UI를 갱신
    //UI 스레드에 안전하게 반영하려고 Invoke(델리게이트)를 쓰는 구조
    public partial class Form2 : Form
    {
        public Form2()
        {
            //폼(Form2) 의 화면 표시 위치를 “오른쪽 아래 구석”으로 정확히 맞추는 코드
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20; // 스크린의 가로위치 //좌표값으로 지정해줘야함 위치를 어케잡아야하냐  디자인 속성에서 오른아래에 배치한다고 만듬
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height; // 스크린의 세로위치

            DesktopLocation = new Point(x, y); //폼의 위치 설정 //x,y위치잡았으니 데스크탑의 위치 잡아준다 
            this.Size = new Size(170, 0); //폼의 크기 설정 //초기값 왜? 숨겨져있다 너비 170만 있고 높이는 아직 지정안한상태로 //Size(170, 0)으로 세로 높이를 0으로 둬 아직 보이지 않게.

            InitializeComponent();
        }

        private static System.Timers.Timer TimerEvent; //Timer 개체 생성  

        public string MsgText //이 속성에 대한 정의를 내려야한다 //대문자(M) 시작 set을 통해 값을 파라미터로 읽어와 lblResult에 할당,텍스트를 가져와 그대로 여기에 표시해준다 . 
        {
            set
            { 
                this.lblResult.Text = value;
            }
        }

        private delegate void OnDelegateHeight(int Flag); //델리게이트 선언 //UI 스레드에서 높이/위치 변경을 실행하기 위해 델리게이트를 준비.
        //System.Timers.Timer는 스레드풀 스레드에서 콜백이 오므로, UI 접근은 반드시 Invoke 필요.

        private OnDelegateHeight OnHeight = null; //델리게이트 개체 생성

        private void lblResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //유저가 메시지(링크라벨)를 클릭하면 즉시 닫기 + 타이머 중지.
        {
            this.Close();
            TimerEvent.Stop();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OnHeight = new OnDelegateHeight(MsgView); //델리게이트에 실행 로직(MsgView)을 연결.

            //크기/위치 재설정
            this.Size = new System.Drawing.Size(170, 0);
            this.Location = new System.Drawing.Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height
            );

            TimerEvent = new System.Timers.Timer(2);
            TimerEvent.Elapsed += new ElapsedEventHandler(OnPopUp);
            TimerEvent.Start();
        }

        private void MsgView(int Flag) //왜 이렇게 되는지 이해하기
        {
            if (Flag == 0)
            {
                Height++;
                Top--;
            }
            else if (Flag == 1)
            {
                Height--;
                Top++;
            }
            else if (Flag == 2)
            {
                this.Close();
            }
        }

        private void OnPopUp(object sender, ElapsedEventArgs e)
        {
            if (Height < 120)
            {
                Invoke(OnHeight, 0);
            }
            else
            {
                TimerEvent.Stop();
                TimerEvent.Elapsed -= new ElapsedEventHandler(OnPopUp);
                TimerEvent.Elapsed += new ElapsedEventHandler(OnPopOut);
                TimerEvent.Interval = 3000;
                TimerEvent.Start();
            }
            Application.DoEvents();
        }

        private void OnPopOut(object sender, ElapsedEventArgs e)
        {
            while (Height > 2)
            {
                Invoke(OnHeight, 1);
            }
            TimerEvent.Stop();
            Application.DoEvents();
            Invoke(OnHeight, 2);
        }

        //델리게이트 : 메서드를 변수처럼 저장하고 전달하는 포인터
        //Invoke() : “다른 스레드에서 UI를 건드리지 말고, UI 스레드에게 대신 실행시켜 달라고 부탁하는 것” 
    }
}
