namespace TUTOR_NET105_SU23.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var respone = await httpClient.GetAsync("https://localhost:7196/WeatherForecast/Get");
            var content = await respone.Content.ReadAsStringAsync();

            MessageBox.Show(content, "API Respone");
        }
    }
}