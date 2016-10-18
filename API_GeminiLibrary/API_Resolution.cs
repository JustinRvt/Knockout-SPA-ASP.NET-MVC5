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
using DTOLibrary.Entities.Authentification;
using DTOLibrary.Entities.Statut;
using System.Collections.ObjectModel;
using DTOLibrary.Entities.Resolution;
using Countersoft.Gemini.Commons.Meta;

namespace API_GeminiLibrary
{
    /// <summary>
    /// Classe d'accès aux données des résolutions
    /// </summary>
    /// <remarks>JClaud 2015-03-13 Création</remarks>
    public partial class CServiceGemini
    {
        #region METHODES/FONCTIONS

        /// <summary>
        /// Méthode permettant de transformer une liste de IssueResolution en ResolutionDTO connu par le reste de l'application
        /// </summary>
        /// <param name="pIssueResolutionDto">Liste de IssueResolution du service</param>
        /// <returns>Une liste de ResolutionDTO</returns>
        /// <remarks>JClaud 2015-03-12 Création</remarks>
        private ObservableCollection<ResolutionDTO> FormatIssuesResToDTO(List<IssueResolution> pIssueResolutionDto)
        {
            //jc- on retourne une liste de StatutDTO
            return new ObservableCollection<ResolutionDTO>(pIssueResolutionDto
                                .Select(p => new ResolutionDTO()
                                {
                                    //jc- affectation des différentes valeurs
                                    IdResolution = p.Id,
                                    ResolutionLibelle = p.Label,
                                    Seq = p.Sequence,
                                    TemplateId = p.TemplateId
                                }));
        }

        /// <summary>
        /// Fonction permettant de tester la connexion vers Gemini
        /// Si celle-ci est correcte on retourne une liste de résolutions
        /// </summary>
        /// <returns>Liste de résolutions pour le projet en cours</returns>
        /// <remarks>JClaud 2015-03-12 - Création</remarks>
        private List<IssueResolution> GetListeIssueResolutionDto(CritereResolutionDTO pParam)
        {
            //jc - Retourne la liste des résolutions disponible pour le projet en cours
            return new List<IssueResolution>(LanceAuthentification(pParam.User).Meta.GetIssueResolutions()
                                                                                           .Where(p => p.TemplateId == pParam.Ticket.Projet.TemplateId));
        }

        /// <summary>
        /// Méthode publique pour retourner la liste des résolution en fonction d'un CritereResolutionDTO
        /// </summary>
        /// <param name="pParam">CritereResolutionDTO</param>
        /// <returns>Une liste de ResolutionDTO</returns>
        /// <remarks>JClaud 2015-03-13 Création</remarks>
        public ObservableCollection<ResolutionDTO> GetListeResolution(CritereResolutionDTO pParam)
        {
            //jc- on appel la fonction qui va questionner l'API GEMINI
            return FormatIssuesResToDTO(GetListeIssueResolutionDto(pParam));
        }

        /// <summary>
        /// Méthode permettant de mettre à jour la résolution d'un ticket  
        /// </summary>
        /// <param name="pParam">Paramètre de la méthode</param>
        /// <remarks>JClaud 2015-03-10- Création</remarks>
        public void UpdateResolution(ParamResolutionDTO pParam)
        {
            //jc - Récupération de la connexion vers Gemini
            ServiceManager lService = LanceAuthentification(pParam.User);

            //jc - Récupération du ticket à modifier
            IssueDto lUpdateTicket = GetTicket(lService, pParam.CriteteTicket);

            //jc - Si le ticket n'est pas null
            if (lUpdateTicket != null && pParam.Resolution.IdResolution != 0)
            {
                //jc - Affectation du nouveau statut
                lUpdateTicket.Entity.ResolutionId = pParam.Resolution.IdResolution;
                //jc - Enregistrement via l'API
                lService.Item.Update(lUpdateTicket.Entity);
            }
        }

        #endregion
    }
}
