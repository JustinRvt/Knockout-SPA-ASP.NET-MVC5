using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Client
{
    /// <summary>
    /// Classe de critère pour les clients
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-06-19 - Création</remarks>
    [DebuggerDisplay("Identifiant Client = {IdentifiantClient} - Nom Client = {NomClient} - Is Actif = {IsActif}")]
    [DataContract]
    public class CritereClientDTO : CritereBaseDTO
    {
        #region ATTRIBUTS

        private int? _IdentifiantClient;
        /// <summary>
        /// Accesseur de l'identifiant du client
        /// </summary>
        [DataMember]
        public int? IdentifiantClient
        {
            get { return _IdentifiantClient; }
            set { _IdentifiantClient = value; }
        }

        private string _NomClient;
        /// <summary>
        /// Accesseur du nom du client
        /// </summary>
        [DataMember]
        public string NomClient
        {
            get { return _NomClient; }
            set { _NomClient = value; }
        }

        private bool? _IsActif;
        /// <summary>
        /// Accesseur du bool qui indique si le client est actif
        /// </summary>
        [DataMember]
        public bool? IsActif
        {
            get { return _IsActif; }
            set { _IsActif = value; }
        }

        #endregion
    }
}
