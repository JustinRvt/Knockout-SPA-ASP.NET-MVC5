using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Statut
{
    /// <summary>
    /// Classe permettant de gérer le statut d'un ticket
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("ID Statut = {IdStatut} - Libelle Statut = {LibelleStatut}")]
    [DataContract]
    public class StatutDTO : BaseDTO
    {
        #region PROPERTIES

        private int _IdStatut;
        /// <summary>
        /// Accesseur de l'id du statut
        /// </summary>
        [DataMember]
        public int IdStatut
        {
            get { return _IdStatut; }
            set { _IdStatut = value; }
        }

        private string _LibelleStatut;
        /// <summary>
        /// Accesseur du libellé du statut
        /// </summary>
        [DataMember]
        public string LibelleStatut
        {
            get { return _LibelleStatut; }
            set { _LibelleStatut = value; }
        }

        private string _Couleur;
        /// <summary>
        /// Accesseur de la couleur du statut
        /// </summary>
        [DataMember]
        public string Couleur
        {
            get { return _Couleur; }
            set { _Couleur = value; }
        }

        private int _IdTemplate;
        /// <summary>
        /// Accesseur de l'id du template
        /// </summary>
        [DataMember]
        public int IdTemplate
        {
            get { return _IdTemplate; }
            set { _IdTemplate = value; }
        }

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de retourner la liste des statuts</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type CritereStatutDTO</para>
            /// </summary>
            GetData,
            /// <summary>
            /// <para>Description : Méthode permettant de mettre à jour le statut d'un ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamUpdateStatutDTO</para>
            /// </summary>
            UpdateStatut
        }

        #endregion
    }
}
