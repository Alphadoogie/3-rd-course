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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Threading;
namespace KP_WPF

{
    public partial class Test : Window
    {
        bool testIsStarted = false;
        int currentAnswer = 0;
        int trueAnswers = 0;
        int[] answers = {1,2,3,3,2,1,4,2,2};

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public bool TestIsStarted { get => testIsStarted; set => testIsStarted = value; }

        private void test()
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        public void EndTest()
        {
            TestGrid.Visibility = Visibility.Collapsed;
            ResultTB.Text = $"Ваш результат: {trueAnswers} из 9";
            if(trueAnswers <=2)
            {
                ResultTBText.Text = "Вы плохой человек!";
            }
            else if (trueAnswers >2 && trueAnswers <= 4)
            {
                ResultTBText.Text = "Вы хороший человек!";
            }
            else if (trueAnswers > 4 && trueAnswers <= 7)
            {
                ResultTBText.Text = "Вы очень хороший человек!";
            }
            else if (trueAnswers > 7 && trueAnswers <= 9)
            {
                ResultTBText.Text = "Вы очень плохой человек!";
            }
        
            FinishGrid.Visibility = Visibility.Visible;
            
         

        }
        public Test()
        {
            InitializeComponent();
            Background = Theme.background;
            test();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
            this.Close();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
          
            Main main = new Main();
            main.Show();
            this.Close();
            
        }

        public void CheckAnswer(int answer)
        {
            if(answers[currentAnswer] == answer)
            {
                trueAnswers++;
            }
            currentAnswer++;
            if (currentAnswer == 9)
            {
                PB.Value++;
                EndTest();
            }
            else
            {
                ChangeImg();
                PB.Value++;
            }
        }
        private void ChangeImg()
        {
            ImageSourceConverter converter = new ImageSourceConverter();
            switch (currentAnswer)
            {
                case 1:
                    IMG.Source = (ImageSource)converter.ConvertFromString("test4.png");
                    Quest.Text = "Вы добрались до работы. Выяснилось, что курьер потерял папку с документами, которые вы готовили вчера. Что делать?";
                    FirstAnswer.Content = "Переделывать! Но одному спеть нереально, так что попрошу помощи коллег";
                    SecondAnswer.Content = "Быстро переквалифицирую курьера в специалиста по документообороту.";
                    ThirdAnswer.Content = "Напишу гневное письмо на почту боссу, потом примусь восстанавливать документы";
                    FourthAnswer.Content = "Ой, бедный курьер, он, наверное так переживает, напою его чаем";
                    break;
                case 2:
                    IMG.Source = (ImageSource)converter.ConvertFromString("test3.png");
                    Quest.Text = "Босс? Я здесь босс и я уже дома";
                    FirstAnswer.Content = "НЛП и гипноз и мой босс уже не хочет меня видеть";
                    SecondAnswer.Content = "Останусь, но сбегу как только он вернется";
                    ThirdAnswer.Content = "Получится золотой дракон?";
                    FourthAnswer.Content = "Конечно останусь";
                    break;
                case 3:
                   IMG.Source = (ImageSource)converter.ConvertFromString("test4.png");
                    Quest.Text = "Вы в кинотеатре но фильм не фонтан. Да и соседи достали хрустом попкорна. Ваши действия?";
                    FirstAnswer.Content = "Хватит это терпеть. Попкорн полетит в лицо соседям";
                    SecondAnswer.Content = "Сделаю им замечание";
                    ThirdAnswer.Content = "Досмотрю до конца. Жалко денег за билет";
                    FourthAnswer.Content = "Демостративно уйду в середине сеанса!";
                    break;
                case 4:
                    IMG.Source = (ImageSource)converter.ConvertFromString("test1.jpg");
                    Quest.Text = "По дороге из кино вас подрезает какой то лихач. Что будете делать?";
                    FirstAnswer.Content = "Догоню и тоже подрежу.";
                    SecondAnswer.Content = "Да ничего не поделать, подумаешь";
                    ThirdAnswer.Content = "Наору на другого водителя. Не держать же злобу в себе";
                    FourthAnswer.Content = "Досчитаю до 10 и выдохну";
                    break;
           
                case 5:
                    IMG.Source = (ImageSource)converter.ConvertFromString("test4.png");
                    Quest.Text = "Приехали к дому, 10 минут кружились и нашли парковочное место, но кто то занял его перед вами";
                    FirstAnswer.Content = "А ну катись отсюда. Это мой двор и мое место";
                    SecondAnswer.Content = "Извините молодой человек, уступите мне";
                    ThirdAnswer.Content = "Да что тут скажешь поеду искать другое место";
                    FourthAnswer.Content = "Кину что нибудь в окно";
                    break;
                case 6:
                    IMG.Source = (ImageSource)converter.ConvertFromString("test1.jpg");
                    Quest.Text = "Вы зашли в магазин. 22:58, в очереди перед кассой к вам пристраиваются трое незакомцев. Что будете делать?";
                    FirstAnswer.Content = "Войду в положение, пропущу";
                    SecondAnswer.Content = "Охамели в троем лезть, пущу одного";
                    ThirdAnswer.Content = "Буду стоять до конца, но не уступлю";
                    FourthAnswer.Content = "Пущу из жалости";
                    break;
                case 7:
                    IMG.Source = (ImageSource)converter.ConvertFromString("test3.png");
                    Quest.Text = "Наконец - вы прилегли на диван и включили любимый фильм, тут же кот наделал лужу на полу";
                    FirstAnswer.Content = "Нет ему оправдания";
                    SecondAnswer.Content = "Он так сделал, потому чтоя не уделяю внимания";
                    ThirdAnswer.Content = " Тыкну мордой в лужу";
                    FourthAnswer.Content = " Ну он просто кот";
                    break;
            }
        }
        private void FirstAnswer_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(1);
        }

        private void SecondAnswer_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(2);
        }

        private void ThirdAnswer_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(3);
        }

        private void FourthAnswer_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(4);
        }

        private void TestStart_Click(object sender, RoutedEventArgs e)
        {
            StartGrid.Visibility = Visibility.Collapsed;
            TestGrid.Visibility = Visibility.Visible;
            TestIsStarted = true;
        }

        
    private void EndTestButton_Click(object sender, RoutedEventArgs e)
             {
                 EndTest();
             
        }
       

    }
}
