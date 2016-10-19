using WS_Hotline.DTOLibrary.Entities.Projet;
using WS_Hotline.DTOLibrary.Entities.Statut;
using WS_Hotline.DTOLibrary.Entities.Temps;
using WS_Hotline.DTOLibrary.Entities.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Commentaire
{
    /// <summary>
    /// Classe de DTO pour les commentaires des tickets
    /// </summary>
    /// <remarks>JClaud 2015-03-19 Création</remarks>
    [DebuggerDisplay("ID Commentaire = {IdCommentaire} - ID Ticket = {TicketId} - ID User = {UserId} UserName = {UserName}")]
    [DataContract]
    public class CommentaireDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdCommentaire;
        /// <summary>
        /// Accesseur de l'identifiant du commentaire
        /// </summary>
        [DataMember]
        public int IdCommentaire
        {
            get { return _IdCommentaire; }
            set { _IdCommentaire = value; }
        }

        private int _TicketId;
        /// <summary>
        /// Accesseur de l'id du ticket
        /// </summary>
        [DataMember]
        public int TicketId
        {
            get { return _TicketId; }
            set { _TicketId = value; }
        }

        private int _UserId;
        /// <summary>
        /// Accesseur de l'id de l'utilisateur
        /// </summary>
        [DataMember]
        public int UserId
        {
            get { return _UserId; }
            set 
            {
                _UserId = value;
            }
        }

        private int _IdProjet;
        /// <summary>
        /// Accesseur du IdProjet
        /// </summary>
        [DataMember]
        public int IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private string _CommentaireTxt;
        /// <summary>
        /// Accesseur du commentaire du ticket au format txt
        /// </summary>
        [DataMember]
        public string CommentaireTxt
        {
            get { return _CommentaireTxt; }
            set { _CommentaireTxt = value; }
        }

        private string _CommentaireHtml;
        /// <summary>
        /// Accesseur du commentaire du ticket au format html
        /// </summary>
        [DataMember]
        public string CommentaireHtml
        {
            get { return _CommentaireHtml; }
            set { _CommentaireHtml = value; }
        }

        private string _UserName;
        /// <summary>
        /// Accesseur du nom du créateur
        /// </summary>
        [DataMember]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private bool _IsClosing;
        /// <summary>
        /// Accesseur du booléen de fermeture
        /// </summary>
        [DataMember]
        public bool IsClosing
        {
            get { return _IsClosing; }
            set { _IsClosing = value; }
        }

        private int _Visibilitée;
        /// <summary>
        /// Accesseur de la visibilitée
        /// </summary>
        [DataMember]
        public int Visibilitée
        {
            get { return _Visibilitée; }
            set { _Visibilitée = value; }
        }

        private DateTime _DateCreation;
        /// <summary>
        /// Accesseur de la date de création du ticket
        /// </summary>
        [DataMember]
        public DateTime DateCreation
        {
            get { return _DateCreation; }
            set { _DateCreation = value; }
        }

        #endregion

        #region PUBLICS VARIABLES


        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur du CommentaireDTO
        /// </summary>
        /// <remarks>Jclaud 2015-03-19 - Création</remarks>
        public CommentaireDTO()
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
            /// <para>Description : Fonction permettant de créer un nouveau commentaire pour le ticket en cours</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCommentaireDTO</para>
            /// </summary>
            CreateComment,
        }

        #endregion
    }
}
