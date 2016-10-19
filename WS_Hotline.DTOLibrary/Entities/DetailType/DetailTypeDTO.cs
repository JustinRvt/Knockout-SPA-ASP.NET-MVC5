using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace DTOLibrary.Entities.DetailType
{
    /// <summary>
    /// Classe de DTO pour la gestion des DetailTypeDTO
    /// </summary>
    /// <remarks>JClaud 2015-07-20 Création</remarks>
    [DebuggerDisplay("ID DetailType = {IdDetailType} - Nom DetailType = {NomDetailType}")]
    [DataContract]
    public class DetailTypeDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdDetailType;
        /// <summary>
        /// Accesseur de l'id du detail type
        /// </summary>
        [DataMember]
        public int IdDetailType
        {
            get { return _IdDetailType; }
            set { _IdDetailType = value; }
        }

        private string _NomDetailType;
        /// <summary>
        /// Accesseur du nom du detail type
        /// </summary>
        [DataMember]
        public string NomDetailType
        {
            get { return _NomDetailType; }
            set { _NomDetailType = value; }
        }

        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public DetailTypeDTO()
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
            /// <para>Description : Fonction permettant de créer un detail type en BDD</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationDetailTypeDTO</para>
            /// </summary>
            CreateDetailTypeData,
        }

        #endregion
    }
}
