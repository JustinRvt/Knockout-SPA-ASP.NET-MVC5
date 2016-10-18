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
using Countersoft.Gemini.Commons.Meta;

namespace API_GeminiLibrary
{
    /// <summary>
    /// Classe d'accès aux données des status
    /// </summary>
    /// <remarks>JClaud 2015-03-12 Création</remarks>
    public partial class CServiceGemini
    {
        #region METHODES/FONCTIONS
        
        /// <summary>
        /// Méthode permettant de transformer une liste de IssueStatusDto en StatutDTO connu par le reste de l'application
        /// </summary>
        /// <param name="pIssueStatusDto">Liste de statuSDto du service</param>
        /// <returns>Une liste de StatutDTO</returns>
        /// <remarks>JClaud 2015-03-12 Création</remarks>
        private ObservableCollection<StatutDTO> FormatIssuesToDTO(List<IssueStatusDto> pIssueStatusDto)
        {
            //jc- on retourne une liste de StatutDTO
            return new ObservableCollection<StatutDTO>(pIssueStatusDto
                                .Select(p => new StatutDTO()
                                { 
                                    //jc- affectation des différentes valeurs
                                    Couleur = p.Entity.Color,
                                    IdStatut = p.Entity.Id,
                                    LibelleStatut = p.Entity.Label
                                }));
        }

        /// <summary>
        /// Fonction permettant de tester la connexion vers Gemini
        /// Si celle-ci est correcte on retourne une liste de statuts
        /// </summary>
        /// <returns>Identifiant de l'utilisateur</returns>
        /// <remarks>JClaud 2015-03-12 - Création</remarks>
        private List<IssueStatusDto> GetListeIssueStatusDto(CritereStatutDTO pParam)
        {
            //jc- déclaration de variables
            IssueTypeDto lTypeSelected;
            List<int> lListeIdStatuts = new List<int>();
            List<ItemWorkflow.WorkflowTransition> lListeWorkFlowStatuts;

            //jc - Retourne le IssueTypeDto pour le ticket et le projet en cours
            lTypeSelected = LanceAuthentification(pParam.User).Meta.GetIssueTypesForTemplate(pParam.Ticket.Projet.TemplateId)
                                                    .Where(p => p.Entity.Id == pParam.Ticket.Type.IdType)
                                                    .FirstOrDefault();

            //jc- on récupère les transitions
            lListeWorkFlowStatuts = lTypeSelected.Entity.Workflow.Status.Where(p => p.StatusId == pParam.Ticket.Statut.IdStatut)
                                                                                             .FirstOrDefault().Transitions.Select(p => p)
                                                                                             .ToList();

            //jc- on parcours la liste des transitions
            foreach (ItemWorkflow.WorkflowTransition lTransition in lListeWorkFlowStatuts)
            {
                //jc- on parcours la liste des id groupe de l'utilisateur en cours
                foreach (int lGroupeId in pParam.User.Groupes.Select(p => p.IdGroupe))
                {
                    //jc- si la transitions contient un des groupes de l'utilisateurs
                    if (lTransition.Groups.Contains(lGroupeId) && lListeIdStatuts.Contains(lTransition.StatusId) == false)
                    {
                        //jc- on ajoute et on passe à la transitions suivante
                        lListeIdStatuts.Add(lTransition.StatusId);
                    }
                }
            }

            //jc- on ajoute l'id du statut du ticket en cours
            lListeIdStatuts.Add(pParam.Ticket.Statut.IdStatut);
            //jc- gestion des doublons dans les statuts
            lListeIdStatuts = lListeIdStatuts.Distinct().ToList();

            //jc - retourne la liste des IssueStatusDto
            return new List<IssueStatusDto>(lListeIdStatuts.Select(p =>  LanceAuthentification(pParam.User).Meta.GetIssueStatus(p)));
        }

        /// <summary>
        /// Méthode publique pour retourner la liste des statuts en fonction d'un critère statut Dto
        /// </summary>
        /// <param name="pParam">CritèreStatutDTO</param>
        /// <returns>Une liste de statutDTO</returns>
        /// <remarks>JClaud 2015-03-13 Création</remarks>
        public ObservableCollection<StatutDTO> GetListeStatut(CritereStatutDTO pParam)
        {
            //jc- on appel la fonction qui va questionner l'API GEMINI
            return FormatIssuesToDTO(GetListeIssueStatusDto(pParam));
        }

        /// <summary>
        /// Méthode permettant de mettre à jour le status d'un ticket
        /// </summary>
        /// <param name="pParam">Paramètre de la méthode</param>
        /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
        public void UpdateStatut(ParamUpdateStatutDTO pParam)
        {
            //gb - Récupération de la connexion vers Gemini
            ServiceManager lService = LanceAuthentification(pParam.User);

            //gb - Récupération du ticket à modifier
            IssueDto lUpdateTicket = GetTicket(lService, pParam.CriteteTicket);

            //gb - Si le ticket n'est pas null et que le statut n'est pas le même
            if (lUpdateTicket != null && pParam.Statut.IdStatut != 0)
            {
                //gb - Affectation du nouveau statut
                lUpdateTicket.Entity.StatusId = pParam.Statut.IdStatut;
                //gb - Enregistrement via l'API
                lService.Item.Update(lUpdateTicket.Entity);
            }
        }
        
        #endregion
    }
}
