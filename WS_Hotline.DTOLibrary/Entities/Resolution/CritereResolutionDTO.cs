using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Resolution
{
    //jc- classe de critère pour ResolutionDTO
    [DebuggerDisplay("ID Resolution {IdResolution} - Sequencement = {Seq} - Libelle Resolution = {ResolutionLibelle}")]
    [DataContract]
    public class CritereResolutionDTO : CritereBaseDTO
    {
        #region ACCESSEURS

        private int _IdResolution;
        /// <summary>
        /// Accesseur de l'identifiant de la résolution
        /// </summary>
        [DataMember]
        public int IdResolution
        {
            get { return _IdResolution; }
            set { _IdResolution = value; }
        }

        private string _Seq;
        /// <summary>
        /// Accesseur du sequencement des resolutions
        /// </summary>
        [DataMember]
        public string Seq
        {
            get { return _Seq; }
            set { _Seq = value; }
        }

        private bool _IsFinal;
        /// <summary>
        /// Accesseur du statut de finalité
        /// </summary>
        [DataMember]
        public bool IsFinal
        {
            get { return _IsFinal; }
            set
            {
                _IsFinal = value;
            }
        }

        private string _ResolutionLibelle;
        /// <summary>
        /// Accesseur du libelle de la resolution
        /// </summary>
        [DataMember]
        public string ResolutionLibelle
        {
            get { return _ResolutionLibelle; }
            set { _ResolutionLibelle = value; }
        }

        private int _TemplateId;
        /// <summary>
        /// Accesseur du template lié a la résolution
        /// </summary>
        [DataMember]
        public int TemplateId
        {
            get { return _TemplateId; }
            set { _TemplateId = value; }
        }

        private AuthentificationDTO _User;
        /// <summary>
        /// Accesseur de l'utilisateur en cours
        /// </summary>
        [DataMember]
        public AuthentificationDTO User
        {
            get { return _User; }
            set { _User = value; }
        }

        private TicketDTO _Ticket;
        /// <summary>
        /// Accesseur du ticket en cours
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }

        #endregion
    }
}
