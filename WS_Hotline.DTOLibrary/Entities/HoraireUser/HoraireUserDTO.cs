using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace DTOLibrary.Entities.HoraireUser
{
    /// <summary>
    /// Classe de gestion des données de type HoraireUserDTO
    /// </summary>
    /// <remarks>JClaud 2015-08-04 Création</remarks>
    [DebuggerDisplay("ID = {Id} - Jour = {Jour} - User Id = {UserId}")]
    [DataContract]
    public class HoraireUserDTO : BaseDTO
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

        private DateTime _Jour;
        /// <summary>
        /// Accesseur de la date
        /// </summary>
        [DataMember]
        public DateTime Jour
        {
            get { return _Jour; }
            set { _Jour = value; }
        }

        private int _UserId;
        /// <summary>
        /// Accesseur de l'id utilisateur
        /// </summary>
        [DataMember]
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private int _Nb_Expected_H;
        /// <summary>
        /// Accesseur du nombre d'heures attendu en saisie
        /// </summary>
        [DataMember]
        public int Nb_Expected_H
        {
            get { return _Nb_Expected_H; }
            set { _Nb_Expected_H = value; }
        }

        private int _Nb_Expected_Min;
        /// <summary>
        /// Accesseur du nombre de minutres attendu en saisie
        /// </summary>
        [DataMember]
        public int Nb_Expected_Min
        {
            get { return _Nb_Expected_Min; }
            set { _Nb_Expected_Min = value; }
        }

        private int _Nb_Logged_H;
        /// <summary>
        /// Accesseur du nombre d'heures saisies par l'utilisateur
        /// </summary>
        [DataMember]
        public int Nb_Logged_H
        {
            get { return _Nb_Logged_H; }
            set { _Nb_Logged_H = value; }
        }

        private int _Nb_Logged_Min;
        /// <summary>
        /// Accesseur du nombre de minutes saisies par l'utilisateur
        /// </summary>
        [DataMember]
        public int Nb_Logged_Min
        {
            get { return _Nb_Logged_Min; }
            set { _Nb_Logged_Min = value; }
        }

        private int _Nb_Astreinte_H;
        /// <summary>
        /// Accesseur du nombre d'heures d'astreinte de l'utilisateur
        /// </summary>
        [DataMember]
        public int Nb_Astreinte_H
        {
            get { return _Nb_Astreinte_H; }
            set { _Nb_Astreinte_H = value; }
        }

        private int _Nb_Astreinte_Min;
        /// <summary>
        /// Accesseur du nombre de minutes d'astreinte de l'utilisateur
        /// </summary>
        [DataMember]
        public int Nb_Astreinte_Min
        {
            get { return _Nb_Astreinte_Min; }
            set { _Nb_Astreinte_Min = value; }
        }

        private TimeSpan _EcartTemps;
        /// <summary>
        /// Accesseur de l'écart de temps en prévu et loggé
        /// </summary>
        [DataMember]
        public TimeSpan EcartTemps
        {
            get { return _EcartTemps; }
            set { _EcartTemps = value; }
        }

        private bool? _IsFirstPlay;
        /// <summary>
        /// Accesseur du boolean premier click
        /// </summary>
        [DataMember]
        public bool? IsFirstPlay
        {
            get { return _IsFirstPlay; }
            set { _IsFirstPlay = value; }
        }

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-07-20 - Création</remarks>
        public HoraireUserDTO()
        {

        }

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de MAJ puis de retourner le temps loggé par l'utilisateur</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationHoraireUserDTO</para>
            /// </summary>
            MAJHoraireUser,
        }

        #endregion
    }
}
