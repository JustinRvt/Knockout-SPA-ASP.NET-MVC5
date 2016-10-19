using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WS_Hotline.DTOLibrary.Entities.Type
{
    /// <summary>
    /// Classe permettant de gérer le type d'un ticket
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("ID Type = {IdType} - Libelle Type = {LibelleType} - Is En Cours = {IsEnCours}")]
    [DataContract]
    public class TypeDTO
    {
        #region PROPERTIES

        private int _IdType;
        /// <summary>
        /// Accesseur de l'id du type
        /// </summary>
        [DataMember]
        public int IdType
        {
            get { return _IdType; }
            set { _IdType = value; }
        }

        private string _LibelleType;
        /// <summary>
        /// Accesseur du libellé du type
        /// </summary>
        [DataMember]
        public string LibelleType
        {
            get { return _LibelleType; }
            set { _LibelleType = value; }
        }

        private bool _IsEnCours;
        /// <summary>
        /// Accesseur du champ IsEnCours
        /// </summary>
        [DataMember]
        public bool IsEnCours
        {
            get { return _IsEnCours; }
            set { _IsEnCours = value; }
        }

        #endregion
    }
}
