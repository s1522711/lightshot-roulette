using System.Security.Policy;

namespace lightshot_roulette
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string templateUrl = "https://prnt.sc/";
            Random random = new Random();
            string randomString = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz0123456789", 6).Select(s => s[random.Next(s.Length)]).ToArray());
            string url = templateUrl + randomString;
            textBox1.Text = url;
            chromiumWebBrowser1.Load(url);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load(textBox1.Text);
            //pictureBox1.ImageLocation = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.LoadUrl("https://media.retardhub.xyz/lightshot/");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
            GlobalVars.timerCounter = (double)numericUpDown1.Value;
            if (checkBox1.Checked)
            {
                timer1.Start();
                label2.Visible = true;
            }
            else
            {
                timer1.Stop();
                label2.Visible = false;
            }
        }

        static class GlobalVars
        {
            public static double timerCounter = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GlobalVars.timerCounter > 0)
            {
                GlobalVars.timerCounter -= 0.01;
                label2.Text = Math.Abs(GlobalVars.timerCounter).ToString("0.00");
            }
            else
            {
                button1.PerformClick();
                GlobalVars.timerCounter = (double)numericUpDown1.Value;
            }
        }
    }
}
