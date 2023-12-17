using System.Diagnostics;

namespace DZCHWF2
{
    public partial class Form1 : Form
    {
        List<Tuple<string, double>> priceListBenzine = new List<Tuple<string, double>>
    {
        new Tuple<string, double>("АИ-80", 40.5),
        new Tuple<string, double>("АИ-92", 45.2),
        new Tuple<string, double>("АИ-95", 48.7),
        new Tuple<string, double>("АИ-95+", 50.0),
        new Tuple<string, double>("АИ-98", 54.3),
        new Tuple<string, double>("АИ-100", 56.8)
        };
        double X = 0;


        public Form1()
        {

            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "АИ-80", "АИ-92", "АИ-95", "АИ-95+", "АИ-98", "АИ-100" });
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            string relativeImagePath = "..\\..\\..\\example.jpg";

            try
            {
                Image img = Image.FromFile(relativeImagePath);
                pictureBox1.Image = img;
                pictureBox1.ClientSize = new Size(pictureBox1.Width, pictureBox1.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "0";
            textBox3.Text = "0";
            string selectedBenzineType = comboBox1.SelectedItem.ToString();


            Tuple<string, double> selectedBenzine = priceListBenzine.Find(b => b.Item1 == selectedBenzineType);


            textBox1.Text = selectedBenzine.Item2.ToString();
            updateFinalPrice();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void updateFinalPrice()
        {
            label10.Text = (double.Parse(label8.Text) + double.Parse(label7.Text)).ToString("0.00");

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            textBox2.Enabled = false;
            textBox2.Text = "0";
            textBox3.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Text = "0";
            textBox3.Enabled = false;
        }

        private void HandleCheckBoxStateChanged(CheckBox checkBox, TextBox textBox)
        {
            textBox.Enabled = checkBox.Checked;
            if (!textBox.Enabled)
            {
                textBox.Text = "";
            }
            else
            {
                HandleTextBoxTextChanged(textBox);
            }
            updateFinalPrice();
        }

        private void HandleTextBoxTextChanged(TextBox textBox)
        {
            try
            {
                textBox.Text = int.Parse(textBox.Text).ToString();

            }
            catch (FormatException)
            {
                textBox.Text = "0";
            }
            updateFinalPrice();
        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            HandleCheckBoxStateChanged(checkBox1, textBox11);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxStateChanged(checkBox2, textBox10);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxStateChanged(checkBox4, textBox9);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxStateChanged(checkBox3, textBox8);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            HandleTextBoxTextChanged(textBox11);
            finalPriceCafe();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            HandleTextBoxTextChanged(textBox10);
            finalPriceCafe();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            HandleTextBoxTextChanged(textBox9);
            finalPriceCafe();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            HandleTextBoxTextChanged(textBox8);
            finalPriceCafe();
        }

        private void finalPriceCafe()
        {
            label8.Text = (int.Parse(textBox11.Text) * double.Parse(textBox4.Text) +
                int.Parse(textBox10.Text) * double.Parse(textBox5.Text) +
                int.Parse(textBox9.Text) * double.Parse(textBox6.Text) +
                int.Parse(textBox8.Text) * double.Parse(textBox7.Text)
                ).ToString("0.00");
            updateFinalPrice();
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    textBox3.Text = int.Parse(textBox3.Text).ToString();
                }
                catch (FormatException)
                {
                    textBox3.Text = "0";
                }

                textBox2.Text = (priceListBenzine.Find(b => b.Item1 == comboBox1.SelectedItem.ToString()).Item2 * double.Parse(textBox3.Text)).ToString();
                label7.Text = double.Parse(textBox2.Text).ToString("0.00");
                updateFinalPrice();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                try
                {
                    textBox2.Text = int.Parse(textBox2.Text).ToString();
                }
                catch (FormatException)
                {
                    textBox2.Text = "0";
                }
                textBox3.Text = (double.Parse(textBox2.Text) / priceListBenzine.Find(b => b.Item1 == comboBox1.SelectedItem.ToString()).Item2).ToString();
                label7.Text = double.Parse(textBox2.Text).ToString("0.00");
                updateFinalPrice();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                DialogResult result;

                do
                {
                    Thread.Sleep(3000);

                    result = MessageBox.Show("Очистить форму?", "Подтверждение", MessageBoxButtons.YesNo);

                } while (result != DialogResult.Yes);
            }

            X += double.Parse(label10.Text);
            textBox3.Text = "0";
            textBox2.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            label7.Text = "0";
            label8.Text = "0";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            //OpenImage();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show($"Выручка за рабочий день : {X} руб.", "Результат", MessageBoxButtons.OK);
        }
        //просто бонус из интереса
        private void OpenImage()
        {
            Process.Start("cmd.exe", $"/c start ..\\..\\..\\example.jpg");

        }
    }
}
