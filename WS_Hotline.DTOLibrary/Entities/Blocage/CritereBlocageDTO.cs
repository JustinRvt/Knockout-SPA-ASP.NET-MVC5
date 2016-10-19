using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Blocage
{
    //jc- classe de crièteres pour BlocageDTO
    [DebuggerDisplay("Nom Ticket = {Ticket.NomTicket}")]
    [DataContract]
    public class CritereBlocageDTO : CritereBaseDTO
    {
        #region ACCESSEURS

        private TicketDTO _Ticket;
        /// <summary>
        /// Accesseur du ticket
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
