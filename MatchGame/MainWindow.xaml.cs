using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatchGame
{
    public partial class MainWindow : Window
    {
        private List<string> animalEmoji = new List<string>()
        {
            "🐴", "🐴",
            "🐍", "🐍",
            "🐳", "🐳",
            "🐔", "🐔",
            "🐵", "🐵",
            "😸", "😸",
            "🐁", "🐁",
            "🎁", "🎁",
        };

        private List<TextBlock> textBlocks = new List<TextBlock>();
        private List<int> revealedIndexes = new List<int>(); // Índices dos emojis revelados

        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            Random random = new Random();
            int emojiIndex = 0;

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                textBlocks.Add(textBlock);
                textBlock.Text = "?";
                textBlock.MouseDown += TextBlock_MouseDown; // Adiciona o evento MouseDown a cada TextBlock
            }
        }
        
        private async void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            int index = textBlocks.IndexOf(textBlock);

            // Verifica se o emoji já foi encontrado ou se já estão duas imagens reveladas
            if (textBlock.Text != "?" || revealedIndexes.Contains(index) || revealedIndexes.Count >= 2)
                return;

            textBlock.Text = animalEmoji[index];
            revealedIndexes.Add(index);

            if (revealedIndexes.Count == 2)
            {
                await Task.Delay(1000); // Aguarda 1 segundo antes de verificar os emojis

                int index1 = revealedIndexes[0];
                int index2 = revealedIndexes[1];

                if (animalEmoji[index1] != animalEmoji[index2])
                {
                    // Se não formam um par correto, esconde os emojis novamente
                    textBlocks[index1].Text = "?";
                    textBlocks[index2].Text = "?";
                }

                revealedIndexes.Clear(); // Limpa os índices revelados para o próximo par
            }
        }
    }
}
