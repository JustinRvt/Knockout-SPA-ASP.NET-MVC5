using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WS_Hotline.DTOLibrary.Helper
{
    /// <summary>
    /// Classe de validation pour les dates spécifique
    /// </summary>
    /// <remarks>JClaud 2015-04-08 Création</remarks>
    public class DateTimeValidationExo : ValidationAttribute
    {
        #region PROPERTIES

        public string MessagePeriode
        { 
            get; 
            set;
        }

        public string MessageConversion
        { 
            get; 
            set; 
        }

        #endregion

        #region MTDH

        /// <summary>
        /// Méthode qui viens réécrire la fonction de validation d'un attribut XML
        /// </summary>
        /// <param name="value">objet à valider</param>
        /// <returns>Booléen qui indique si l'objet est valide ou non</returns>
        /// <remarks>JClaud 2015-04-08 Création</remarks>
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            //jc- déclaration de variables
            bool lIsParse; 
            DateTime lDt, lDt_Verif;

            //jc- on tente de parser la date
            lIsParse = DateTime.TryParse(Convert.ToString(value), out lDt);
            //jc- si le parsage à réussit
            if (lIsParse)
            {
                //jc- on affecte la date en récupération l'année, mois, jour
                lDt_Verif = new DateTime(lDt.Year,lDt.Month, lDt.Day, 0,0,0);

                //jc- gestion des différents contrôles et erreurs
                //------------------------------------------------------
                //jc- on gère la cas ou le temps saisie n'est pas compris entre 1min et 8h
                if (!(lDt >= lDt_Verif.AddMinutes(1) && lDt < lDt_Verif.AddHours(8).AddMinutes(1)))
                    return new ValidationResult(MessagePeriode);
            }
            else
                return new ValidationResult(MessageConversion);

            //jc- dans tous les autres cas on retourne vrai
            return ValidationResult.Success;
        }

        #endregion
    }
}
