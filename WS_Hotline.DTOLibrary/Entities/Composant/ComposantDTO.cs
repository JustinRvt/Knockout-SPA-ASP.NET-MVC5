using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Composant
{
    /// <summary>
    /// Classe permettant la gestion des composants
    /// </summary>
    /// <remarks>JClaud 2015-07-27 Création</remarks>
    [DebuggerDisplay("ID Composant = {IdComposant} - ID Projet = {IdProjet} - Nom Composant = {NomComposant}")]
    [DataContract]
    public class ComposantDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdComposant;
        /// <summary>
        /// Accesseur de l'identifiant du composant
        /// </summary>
        [DataMember]
        public int IdComposant
        {
            get { return _IdComposant; }
            set { _IdComposant = value; }
        }

        private int _IdProjet;
        /// <summary>
        /// Accesseur de l'id du projet lié
        /// </summary>
        [DataMember]
        public int IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private string _NomComposant;
        /// <summary>
        /// Accesseur du nom du composant
        /// </summary>
        [DataMember]
        public string NomComposant
        {
            get { return _NomComposant; }
            set 
            {
                _NomComposant = value;
            }
        }

        private string _DescrComposant;
        /// <summary>
        /// Accesseur de la description du composant
        /// </summary>
        [DataMember]
        public string DescrComposant
        {
            get { return _DescrComposant; }
            set { _DescrComposant = value; }
        }

        private int _OrdreComposant;
        /// <summary>
        /// Accesseur de l'ordre du composant
        /// </summary>
        [DataMember]
        public int OrdreComposant
        {
            get { return _OrdreComposant; }
            set { _OrdreComposant = value; }
        }

        private bool _IsComposantReadOnly;
        /// <summary>
        /// Accesseur du booléen de lecture seule
        /// </summary>
        [DataMember]
        public bool IsComposantReadOnly
        {
            get { return _IsComposantReadOnly; }
            set { _IsComposantReadOnly = value; }
        }
        
        #endregion

        #region PUBLICS VARIABLES
        
        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-02-23 - Création</remarks>
        public ComposantDTO()
        {

        }

        #endregion

        #region METHODES / FONCTIONS

        #region VALIDATION DTO

        /// <summary>
        /// Méthode permettant de valider le DTO
        /// Si il y a une erreur, une exception est levée
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-02-18 - Création</remarks>
        public override void ValidationDTO()
        {
            //gb - Appel les méthodes de validation des DTO
            base.ValidationDTO();
        }

        #endregion

        #endregion
    }
}
