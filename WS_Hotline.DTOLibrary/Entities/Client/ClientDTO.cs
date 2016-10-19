using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Client
{
    /// <summary>
    /// Classe correspondant à un client
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-06-19 - Création</remarks>
    [DebuggerDisplay("Identifiant = {Identifiant} - Code Client = {CodeClient} - Is Actif = {IsActif}")]
    [DataContract]
    public class ClientDTO : BaseDTO
    {
        #region ATTRIBUTS / ACCESSEURS

        private int _Identifiant;
        /// <summary>
        /// Accesseur de l'identifiant du client
        /// </summary>
        [DataMember]
        public int Identifiant
        {
            get { return _Identifiant; }
            set { _Identifiant = value; }
        }

        private string _CodeClient;
        /// <summary>
        /// Accesseur du code client
        /// </summary>
        [DataMember]
        public string CodeClient
        {
            get { return _CodeClient; }
            set { _CodeClient = value; }
        }

        private string _Libelle;
        /// <summary>
        /// Accesseur du libellé du client
        /// </summary>
        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }

        private bool? _IsActif;
        /// <summary>
        /// Accesseur du bool qui indique si le client est actif ou non
        /// </summary>
        public bool? IsActif
        {
            get { return _IsActif; }
            set { _IsActif = value; }
        }

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-06-19 - Création</remarks>
        public ClientDTO()
        {

        }

        #endregion
    }
}
