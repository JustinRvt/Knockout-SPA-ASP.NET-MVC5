using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace WS_Hotline.DTOLibrary.Entities.HoraireJour
{
    /// <summary>
    /// Classe de critères pour les objects de type HoraireJourDTO
    /// </summary>
    /// <remarks>JClaud 2015-08-04 Création</remarks>
    [DebuggerDisplay("ID = {Id} - Nom_Fr = {Nom_Fr} - Nom_Eng = {Nom_Eng} - Nb Heure Max = {Nb_HeureMax}")]
    [DataContract]
    public class CritereHoraireJourDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private int _Id;
        /// <summary>
        /// Accesseur de l'id
        /// </summary>
        [DataMember]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nom_Fr;
        /// <summary>
        /// Accesseur du nom français
        /// </summary>
        [DataMember]
        public string Nom_Fr
        {
            get { return _Nom_Fr; }
            set { _Nom_Fr = value; }
        }

        private string _Nom_Eng;
        /// <summary>
        /// Accesseur du nom anglais
        /// </summary>
        [DataMember]
        public string Nom_Eng
        {
            get { return _Nom_Eng; }
            set { _Nom_Eng = value; }
        }

        private int _Nb_HeureMax;
        /// <summary>
        /// Accesseur du nombre d'heures de la journée
        /// </summary>
        [DataMember]
        public int Nb_HeureMax
        {
            get { return _Nb_HeureMax; }
            set { _Nb_HeureMax = value; }
        }

        #endregion
    }
}
