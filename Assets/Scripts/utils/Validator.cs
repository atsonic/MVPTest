using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace utils{
    public class Validator{
        public static bool IsEmpty(string text){
            return string.IsNullOrEmpty(text);
        }
        public static bool IsEnglish(string text){
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"^[a-zA-Z]+$");
        }
        public static bool IsKanji(string text){
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"^[\u4e00-\u9fa5]+$");
        }
        public static bool IsKana(string text){
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"^[ァ-ヶ]+$");
        }
        public static bool IsNumber(string text){
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"^[0-9]+$");
        }
    }
}