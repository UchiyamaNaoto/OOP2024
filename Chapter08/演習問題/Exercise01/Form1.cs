using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            // 2024/6/25 11:58 
            var str1 = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            tbDisp.Text = str1 + "\r\n";

            // 2024”N06Œ25“ú 1158•ª32•b 
            var str2 = dateTime.ToString("yyyy”NMMŒdd“ú HHmm•ªss•b");
            tbDisp.Text += str2 + "\r\n";

            // —ß˜a6”N 6Œ25“ú(‰Î—j“ú)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str3 = string.Format("{0}”N{1,2}Œ{2,2}“ú({3})", datestr, dateTime.Month, dateTime.Day, dayOfWeek);
            tbDisp.Text += str3;
        }

        private void btEx8_2_Click(object sender, EventArgs e) {

            var dateTime = DateTime.Today;

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {

                var str1 = string.Format("{0:yy/MM/dd}‚ÌŸT‚Ì{1}: ", dateTime, (DayOfWeek)dayofweek);
                //—ˆT‚Ì“ú•t‚ğæ“¾
                var str2 = string.Format("{0:yy/MM/dd(ddd)} ", NextWeek(dateTime, (DayOfWeek)dayofweek));
                tbDisp.Text += str1 + str2 + "\r\n";
            }
        }

        //‘æ‚Pˆø”‚Åw’è‚µ‚½“ú•t‚Ì—‚T‚ÌƒCƒ“ƒXƒ^ƒ“ƒX‚ğ•Ô‹p‚·‚éB‚½‚¾‚µA‘æ‚Qˆø”‚Åw’è‚µ‚½—j“ú‚Æ‚·‚éB
        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var day = (int)dayOfWeek - (int)date.DayOfWeek;
            return nextweek.AddDays(day);
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = String.Format( "ˆ—ŠÔ‚Í{0}ƒ~ƒŠ•b‚Å‚µ‚½", duration.TotalMilliseconds);
            tbDisp.Text = str;
        }
    }

    class TimeWatch {
        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _time;
        }

    }
}
