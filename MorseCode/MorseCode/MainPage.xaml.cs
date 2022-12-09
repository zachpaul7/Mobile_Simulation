using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MorseCode;

public partial class MainPage : ContentPage
{
    public korConvert korConvert = new korConvert();
    public string result = "";
    public List<char> list_row = new List<char>();
    public string str_m;
    public char ch;
    
    public MainPage()
    {
        InitializeComponent();
    }

    private void CodeBtn_Clicked(object sender, EventArgs e)
    {
        CheckString();
    }

    private void MorseConvert()
    {
        char[] ch = new char[str_m.Length];


        for (int i = 0; i < str_m.Length; i++)
        {
            ch[i] = str_m[i];
        }

        morseLabel.Text = ("모스부호 입력");

        for (int i = 0; i < ch.Length; i++)
        {

            if (ch[i].Equals('-'))
            {
                Vibration.Default.Vibrate(600);
                Thread.Sleep(800);
            }

            else if (ch[i].Equals('.'))
            {
                Vibration.Default.Vibrate(200);
                Thread.Sleep(800);
            }

            else if (ch[i].Equals(' '))
            {
                Thread.Sleep(500);
            }
        }
    }

    private void Morsedecoding()
    {
        Dictionary<char, string> dic = new Dictionary<char, string>()
            {
                {'a', ".-"},{'b', "-..."},{'c', "-.-."},{'d', "-.."},{'e', "."},{'f', "..-."},{'g', "--."},{'h', "...."},{'i', ".."},
                {'j', ".---"},{'k', "-.-"},{'l', ".-.."},{'m', "--"},{'n', "-."},{'o', "---"},{'p', ".--."},{'q', "--.-"},{'r', ".-."},
                {'s', "..."},{'t', "-"},{'u', "..-"},{'v', "...-"},{'w', ".--"},{'x', "-..-"},{'y', "-.--"},{'z', "--.."},{' '," "},
                {'1', ".----"},{'2', "..---"},{'3', "...--"},{'4', "....--"},{'5', "....."},{'6', "-...."},{'7', "--..."},{'8', "---.."},
                {'9', "----."},{'0', "-----"}
            };
        char[] ch = new char[korConvert.list.Count];

        for (int j = 0; j < korConvert.list.Count; j++)
        {
            ch[j] = korConvert.list[j];
            result = result + dic[ch[j]];
            if (ch[j] == ' ')
            {
                result = result + " ";
            }
            else
            {
                result += " ";
            }
        }
        str_m += result;
    }

    private void korencoding()
    {
        Dictionary<char, string> korDict = new Dictionary<char, string>()
            {
                {'ㄱ', ".-.."},{'ㄴ', "..-."},{'ㄷ', "-..."},{'ㄹ', "...-"},{'ㅁ', "--"},{'ㅂ', ".--"},{'ㅅ', "--."},{'ㅇ', "-.-"},{'ㅈ', ".--."}
                ,{'ㅊ', "-.-."},{'ㅋ', "-..-"},{'ㅌ', "--.."},{'ㅍ', "---"},{'ㅎ', ".---"},{' ', " "},{'ㅏ', "."},{'ㅑ', ".."}
                ,{'ㅓ', "-"},{'ㅕ', "..."},{'ㅗ', ".-"},{'ㅛ', "-."},{'ㅜ', "...."},{'ㅠ', ".-."},{'ㅡ', "-.."},{'ㅣ', "..-"}
                ,{'ㅔ', "-.--"},{'ㅐ', "--.-"}
            };
        char[] stch = new char[korConvert.list.Count];
        for(int i = 0; i < korConvert.list.Count; i++)
        {
            stch[i] = korConvert.list[i];
        }

        for (int j = 0; j < stch.Length; j++)
        {
            result = result + korDict[stch[j]];
            if (stch[j].Equals(" "))
            {
                result = result + " ";
            }
            else
            {
                result += " ";
            }
        }
        str_m += result;
    }

    private void CheckString()
    {

        if (morseData.Text == null)
            morseLabel.Text = ("다시 입력해주세요.");
        else
        {
            List<char> a = new List<char>();
            List<char> b = new List<char>();
            int i;

            str_m = "";
            
            for (i = 0; i < morseData.Text.Length; i++)
            {
                a.Add(morseData.Text[i]);
                korConvert.sepChar(a[i]);
                //korConvert.list.Clear();
                if (!korConvert.CheckingUni(a[i]).Equals("NH"))
                {
                    korencoding();
                    
                }
                else if(korConvert.CheckingUni(a[i]).Equals("NH"))
                {
                    
                    Morsedecoding();
                }
                result = "";
                korConvert.list.Clear();
            }
            MorseConvert();

            encodeLabel.Text = str_m;
        }
    }
}