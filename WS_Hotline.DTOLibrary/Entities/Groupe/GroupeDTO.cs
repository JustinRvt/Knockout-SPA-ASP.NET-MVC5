using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Groupe
{
    /// <summary>
    /// Classe de DTO pour la gestion des groupes dans TimeGemini
    /// </summary>
    /// <remarks>Jclaud 2015-07-28 Création</remarks>
    [DebuggerDisplay("ID Groupe = {IdGroupe} - Nom Groupe = {GroupeNom} - Date Création Groupe = {GroupeDateCreation}")]
    [DataContract]
    public class GroupeDTO : BaseDTO
    {
        #region PROPERTIES

        private int _IdGroupe;
        /// <summary>
        /// Accesseur de l'identifiant du groupe
        /// </summary>
        [DataMember]
        public int IdGroupe
        {
            get { return _IdGroupe; }
            set { _IdGroupe = value; }
        }

        private string _GroupeNom;
        /// <summary>
        /// Accesseur du nom du groupe
        /// </summary>
        [DataMember]
        public string GroupeNom
        {
            get { return _GroupeNom; }
            set { _GroupeNom = value; }
        }

        private string _GroupeDescription;
        /// <summary>
        /// Accesseur de la description du groupe
        /// </summary>
        [DataMember]
        public string GroupeDescription
        {
            get { return _GroupeDescription; }
            set { _GroupeDescription = value; }
        }

        private DateTime _GroupeDateCreation;
        /// <summary>
        /// Accesseur de la date de création du groupe
        /// </summary>
        [DataMember]
        public DateTime GroupeDateCreation
        {
            get { return _GroupeDateCreation; }
            set { _GroupeDateCreation = value; }
        }

        private List<int> _GroupeInteractions;
        /// <summary>
        /// Accesseur des intéractions du groupe
        /// </summary>
        [DataMember]
        public List<int> GroupeInteractions
        {
            get { return _GroupeInteractions; }
            set { _GroupeInteractions = value; }
        }

        #endregion

        #region MTDHS / FUNCTIONS

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public GroupeDTO()
        {

        }

        #endregion

        /// <summary>
        /// Méthode permettant de valider le DTO
        /// Si il y a une erreur, une exception est levée
        /// </summary>
        /// <remarks>Jclaud 2015-07-28 - Création</remarks>
        public override void ValidationDTO()
        {
            //gb - Appel les méthodes de validation des DTO
            base.ValidationDTO();
        }

        #endregion

        #region ENUM MTDH

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            ///<para>Description : Fonction permettant de créer un groupe</para>
            ///<para>Paramètre : Cette fonction prend un paramètre un objet de type ParamCreationGroupeDTO</para>
            /// </summary>
            CreateGroupeData
        }

        #endregion
    }
}
