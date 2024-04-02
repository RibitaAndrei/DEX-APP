using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_DEX
{
    class Word
    {
        // Proprietate pentru textul cuvântului.(CUVANT IN SINE)
        public String text { get; set; }
        // Proprietate pentru categoria cuvântului.
        public String category { get; set; }
        // Proprietate pentru descrierea cuvântului.
        public String description { get; set; }
        // Proprietate pentru calea către imaginea asociată cuvântului.
        public String picture_path { get; set; }

        public Word(String newText, String newCategory, String newDescription, String newPicturePath)
        {
            // Inițializarea proprietăților cu valorile primite ca parametri.
            this.text = newText;
            this.category = newCategory;
            this.description = newDescription;
            this.picture_path = newPicturePath;
        }
    }
}
