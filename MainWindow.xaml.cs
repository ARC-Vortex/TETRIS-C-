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

namespace TETRIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/TileRed.png", UriKind.Relative)),
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/Block-Z.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("assets/Block-Empty.png", UriKind.Relative)),
        };

        private readonly Image[,] imageControls;

        private readonly int MAX_DELAY = 1250;
        private readonly int MIN_DELAY = 25;
        private readonly int DIFF_INCR = 75;

        private GAMEST game = new GAMEST();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SETUP(game.gr);
        }

        private Image[,] SETUP(GRID grid)
        {
            Image[,] imageControls = new Image[grid.ROWS, grid.COLUMNS];
            int CELLsz = 25;

            for (int R = 0; R < grid.ROWS; R++)
            {
                for (int C = 0; C < grid.COLUMNS; C++)
                {
                    Image imageControl = new Image
                    {
                        Width = CELLsz,
                        Height = CELLsz
                    };

                    Canvas.SetTop(imageControl, (R - 2) * CELLsz);
                    Canvas.SetLeft(imageControl, C * CELLsz);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[R, C] = imageControl;
                }
            }
            return imageControls;
        }

        private void DRGRID(GRID grid)
        {
            for (int R = 0; R < grid.ROWS; R++)
            {
                for (int C = 0; C < grid.COLUMNS; C++)
                {
                    int ID = grid[R, C];
                    imageControls[R, C].Opacity = 1;
                    imageControls[R, C].Source = tileImages[ID];

                }
            }
        }

        private void DRBLOCK(BLOCK block)
        {
            foreach (POSITION P in block.TILE_POSITION())
            {
                imageControls[P.ROW, P.COLUMN].Opacity = 1;
                imageControls[P.ROW, P.COLUMN].Source = tileImages[block.ID];

            }
        }

        private void DR_NXT_BLOCK(BLOCKQUEUE blockQueue)
        {
            BLOCK NXT = blockQueue.nxt_BLOCK;
            NextImage.Source = blockImages[NXT.ID];
        }

        private void DR_GHS_BLOCK(BLOCK block)
        {
            int dropDist = game.BLOCK_DROP_DIST();

            foreach (POSITION P in block.TILE_POSITION())
            {
                imageControls[P.ROW + dropDist, P.COLUMN].Opacity = 0.375;
                imageControls[P.ROW + dropDist, P.COLUMN].Source = tileImages[block.ID];
            }
        }

        private void DR(GAMEST game)
        {
            DRGRID(game.gr);
            DR_GHS_BLOCK(game.CurrentBlock);
            DRBLOCK(game.CurrentBlock);
            DR_NXT_BLOCK(game.blockQueue);
            ScoreText.Text = $"Score: {game.Score}";
        }

        private async Task MAIN()
        {
            DR(game);

            while (!game.gameOver)
            {
                int DELAY = Math.Max(MIN_DELAY, MAX_DELAY - (game.Score * DIFF_INCR));
                await Task.Delay(DELAY);
                game.MOVE_BLOCK_DW();
                DR(game);
            }

            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoreText.Text = $"Final Score: {game.Score}";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.gameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.A:
                    game.MOVE_LEFT();
                    break;
                case Key.D:
                    game.MOVE_RIGHT();
                    break;
                case Key.Down:
                    game.MOVE_BLOCK_DW();
                    break;
                case Key.Up:
                    game.ROT_BLOCK_CW();
                    break;
                case Key.Z:
                    game.ROT_BLOCK_CCW();
                    break;
                case Key.S:
                    game.DROP();
                    break;
                default:
                    return;
            }

            DR(game);
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await MAIN();
        }

        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            game = new GAMEST();
            GameOverMenu.Visibility = Visibility.Hidden;
            await MAIN();
        }
    }
}
