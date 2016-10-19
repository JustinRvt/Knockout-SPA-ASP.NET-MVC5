using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Tache
{
    public class CritereTacheDTO : CritereBaseDTO
    {
        [DebuggerDisplay("Identifiant = {Identifiant} - ID Projet = {IdProjet} - Nom = {Nom}")]

        #region ATTRIBUTS / ACCESSEURS

        private decimal _Identifiant;
        /// <summary>
        /// Accesseur de l'identifiant de la tache
        /// </summary>
        [DataMember]
        public decimal Identifiant
        {
            get { return _Identifiant; }
            set { _Identifiant = value; }
        }

        private decimal _IdProjet;
        /// <summary>
        /// Accesseur de l'identifiant du projet
        /// </summary>
        [DataMember]
        public decimal IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private string _Nom;
        /// <summary>
        /// Accesseur du nom de la tache
        /// </summary>
        [DataMember]
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        private string _Description;
        /// <summary>
        /// Accesseur du nom de la tache
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion
    }
}
