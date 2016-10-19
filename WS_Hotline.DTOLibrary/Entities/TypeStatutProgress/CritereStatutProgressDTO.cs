using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.TypeStatutProgress
{
    /// <summary>
    /// Classe de critère pour la recherche des StatutProgressDTO
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-03-12 - Création</remarks>
    [DebuggerDisplay("Type Statut = {TypeStatut}")]
    [DataContract]
    public class CritereStatutProgressDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private string _TypeStatut;
        /// <summary>
        /// Accesseur du type de statut que l'on souhaite récupérer
        /// </summary>
        [DataMember]
        public string TypeStatut
        {
            get { return _TypeStatut; }
            set { _TypeStatut = value; }
        }

        #endregion
    }
}
