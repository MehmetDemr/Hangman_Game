using System.Diagnostics.Eventing.Reader;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Diagnostics.Metrics;

namespace HangMan_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public int health = 5;
        public bool game = true;
        public static string chosen1="";
        public string[] list1 = {};
        


        public static string RemoveWhiteSpace(string input)// Return the string with whitespaces removed and converted to lowercase
        {
            int whitespaceIndex = input.IndexOf(' ');
            string withoutWhitespace;

            if (whitespaceIndex != -1)
            {
                withoutWhitespace = input.Trim();
            }
            else
            {
                withoutWhitespace = input.TrimEnd();
            }

            string lowercase = withoutWhitespace.ToLower();
            return lowercase;
        }


       
        private void button7_Click_1(object sender, EventArgs e)
        {
            int currentIndex = tabControl1.SelectedIndex;
            int nextIndex = (currentIndex + 1) % tabControl1.TabCount;
            tabControl1.SelectedIndex = nextIndex;
            //next button

        }










        private void GameLogic()//game mechanics
        {

           

            
    
            string chosen = richTextBox1.Text;
            string m = textBox2.Text;
            int whitespaceIndex = m.IndexOf(' ');
            

            if (whitespaceIndex != -1)
            {
                m = m.Trim();
            }
            else
            {
                m = m.TrimEnd();
            }

            string n = RemoveWhiteSpace(m);


            if (string.IsNullOrEmpty(chosen1) || string.IsNullOrEmpty(n) || (chosen1 == ""))//Bug control
            {

                MessageBox.Show("Unexpected Error!");


            }

            else if (!string.IsNullOrEmpty(chosen1) && chosen1.Contains(n))
            {
                // Check if the chosen word contains the guessed letter (n)
                for (int indeks = 0; indeks < chosen1.Length; indeks++)
                {
                    if (n == chosen1[indeks].ToString())
                    {
                        // Update the displayed word with the correctly guessed letter
                        chosen = chosen.Substring(0, indeks) + n + chosen.Substring(indeks + 1);



                        richTextBox1.Text = chosen;

                        // Colorize the richTextBox to highlight the guessed letters
                        for (int i = 0; i < chosen.Length; i++)
                        {

                            richTextBox1.SelectionStart = i;
                            richTextBox1.SelectionLength = 1;

                            if (i % 3 == 0)
                            {
                                richTextBox1.SelectionColor = System.Drawing.Color.OrangeRed;
                            }
                            else if (i % 3 == 1)
                            {
                                richTextBox1.SelectionColor = System.Drawing.Color.DeepSkyBlue;
                            }
                            else
                            {
                                richTextBox1.SelectionColor = System.Drawing.Color.DarkRed;
                            }

                        }


                    }
                }

                // Check if the word has been completely guessed

                if (!chosen.Contains("_"))
                {
                    MessageBox.Show("Congratulations! You won the game.");
                    health = 5;
                    game = false;
                    richTextBox1.Clear();
                    textBox2.Clear();
                    label4.Text = "LETS PLAY!";
                    chosen1 = "";
                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.fullhealth;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;

                }

                else if (m == chosen1)
                {
                    
                    

                    MessageBox.Show("Congratulations! You Guessed it well :)");

                    health = 5;

                    game = false;

                    richTextBox1.Clear();

                    textBox2.Clear();
                    label4.Text = "LETS PLAY!";

                    chosen1 = "";
                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.fullhealth;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;


                }

            }
            else
            {
                health--;

                if (health == 0)
                {

                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.game_over;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman_5;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                    // Reset UI elements for a new game


                    MessageBox.Show("I am sorry! You lost the game. Correct word: " + chosen1);
                    game = false;
                    health = 5;
                    richTextBox1.Clear();
                    textBox2.Clear();
                    chosen1 = "";

                    label4.Text = "LETS PLAY!";
                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.fullhealth;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;

                }

                else if (health == 4)
                {

                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.mistake_1;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman_1;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                }

                else if (health == 3)
                {

                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.mistake_2;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman_2;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (health == 2)
                {

                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.mistake_3;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman_3;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (health == 1)
                {

                    pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.mistake_4;

                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                    pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman_4;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                }

            }


            textBox3.Text = health.ToString();
            game = true;
            if (string.IsNullOrEmpty(chosen1) || (chosen1 == ""))
            {

                textBox3.Clear();


            }

        }

        static int RandomIndex(int arraylength)//choosing random word from string array
        {
            Random random = new Random();
            int randomIndex = random.Next(0, arraylength);
            return randomIndex;
        }

        private void button1_Click(object sender, EventArgs e)//mode selection
        {
            label1.Text = "Easy Mode Selected";
            button7.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Medium Mode Selected";
            button7.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Hard Mode Selected";
            button7.Visible = true;
        }
        //exit button
        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }


        private void button5_Click(object sender, EventArgs e)
        {
            //guess button

            GameLogic();




        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //you cant write over textboxes
            richTextBox1.ReadOnly = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //start button

            try
            {
                // Set initial images and styles for UI elements

                pictureBox1.BackgroundImage = HangMan_Game.Properties.Resources.fullhealth;

                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

                pictureBox2.BackgroundImage = HangMan_Game.Properties.Resources.hangman;

                pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                richTextBox1.Font = new System.Drawing.Font("Arial", 25);

                // Set up word lists based on the selected difficulty level

                if (label1.Text == "Easy Mode Selected")
                {
                    list1 = new string[] { "apple", "banana", "strawberry", "blueberry", "blackberry", "pear", "grape", "orange", "grapefruit", "plum" };
                    label6.Text = "ITS A FRUIT GOOD LUCK";
                    label6.Visible = true;

                }
                else if (label1.Text == "Medium Mode Selected")
                {

                     list1 = new string[] { "london", "dublin", "tallin", "vilnius", "minsk", "warsaw", "berlin", "kiev", "abuja", "ankara", "beijing", "tokyo", "seul", "mexico city" };

                   

                    label6.Text = "ITS A CAPITAL CITY GOOD LUCK";
                    label6.Visible = true;
                }

                else if (label1.Text == "Hard Mode Selected")
                {
                    list1 = new string[] { "namibia", "cameroon", "liberia", "estonia", "kazakhstan", "bangladesh", "malaysia", "singapore", "paraguay", "nigeria", "uzbekistan" };
                    label6.Text = "ITS A COUNTRY GOOD LUCK";
                    label6.Visible = true;
                }

                else
                {

                    MessageBox.Show("Unexpected Error!");
                }

                // Choose a random word from the selected difficulty level list
                int randomIndex = RandomIndex(list1.Length);
                chosen1 = list1[randomIndex];

                char[] s = chosen1.ToCharArray();

                string m = "";

                // Create a masked version of the word for display in the richTextBox

                foreach (char character in s)
                {
                    if (char.IsWhiteSpace(character))
                    {
                        m += " ";
                    }
                    else
                    {
                        m += "_";
                    }
                }

                richTextBox1.Text = m;

                for (int i = 0; i < m.Length; i++)
                {
                    if (m[i] == '_')
                    {
                        richTextBox1.SelectionStart = i;
                        richTextBox1.SelectionLength = 1;

                        if (i % 3 == 0)
                        {
                            richTextBox1.SelectionColor = System.Drawing.Color.OrangeRed;
                        }
                        else if (i % 3 == 1)
                        {
                            richTextBox1.SelectionColor = System.Drawing.Color.DeepSkyBlue;
                        }
                        else
                        {
                            richTextBox1.SelectionColor = System.Drawing.Color.DarkRed;
                        }
                    }
                }
                label4.Text = "The word consists of " + chosen1.Length.ToString() + " letters!!";
                textBox3.Text = health.ToString();
            }

            catch
            {
                MessageBox.Show("You have to choose any game mode!");

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {


        }

        private void button8_Click(object sender, EventArgs e)//back button
        {
            int currentIndex = tabControl1.SelectedIndex;
            int nextIndex = (currentIndex - 1) % tabControl1.TabCount;
            tabControl1.SelectedIndex = nextIndex;
        }

        
    }
}
