using Countersoft.Gemini.Api;
using Countersoft.Gemini.Commons.Dto;
using Countersoft.Gemini.Commons.Entity;
using DTOLibrary.Entities.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_GeminiLibrary
{
    /// <summary>
    /// Classe contenant les méthodes de recherche
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-03-12 - Création</remarks>
    public partial class CServiceGemini
    {
        #region METHODES / FONCTIONS

        /// <summary>
        /// Fonction permettant de retourner le ticket
        /// en fonction des paramètres
        /// </summary>
        /// <param name="pCritere">Critère de sélection</param>
        /// <returns>Ticket correspondant</returns>
        /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
        private IssueDto GetTicket(ServiceManager pService, CritereTicketDTO pCritere)
        {
            //gb - Déclaration des variables
            IssuesFilter lFiltre = new IssuesFilter();
            List<IssueDto> lResultat = new List<IssueDto>();

            //gb - Si on a une restriction sur l'id
            if (pCritere.IdTicket != null)
                lFiltre.Issues = pCritere.IdTicket;

            //gb - Récupération des tickets
            lResultat = pService.Item.GetFilteredItems(lFiltre);

            //gb - Retourne le premier item s'il y en a un
            return lResultat.FirstOrDefault();
        }

        #endregion
    }
}
