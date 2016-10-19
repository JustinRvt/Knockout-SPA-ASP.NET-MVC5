using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.KeyWord
{
    /// <summary>
    /// Classe de DTO pour les mots clés
    /// </summary>
    /// <remarks>JClaud 2015-07-20 Création</remarks>
    [DebuggerDisplay("ID KeyWord = {IdKeyWord} - Nom KeyWord = {NomKeyWord}")]
    [DataContract]
    public class KeyWordDTO : BaseDTO
    {
         #region PROPERTIES

        #region ACCESSEURS

        private int _IdKeyWord;
        /// <summary>
        /// Accesseur de l'id du mot clé
        /// </summary>
        [DataMember]
        public int IdKeyWord
        {
            get { return _IdKeyWord; }
            set { _IdKeyWord = value; }
        }

        private string _NomKeyWord;
        /// <summary>
        /// Accesseur du nom du mot clé
        /// </summary>
        [DataMember]
        public string NomKeyWord
        {
            get { return _NomKeyWord; }
            set { _NomKeyWord = value; }
        }

        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-07-20 - Création</remarks>
        public KeyWordDTO()
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
            /// <para>Description : Fonction permettant de créer un mot clé en BDD</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationKeyWordDTO</para>
            /// </summary>
            CreateKeyWordData,
        }

        #endregion
    }
}
