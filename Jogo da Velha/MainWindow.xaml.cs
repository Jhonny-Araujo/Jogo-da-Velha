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



namespace Jogo_da_Velha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

/****************************************************************************************************************************************/
        private String XouO; //Variavel para setar se é X ou O;
        private int jgd1, jgd2, empt;
        
        private void iniciar_Jogo()
        {
           
            limpar_Tela();
            liberar_Botoes();
            XouO = "X";
        }

        private void liberar_Botoes()//Habilita os botoes para que possam ser marcados
        {
            Botao_1_1.IsEnabled = true;
            Botao_1_2.IsEnabled = true;
            Botao_1_3.IsEnabled = true;

            Botao_2_1.IsEnabled = true;
            Botao_2_2.IsEnabled = true;
            Botao_2_3.IsEnabled = true;

            Botao_3_1.IsEnabled = true;
            Botao_3_2.IsEnabled = true;
            Botao_3_3.IsEnabled = true;
        }

        private void travar_Botoes()//Desabilita o uso dos botoes (usa quando acaba o jogo e tem botoes a serem usados ainda)
        {
            Botao_1_1.IsEnabled = false;
            Botao_1_2.IsEnabled = false;
            Botao_1_3.IsEnabled = false;

            Botao_2_1.IsEnabled = false;
            Botao_2_2.IsEnabled = false;
            Botao_2_3.IsEnabled = false;

            Botao_3_1.IsEnabled = false;
            Botao_3_2.IsEnabled = false;
            Botao_3_3.IsEnabled = false;
        }
        private void limpar_Tela() //Usado para tirar o texto dos botões (para poder iniciar o jogo)
        {
            Botao_1_1.Content = "";
            Botao_1_2.Content = "";
            Botao_1_3.Content = "";

            Botao_2_1.Content = "";
            Botao_2_2.Content = "";
            Botao_2_3.Content = "";

            Botao_3_1.Content = "";
            Botao_3_2.Content = "";
            Botao_3_3.Content = "";
        }
        private void inverte_Jogada() //Inverte a vez do jogador
        {
            if (XouO == "O")
                XouO = "X";
            else if (XouO == "X")
                XouO = "O"; 
        }
        private void realizar_Jogada(Button botaoAuxiliar) //Fazer a jogada, modificação o texto do Botão, olha se tem vencedor
        {
           
            botaoAuxiliar.Content = XouO;
            botaoAuxiliar.IsEnabled = false;
            inverte_Jogada();
            verificar_Vencedor();
   
        }

        private void verificar_Vencedor() //Verifica se Jogo chegou ao fim
        {
            
            
            if ((Botao_1_1.Content == "X" && Botao_1_2.Content == "X" && Botao_1_3.Content == "X") ||
            (Botao_1_1.Content == "X" && Botao_2_1.Content == "X" && Botao_3_1.Content == "X") ||
            (Botao_1_2.Content == "X" && Botao_2_2.Content == "X" && Botao_3_2.Content == "X") ||
            (Botao_1_3.Content == "X" && Botao_2_3.Content == "X" && Botao_3_3.Content == "X") ||
            (Botao_2_1.Content == "X" && Botao_2_2.Content == "X" && Botao_2_3.Content == "X") ||
            (Botao_3_1.Content == "X" && Botao_3_2.Content == "X" && Botao_3_3.Content == "X") ||
            (Botao_1_1.Content == "X" && Botao_2_2.Content == "X" && Botao_3_3.Content == "X") ||
            (Botao_3_1.Content == "X" && Botao_2_2.Content == "X" && Botao_1_3.Content == "X"))
            {
                jgd1++;
                travar_Botoes();
                MessageBox.Show("JOGADOR 1 VENCEU!!!");
                    
            }
            else if ((Botao_1_1.Content == "O" && Botao_1_2.Content == "O" && Botao_1_3.Content == "O") ||
            (Botao_1_1.Content == "O" && Botao_2_1.Content == "O" && Botao_3_1.Content == "O") ||
            (Botao_1_2.Content == "O" && Botao_2_2.Content == "O" && Botao_3_2.Content == "O") ||
            (Botao_1_3.Content == "O" && Botao_2_3.Content == "O" && Botao_3_3.Content == "O") ||
            (Botao_2_1.Content == "O" && Botao_2_2.Content == "O" && Botao_2_3.Content == "O") ||
            (Botao_3_1.Content == "O" && Botao_3_2.Content == "O" && Botao_3_3.Content == "O") ||
            (Botao_1_1.Content == "O" && Botao_2_2.Content == "O" && Botao_3_3.Content == "O") ||
            (Botao_3_1.Content == "O" && Botao_2_2.Content == "O" && Botao_1_3.Content == "O"))
            {
                travar_Botoes();
                MessageBox.Show("JOGADOR 2 VENCEU!!!");
                jgd2++;
            }

            else if(Botao_1_1.Content != "" && Botao_1_2.Content != "" && Botao_1_3.Content != "" &&
            Botao_2_1.Content != "" && Botao_2_2.Content != "" && Botao_2_3.Content != "" &&
            Botao_3_1.Content != "" && Botao_3_2.Content != "" && Botao_3_3.Content != "")
            {
                MessageBox.Show("EMPATE!!!");
                empt++;
            }

            lbl_jogador1.Content = "Jogador 1: "+jgd1;
            lbl_jogador2.Content = "Jogador 2: "+jgd2;
            lbl_empate.Content = "EMPATE: "+ empt;

            if (XouO == "O") //Caso o jogo não tenha chegado ao fim, passa a vez para a máquina
            {
                IA();
            }

        }

        private void IA() //Cria uma pequena inteligência, para jogar contra o play 1
        {
            //IA BURRA (Sorteia um botão aleatorio)
            if (true)
            {
                //string XouO_maquina = "O";// Variavel a ser usada quando o jogador escolher se prefero X ou O;
                bool jogadaRealizada = false;
                int botaoPressionado;
                Random random = new Random();

                while (!jogadaRealizada) //Enquanto o botão selecionado não for válido...
                {
                    botaoPressionado = random.Next(1, 9);
                    if ((botaoPressionado == 1) && Botao_1_1.IsEnabled) //verifica se o botão escolhido esta disponivel
                    {
                        realizar_Jogada(Botao_1_1);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 2) && Botao_1_2.IsEnabled)
                    {
                        realizar_Jogada(Botao_1_2);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 3) && Botao_1_3.IsEnabled)
                    {
                        realizar_Jogada(Botao_1_3);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 4) && Botao_2_1.IsEnabled)
                    {
                        realizar_Jogada(Botao_2_1);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 5) && Botao_2_2.IsEnabled)
                    {
                        realizar_Jogada(Botao_2_2);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 6) && Botao_2_3.IsEnabled)
                    {
                        realizar_Jogada(Botao_2_3);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 7) && Botao_3_1.IsEnabled)
                    {
                        realizar_Jogada(Botao_3_1);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 8) && Botao_3_2.IsEnabled)
                    {
                        realizar_Jogada(Botao_3_2);
                        jogadaRealizada = true;
                    }
                    else if ((botaoPressionado == 9) && Botao_3_3.IsEnabled)
                    {
                        realizar_Jogada(Botao_3_3);
                        jogadaRealizada = true;
                    }


                    //Verfica se o jogo acabou (para sair do loop, caso play vencer vencedor)
                    else if(!Botao_1_1.IsEnabled && !Botao_1_2.IsEnabled && !Botao_1_3.IsEnabled &&
                            !Botao_2_1.IsEnabled && !Botao_2_2.IsEnabled && !Botao_2_3.IsEnabled &&
                            !Botao_3_1.IsEnabled && !Botao_3_2.IsEnabled && !Botao_3_3.IsEnabled)
                    {
                        jogadaRealizada = true;
                    }

                }
                

               
            }
        }
/*******************************************************************************************************************************************/

        public MainWindow()
        {
            InitializeComponent();
            iniciar_Jogo();
        }

        private void Botao_1_1_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_1_1);
        }

        private void Botao_1_2_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_1_2);
        }

        private void Botao_1_3_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_1_3);
        }

        private void Botao_2_1_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_2_1);
        }

        private void Botao_2_2_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_2_2);
        }

        private void Botao_2_3_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_2_3);
        }

        private void Botao_3_1_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_3_1);
        }

        private void Botao_3_2_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_3_2);
        }

        private void Botao_3_3_Click(object sender, RoutedEventArgs e)
        {
            realizar_Jogada(Botao_3_3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            iniciar_Jogo();
        }
    }
}
