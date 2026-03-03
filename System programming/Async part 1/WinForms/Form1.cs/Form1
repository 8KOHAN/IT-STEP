namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            var coffeeTask = PourCoffeeAsync();
            await Task.WhenAll(coffeeTask);

            var eggsTask = FryEggsAsync();
            var baconTask = FryBaconAsync();
            var toastTask = MakeToastAsync();
            await Task.WhenAll(eggsTask, baconTask, toastTask);

            var juiceTask = PourJuiceAsync();
            await Task.WhenAll(juiceTask);

            MessageBox.Show("Breakfast is ready!");
        }

        private async Task PourCoffeeAsync()
        {
            lblCoffee.Text = "Pouring coffee...";
            await Task.Delay(1000);
            lblCoffee.Text = "Coffee is ready!";
            progressBar1.Value += 20;
        }

        private async Task FryEggsAsync()
        {
            lblEggs.Text = "Cooking eggs...";
            await Task.Delay(2000);
            lblEggs.Text = "Eggs are ready!";
            progressBar1.Value += 20;
        }

        private async Task FryBaconAsync()
        {
            lblBacon.Text = "Frying bacon...";
            await Task.Delay(2500);
            lblBacon.Text = "Bacon is ready!";
            progressBar1.Value += 20;
        }

        private async Task MakeToastAsync()
        {
            lblToast.Text = "Toasting bread...";
            await Task.Delay(1500);

            lblToast.Text = "Spreading jam...";
            await Task.Delay(500);

            lblToast.Text = "Toast is ready!";
            progressBar1.Value += 20;
        }

        private async Task PourJuiceAsync()
        {
            lblJuice.Text = "Pouring juice...";
            await Task.Delay(800);
            lblJuice.Text = "Juice is ready!";
            progressBar1.Value += 20;
        }
    }
}
