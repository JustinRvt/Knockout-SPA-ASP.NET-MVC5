using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Cause
{
    /// <summary>
    /// Classe de DTO pour les causes de blocage des tickets
    /// </summary>
    /// <remarks>JClaud 2015-03-11 Création</remarks>
    [DebuggerDisplay("ID Cause = {IdCause} - Nom Cause = {NomCause} - Service Cause = {ServiceCause}")]
    [DataContract]
    public class CauseDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdCause;
        /// <summary>
        /// Accesseur de l'id de la cause
        /// </summary>
        [DataMember]
        public int IdCause
        {
            get { return _IdCause; }
            set { _IdCause = value; }
        }

        private string _NomCause;
        /// <summary>
        /// Accesseur du nom de la cause
        /// </summary>
        [DataMember]
        public string NomCause
        {
            get { return _NomCause; }
            set { _NomCause = value; }
        }

        private string _ServiceCause;
        /// <summary>
        /// Accesseur du service concerné par la cause
        /// </summary>
        [DataMember]
        public string ServiceCause
        {
            get { return _ServiceCause; }
            set { _ServiceCause = value; }
        }

        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public CauseDTO()
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
            /// <para>Description : Fonction permettant de créer une cause en BDD</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamUpdateAvancementDTO</para>
            /// </summary>
            CreateCauseData,
        }

        #endregion
    }
}
