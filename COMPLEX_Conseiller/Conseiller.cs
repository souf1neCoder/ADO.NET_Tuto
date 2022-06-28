using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPLEX_Conseiller
{
    public class Conseiller
    {
        private int matricule;
        private string nom;
        private string prenom;
        private int codeSecret;
        private int codecomplexe;
        private int numbrevisite;

        public Conseiller(int matricule, string nom, string prenom, int codeSecret, int codecomplexe, int numbrevisite)
        {
            if(codeSecret.ToString().Length < 3)
            {
                throw new Exception("Code Secret Invalide!");
            }
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.codeSecret = codeSecret;
            this.codecomplexe = codecomplexe;
            this.numbrevisite = numbrevisite;
        }

        public Conseiller()
        {
        }

        public int Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }

        public  string myString()
        {
            return this.nom[0].ToString().ToUpper();
        }
    }
}
