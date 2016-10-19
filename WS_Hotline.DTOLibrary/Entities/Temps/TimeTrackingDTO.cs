using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Temps
{
    /// <summary>
    /// Classe permettant de gérer les temps saisie
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DataContract]
    public class TimeTrackingDTO : BaseDTO
    {
        #region PROPERTIES

        private int _NbHeure;
        /// <summary>
        /// Accesseur du nombre d'heure
        /// </summary>
        [DataMember]
        public int NbHeure
        {
            get { return _NbHeure; }
            set { _NbHeure = value; }
        }

        private int _NbMinutes;
        /// <summary>
        /// Accesseur du nombre de minutes
        /// </summary>
        [DataMember]
        public int NbMinutes
        {
            get { return _NbMinutes; }
            set { _NbMinutes = value; }
        }

        #endregion
    }
}
