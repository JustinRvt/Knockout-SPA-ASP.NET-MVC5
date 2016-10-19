using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.TicketLien
{
    [DebuggerDisplay("ID Ticket = {TicketId} - ID SecondTicket = {SecondTicketId} - Date de Creation = {Creation}")]
    [DataContract]
    public class TicketLienDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdTicketLien;
        /// <summary>
        /// Accesseur de l'identifiant du lien
        /// </summary>
        [DataMember]
        public int IdTicketLien
        {
            get { return _IdTicketLien; }
            set { _IdTicketLien = value; }
        }

        private int _TypeLienId;
        /// <summary>
        /// Accesseur de l'id du type de lien
        /// </summary>
        [DataMember]
        public int TypeLienId
        {
            get { return _TypeLienId; }
            set { _TypeLienId = value; }
        }

        private int _TicketId;
        /// <summary>
        /// Accesseur de l'id du ticket
        /// </summary>
        [DataMember]
        public int TicketId
        {
            get { return _TicketId; }
            set 
            {
                _TicketId = value;
            }
        }

        private int _SecondTicketId;
        /// <summary>
        /// Accesseur de l'id du second ticket
        /// </summary>
        [DataMember]
        public int SecondTicketId
        {
            get { return _SecondTicketId; }
            set
            {
                _SecondTicketId = value;
            }
        }

        private string _LienDirection;
        /// <summary>
        /// Accesseur de la direction du lien
        /// </summary>
        [DataMember]
        public string LienDirection
        {
            get { return _LienDirection; }
            set { _LienDirection = value; }
        }

        private DateTime _Creation;
        /// <summary>
        /// Accesseur de la date de création du lien
        /// </summary>
        [DataMember]
        public DateTime Creation
        {
            get { return _Creation; }
            set { _Creation = value; }
        }
        
        #endregion

        #region PUBLICS VARIABLES


        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur du TicketLienDTO
        /// </summary>
        /// <remarks>Jclaud 2015-08-07 - Création</remarks>
        public TicketLienDTO()
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
            /// <para>Description : Fonction permettant de créer un nouveau lien pour le ticket en cours</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationTicketLienDTO</para>
            /// </summary>
            CreateTicketLien,
        }

        #endregion
    }
}
