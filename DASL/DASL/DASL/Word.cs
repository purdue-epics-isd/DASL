using System;
using System.Collections.Generic;
using System.Text;

namespace DASL
{
    public class Word
    {
        private string name;
        private string mainCategory;
        private List<string> categories = new List<string>();
        private string speech;
        private string sentence;
        private string definition;
        public Word()
        {
        
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setMainCategory(string mainCategory)
        {
            this.mainCategory = mainCategory;
        }
        
        public void setSpeech(string speech)
        {
            this.speech = speech;
        }

        public void setDefinition(string definition)
        {
            this.definition = definition;
        }

        public void setSentence(string sentence)
        {
            this.sentence = sentence;
        }
        
        public void setCategories(List<string> categories)
        {
            this.categories = categories;
        }

        public string getName()
        {
            return (name);
        }

        public string getMainCategories()
        {
            return (mainCategory);
        }

        public string getSpeech()
        {
            return (speech);
        }

        public string getSentence()
        {
            return (sentence);
        }

        public string getDefinition()
        {
            return (definition);
        }

        public List<string> getCategories()
        {
            return (categories);
        }
    }
}
 