using Microsoft.Win32;
using QuizMVVM.Model;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace QuizMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region ZMIENNE

        private string _answerA;
        private string _answerB;
        private string _answerC;
        private string _answerD;
        private string _question;
        private string _score;
        private int _questionNumber = 0;

        private bool _isThisLastQuestion;

        private DispatcherTimer _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Render);
        private int _totalSeconds = 0;
        private string _timerText;

        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        #endregion


        static string fileName = @"..\..\..\quiztestowy.json";
        static string jsonString = File.ReadAllText(fileName);


        QuizClass? quizClass = JsonSerializer.Deserialize<QuizClass>(jsonString, options);

#pragma warning disable CS8618
        public MainViewModel()
#pragma warning restore CS8618
        {
            #region ODPOWIEDZI
            Question = quizClass?.Questions?[_questionNumber]?.Content?.ToString();
            AnswerA = quizClass?.Questions?[_questionNumber]?.Answers?[0]?.Content?.ToString();
            AnswerB = quizClass?.Questions?[_questionNumber]?.Answers?[1]?.Content?.ToString();
            AnswerC = quizClass?.Questions?[_questionNumber]?.Answers?[2]?.Content?.ToString();
            AnswerD = quizClass?.Questions?[_questionNumber]?.Answers?[3]?.Content?.ToString();

            AnswerButtonCommand = new RelayCommand(AnswerButton);

            NextQuestionCommand = new RelayCommand(NextQuestion, CanGetNextQuestion);
            EndCommand = new RelayCommand(End);
            #endregion

            Score = "Score: 0";

            #region TIMER
            TimerText = "";
#pragma warning disable CS8622 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z docelowym delegatem (prawdopodobnie z powodu atrybutów dopuszczania wartości null).
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
#pragma warning restore CS8622 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z docelowym delegatem (prawdopodobnie z powodu atrybutów dopuszczania wartości null).
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            _dispatcherTimer.Start();
        }



        // Timer
        public string TimerText
        {
            get
            {
                return this._timerText;
            }
            set
            {
                this._timerText = value;
                OnPropertyChanged();
            }
        }
        

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this._totalSeconds += 1;
            TimerText = string.Format("{0:ss} s", TimeSpan.FromSeconds(this._totalSeconds).Duration());
            CommandManager.InvalidateRequerySuggested();
        }
        #endregion

        #region KONSTRUKTORY
        public string AnswerA
        {
            get { return _answerA; }
            set { _answerA = value; OnPropertyChanged(); }
        }

        public string AnswerB
        {
            get { return _answerB; }
            set { _answerB = value; OnPropertyChanged(); }
        }

        public string AnswerC
        {
            get { return _answerC; }
            set { _answerC = value; OnPropertyChanged(); }
        }

        public string AnswerD
        {
            get { return _answerD; }
            set { _answerD = value; OnPropertyChanged(); }
        }

        public string Question
        {
            get { return _question; }
            set { _question = value; OnPropertyChanged(); }
        }

        public string Score
        {
            get { return _score; }
            set { _score = value; OnPropertyChanged(); }
        }
        #endregion

        public ICommand AnswerButtonCommand { get; set; }

        #region ODPOWIEDZI
        private void AnswerButton(object obj)
        {
            if(obj as string == "A")
            {
                if (quizClass?.Questions?[_questionNumber]?.Answers?[0]?.IsCorrect == true)
                {
                    int wynik = Int32.Parse(Regex.Match(Score.ToString(), @"\d+").Value);
                    wynik++;
                    Score = $"Score: {wynik.ToString()}";
                }
            }
            if (obj as string == "B")
            {
                if (quizClass?.Questions?[_questionNumber]?.Answers?[1]?.IsCorrect == true)
                {
                    int wynik = Int32.Parse(Regex.Match(Score.ToString(), @"\d+").Value);
                    wynik++;
                    Score = $"Score: {wynik.ToString()}";
                }
            }
            if (obj as string == "C")
            {
                if (quizClass?.Questions?[_questionNumber]?.Answers?[2]?.IsCorrect == true)
                {
                    int wynik = Int32.Parse(Regex.Match(Score.ToString(), @"\d+").Value);
                    wynik++;
                    Score = $"Score: {wynik.ToString()}";
                }
            }
            if (obj as string == "D")
            {
                if (quizClass?.Questions?[_questionNumber]?.Answers?[3]?.IsCorrect == true)
                {
                    int wynik = Int32.Parse(Regex.Match(Score.ToString(), @"\d+").Value);
                    wynik++;
                    Score = $"Score: {wynik.ToString()}";
                }
            } 
        }
        #endregion

        public ICommand NextQuestionCommand { get; set; }

        #region NASTEPNE PYTANIE
        private void NextQuestion(object obj)
        {
            if (_questionNumber < quizClass?.Questions?.Count - 1)
            {
                _questionNumber++;
                if(_questionNumber >= quizClass?.Questions?.Count - 1)
                    _isThisLastQuestion = true;
                Question = quizClass?.Questions?[_questionNumber]?.Content?.ToString();
                AnswerA = quizClass?.Questions?[_questionNumber]?.Answers?[0]?.Content?.ToString();
                AnswerB = quizClass?.Questions?[_questionNumber]?.Answers?[1]?.Content?.ToString();
                AnswerC = quizClass?.Questions?[_questionNumber]?.Answers?[2]?.Content?.ToString();
                AnswerD = quizClass?.Questions?[_questionNumber]?.Answers?[3]?.Content?.ToString();
            }
        }
        #endregion
        private bool CanGetNextQuestion(object obj) => !_isThisLastQuestion;

        public ICommand EndCommand { get; set; }

        #region ZAKONCZENIE QUIZU
        private void End(object obj)
        {
            _dispatcherTimer.Stop();
            MessageBox.Show($"Your score: {Regex.Match(Score.ToString(), @"\d+").Value}\n" +
                $"This quiz took you {TimerText.ToString()}!", "Quiz is finished!");
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

#pragma warning disable CS8625 // Nie można przekonwertować literału o wartości null na nienullowalny typ referencyjny.
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
#pragma warning restore CS8625 // Nie można przekonwertować literału o wartości null na nienullowalny typ referencyjny.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region SZYFROWANIE
        private void Encrypt_file(string filepath)
        {
            string file_content = File.ReadAllText(filepath);
            string encrypted_file_content = Encryption.Encrypt(file_content);
            File.WriteAllText(filepath, encrypted_file_content);
        }
        private string Decrypt_file(string filepath)
        {
            string file_content = File.ReadAllText(filepath);
            return Encryption.Decrypt(file_content);
        }
        #endregion

    }
}
