using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace DTOLibrary.Entities.HoraireJour
{
    /// <summary>
    /// Classe pour la gestion des horaires par journées
    /// </summary>
    /// <remarks>JClaud 2015-08-04 Création</remarks>
    [DebuggerDisplay("ID = {Id} - Nom_Fr = {Nom_Fr} - Nom_Eng = {Nom_Eng} - Nb Heure Max = {Nb_HeureMax}")]
    [DataContract]
    public class HoraireJourDTO : BaseDTO
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

        private DateTime _H_Debut_Matin;
        /// <summary>
        /// Accesseur de l'horaire de début de journée
        /// </summary>
        [DataMember]
        public DateTime H_Debut_Matin
        {
            get { return _H_Debut_Matin; }
            set { _H_Debut_Matin = value; }
        }

        private DateTime _H_Fin_Matin;
        /// <summary>
        /// Accesseur de l'horaire de fin de matinée
        /// </summary>
        [DataMember]
        public DateTime H_Fin_Matin
        {
            get { return _H_Fin_Matin; }
            set { _H_Fin_Matin = value; }
        }

        private DateTime _H_Debut_Aprem;
        /// <summary>
        /// Accesseur de l'horaire de début d'aprèm
        /// </summary>
        [DataMember]
        public DateTime H_Debut_Aprem
        {
            get { return _H_Debut_Aprem; }
            set { _H_Debut_Aprem = value; }
        }

        private DateTime _H_Fin_Aprem;
        /// <summary>
        /// Accesseur de l'horaire de fin d'aprèm
        /// </summary>
        [DataMember]
        public DateTime H_Fin_Aprem
        {
            get { return _H_Fin_Aprem; }
            set { _H_Fin_Aprem = value; }
        }

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-07-20 - Création</remarks>
        public HoraireJourDTO()
        {

        }

        #endregion
    }
}
