using Countersoft.Gemini.Api;
using Countersoft.Gemini.Commons.Dto;
using DTOLibrary.Entities.Statut.Méthodes;
using DTOLibrary.Entities.Ticket.Methodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTOLibrary.Entities.Resolution.Methodes;
using DTOLibrary.Entities.Ticket;
using Countersoft.Gemini.Commons.Entity;

namespace API_GeminiLibrary
{
    /// <summary>
    /// Classe d'accès aux données des tickets
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-03-12 - Création</remarks>
    public partial class CServiceGemini
    {
        #region METHODES / FONCTIONS

        /// <summary>
        /// Méthode permettant de mettre à jour les informations
        /// générales du ticket
        /// </summary>
        /// <param name="pParam">Paramètre de la méthode</param>
        /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
        public void UpdateAvancement(ParamUpdateAvancementDTO pParam)
        {
            //gb - Récupération de la connexion vers Gemini
            ServiceManager lService = LanceAuthentification(CopyUserAsAPI(pParam.User));

            //gb - Récupération du ticket à modifier
            IssueDto lUpdateTicket = GetTicket(lService, pParam.CriteteTicket);

            //gb - Si le ticket n'est pas null
            if (lUpdateTicket != null)
            {
                //gb - Mise à jour des valeurs
                lUpdateTicket.Entity.PercentComplete = pParam.Avancement;
                lService.Item.Update(lUpdateTicket.Entity);
            }
        }

        /// <summary>
        /// Méthode permettant de mettre à jour la ressource du ticket
        /// </summary>
        /// <param name="pParam">Paramètre de la méthode</param>
        /// <remarks>JClaud - 2015-09-21 - Création</remarks>
        public void UpdateUserTicket(ParamUpdateTicketDTO pParam)
        {
            //jc - Récupération de la connexion vers Gemini
            ServiceManager lService = LanceAuthentification(CopyUserAsAPI(pParam.User));

            //jc - Récupération du ticket à modifier
            IssueDto lUpdateTicket = GetTicket(lService, pParam.CriteteTicket);

            //jc - Si le ticket n'est pas null
            if (lUpdateTicket != null)
            {
                //jc- si l'utilisateur n'est pas déjà en ressource
                if (!lUpdateTicket.Entity.Resources.Contains("|" + pParam.User.IdGemini + "|"))
                {
                    //jc - Mise à jour des valeurs
                    lUpdateTicket.Entity.Resources = String.IsNullOrWhiteSpace(lUpdateTicket.Entity.Resources) ? "|" + pParam.User.IdGemini + "|" : lUpdateTicket.Entity.Resources + pParam.User.IdGemini + "|";
                    //jc- sauvegarde de l'update en base
                    lService.Item.Update(lUpdateTicket.Entity);
                }
            }
        }

        #endregion
    }
}
