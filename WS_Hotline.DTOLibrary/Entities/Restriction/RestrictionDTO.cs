using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Restriction
{
    /// <summary>
    /// Classe permettant de gérer les restrictions lors de la récupération des données
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("ID Liste = {IdListe} - Valeur = {Valeur}")]
    [DataContract]
    public class RestrictionDTO : BaseDTO
    {
        #region PROPERTIES

        private string _IdListe;
        /// <summary>
        /// Accesseur de l'id de la liste
        /// </summary>
        [DataMember]
        public string IdListe
        {
            get { return _IdListe; }
            set { _IdListe = value; }
        }

        private string _Valeur;
        /// <summary>
        /// Accesseur des valeurs
        /// </summary>
        [DataMember]
        public string Valeur
        {
            get { return _Valeur; }
            set { _Valeur = value; }
        }

        #endregion
    }
}
