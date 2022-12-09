using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    public sealed class korConvert
    {
        public static readonly string first = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        public static readonly string second = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        public static readonly string last = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
        private static readonly ushort fkor = 0xAC00;
        private static readonly ushort lkor = 0xD79F;
        public static char[] rschar = null;
        public List<char> list = new List<char>();
        public string Iskor;
        public string sepChar(char korChar)
        {
            int findex, mindex, lindex;    // 초성,중성,종성의 인덱스
            ushort TempUnicode = 0x0000;                // 임시로 코드값을 담을 변수

            //Char을 16비트 부호없는 정수형 형태로 변환 - Unicode
            TempUnicode = Convert.ToUInt16(korChar);

            // 캐릭터가 한글이 아닐 경우 처리
            if ((TempUnicode < fkor) && !(TempUnicode == 32) || (TempUnicode > lkor) && !(TempUnicode == 32))
            {
                list.Add(korChar);
            }
            else if (TempUnicode == 32)
            {
                list.Add(' ');
            }
            else
            {
                int Unicode = TempUnicode - fkor;
                findex = Unicode / (21 * 28);
                Unicode = Unicode % (21 * 28);
                mindex = Unicode / 28;
                Unicode = Unicode % 28;
                lindex = Unicode;

                list.Add(first[findex]);
                list.Add(second[mindex]);
                list.Add(last[lindex]);

            }
            return Iskor;
        }

        public string CheckingUni(char c)
        {
            ushort TempUnicode = 0x0000;
            TempUnicode = Convert.ToUInt16(c);

            if ((TempUnicode < fkor) || (TempUnicode > lkor))
            {
                Iskor = "NH";
            }
            else
            {
                Iskor = "H";
            }
            return Iskor;
        }
    }
    
}
