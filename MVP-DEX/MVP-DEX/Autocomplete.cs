using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVP_DEX
{
    class Autocomplete
    {
        //lista cuv
        public ObservableCollection<Word> word_list { get; set; }
        //cuvant de adaugat(nou)
        public Word newWord { get; set; }
        //lista texte
        public ObservableCollection<string> text_list { get; set; }
        //lista categorii
        public ObservableCollection<string> category_list { get; set; }

        public Autocomplete()
        {
            //initalizari liste + cuvantul nou
            word_list = new ObservableCollection<Word>();
            category_list = new ObservableCollection<string>();
            text_list = new ObservableCollection<string>();
            newWord = new Word("", "", "", "");
            string path = @"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt";
            try
            {
                category_list.Add("Nicio categorie");
                string file_line;
                //citire din fisier pentru popularea listelor
                StreamReader sr = new StreamReader(path);
                while ((file_line = sr.ReadLine()) != null)
                {
                    string[] word_info = file_line.Split(',');
                    word_list.Add(new Word(word_info[0], word_info[1], word_info[2], word_info[3]));
                    if (category_list.Contains(word_info[1]) == false)
                    {
                        category_list.Add(word_info[1]);
                    }
                    text_list.Add(word_info[0]);
                }
            }
            catch
            {
                Console.WriteLine("Cannot access file!");
            }
        }

        //metoda cautare cuvant in lista
        public Word SearchWord(string text)
        {
            foreach (Word val in word_list)
            {
                if (val.text == text)
                    return val;
            }
            return default;
        }
    }
}
