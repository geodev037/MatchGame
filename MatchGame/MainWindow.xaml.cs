using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent(); //Carregamento de layout XAML

            SetUpGame();//Inicializador do jogo/interface
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐴","🐴",
                "🐍","🐍",
                "🐳","🐳",
                "🐔","🐔",
                "🐵","🐵",
                "😸","😸",
                "🐁","🐁",
                "🎁","🎁",
            };
            Random random = new Random();
            int emojiIndex = 0;

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (emojiIndex < animalEmoji.Count)
                {
                    string nextEmoji = animalEmoji[emojiIndex]; // Acesso ao próximo emoji
                    textBlock.Text = nextEmoji;
                    emojiIndex++; // Avançar para o próximo emoji
                }
                else
                {
                    textBlock.Text = ""; // Caso não haja mais emojis, limpar o TextBlock
                }
            }
        }
    }
}
