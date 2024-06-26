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

            // 2024�N06��25�� 11��58��32�b 
            var str2 = dateTime.ToString("yyyy�NMM��dd�� HH��mm��ss�b");
            tbDisp.Text += str2 + "\r\n";

            // �ߘa6�N 6��25��(�Ηj��)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str3 = string.Format("{0}�N{1,2}��{2,2}��({3})", datestr, dateTime.Month, dateTime.Day, dayOfWeek);
            tbDisp.Text += str3;
        }

        private void btEx8_2_Click(object sender, EventArgs e) {

            var dateTime = DateTime.Today;

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {

                var str1 = string.Format("{0:yy/MM/dd}�̎��T��{1}: ", dateTime, (DayOfWeek)dayofweek);
                //���T�̓��t���擾
                var str2 = string.Format("{0:yy/MM/dd(ddd)} ", NextWeek(dateTime, (DayOfWeek)dayofweek));
                tbDisp.Text += str1 + str2 + "\r\n";
            }
        }

        //��P�����Ŏw�肵�����t�̗��T�̃C���X�^���X��ԋp����B�������A��Q�����Ŏw�肵���j���Ƃ���B
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
            var str = String.Format( "�������Ԃ�{0}�~���b�ł���", duration.TotalMilliseconds);
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
