using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Length != 8)
            {
                MessageBox.Show("HN帳號為八碼請檢查輸入！","提示");
                return;
            }
            String info = "rasdial 寬頻連線 " + textBox1.Text + "@hinet.net " + textBox1.Text;
            Encoding encoding = Encoding.GetEncoding("big5");
            using (StreamWriter writer = new StreamWriter(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\NtunhsNetLogin.cmd", false, encoding))
            {
                writer.Write(info);
                writer.Close();
                System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\NtunhsNetLogin.cmd");
                MessageBox.Show("設定已經完成");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請記得需使用管理員身分來執行\n此程式只適用於windows，且完全無惡意用於非營利。\n並開放原始碼於https://hackmd.io/@real7660/SkEX2Svyn，僅供學術使用。\n如果有任何問題可以聯絡112214102@ntunhs.edu.tw", "聲明");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請點選寬頻然後直接按建立(不用輸入任何字)");
                string cmd = "rasphone -a";
                System.Diagnostics.Process.Start("CMD.exe","/K " + cmd);
            
        }
    }
}
