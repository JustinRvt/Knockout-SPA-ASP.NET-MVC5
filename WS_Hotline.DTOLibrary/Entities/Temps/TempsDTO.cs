using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.TimeTracking;
using System.Diagnostics;

namespace DTOLibrary.Entities.Temps
{
    /// <summary>
    /// Classe permettant de gérer les temps d'un ticket
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("DateDebut = {DateDebut} - DateFin = {DateFin}")]
    [DataContract]
    public class TempsDTO : BaseDTO
    {
        #region PROPERTIES

        private DateTime _DateDebut;
        /// <summary>
        /// Accesseur de la date de début
        /// </summary>
        [DataMember]
        public DateTime DateDebut
        {
            get { return _DateDebut; }
            set { _DateDebut = value; }
        }

        private DateTime _DateFin;
        /// <summary>
        /// Accesseur de la date de fin
        /// </summary>
        [DataMember]
        public DateTime DateFin
        {
            get { return _DateFin; }
            set { _DateFin = value; }
        }

        private int _EstimateHours;
        /// <summary>
        /// Accesseur du nombre d'heure estimé
        /// </summary>
        [DataMember]
        public int EstimateHours
        {
            get { return _EstimateHours; }
            set { _EstimateHours = value; }
        }

        private int _EstimateMinutes;
        /// <summary>
        /// Accesseur du nombre de minute estimé
        /// </summary>
        [DataMember]
        public int EstimateMinutes
        {
            get { return _EstimateMinutes; }
            set { _EstimateMinutes = value; }
        }

        private int _LoggedHours;
        /// <summary>
        /// Accesseur du nombre d'heure passé sur le ticket
        /// </summary>
        [DataMember]
        public int LoggedHours
        {
            get { return _LoggedHours; }
            set { _LoggedHours = value; }
        }

        private int _LoggedMinutes;
        /// <summary>
        /// Accesseur du nombre de minute passé sur le ticket
        /// </summary>
        [DataMember]
        public int LoggedMinutes
        {
            get { return _LoggedMinutes; }
            set { _LoggedMinutes = value; }
        }

        private ObservableCollection<TimeTrackingDTO> _ListeTimeTracking = new ObservableCollection<TimeTrackingDTO>();
        /// <summary>
        /// Accesseur de la liste des temps saisis
        /// </summary>
        [DataMember]
        public ObservableCollection<TimeTrackingDTO> ListeTimeTracking
        {
            get { return _ListeTimeTracking; }
            set { _ListeTimeTracking = value; }
        }

        #endregion
    }
}
