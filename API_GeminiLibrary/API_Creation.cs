using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Countersoft.Gemini.Api;
using Countersoft.Gemini.Commons.Dto;
using DTOLibrary.Entities.Cause.Méthodes;
using DTOLibrary.Entities.Commentaire;
using DTOLibrary.Entities.Commentaire.Methodes;
using DTOLibrary.Entities.DetailType.Methodes;
using DTOLibrary.Entities.KeyWord.Methodes;
using DTOLibrary.Entities.Projet.Methodes;
using DTOLibrary.Entities.Ticket;
using DTOLibrary.Entities.Ticket.Methodes;
using DTOLibrary.Entities.TimeTracking;
using DTOLibrary.Entities.TimeTracking.Méthodes;
using DTOLibrary.Entities.Version.Methodes;
using DTOLibrary.Entities.Authentification;
using DTOLibrary.Entities.Composant.Methodes;
using DTOLibrary.Entities.Groupes.Méthodes;

namespace API_GeminiLibrary
{
    /// <summary>
    /// Classe contenant les différentes fonctions de créations d'objects
    /// </summary>
    /// <remarks>JClaud 2015-03-19 Création</remarks>
    public partial class CServiceGemini
    {
        /// <summary>
        /// Fonction permettant de créer un nouveau en fonction des paramètres
        /// </summary>
        /// <param name="pCriete">Critère de sélection</param>
        /// <returns>Ticket correspondant</returns>
        /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
        public int CreateTicket(ParamCreationTicketDTO pCritere)
        {
            //jc - Déclaration des variables
            ServiceManager lService = LanceAuthentification(pCritere.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pCritere.User));
            IssueDto lNewTicket = new IssueDto();
            IssueTimeTrackingDto lTimeTracking = new IssueTimeTrackingDto();

            #region TICKET

            //jc- on affecte les variables au nouveau ticket
            lNewTicket.Entity.ProjectId = pCritere.Ticket.Projet.IdProjet;
            //jc- si un déclarant est indiqué dans le ticket
            if (pCritere.Ticket.Declarant != null)
                //jc- création du ticket par cette personne
                lNewTicket.Entity.ReportedBy = Convert.ToInt32(pCritere.Ticket.Declarant.IdGemini);
            else
                //jc- sinon création du ticket par la personne en cours
                lNewTicket.Entity.ReportedBy = Convert.ToInt32(pCritere.User.IdGemini);

            //jc- si le type de ticket n'est pas déjà affecter alors on lui affecte une valeur par défault    
            lNewTicket.Entity.TypeId = (pCritere.Ticket.Type == null) ? 80 : pCritere.Ticket.Type.IdType;

            //jc- si une ressource est indiquée dans le ticket
            if (pCritere.Ticket.Ressource != null)
                //jc- on affecte cette personne en ressource du ticket
                lNewTicket.Entity.Resources = "|" + Convert.ToInt32(pCritere.Ticket.Ressource.IdGemini) + "|";

            lNewTicket.Entity.Title = pCritere.Ticket.NomTicket;
            lNewTicket.Entity.Description = pCritere.Ticket.DescriptionTicket;
            lNewTicket.Entity.StatusId = pCritere.Ticket.Statut.IdStatut;
            lNewTicket.Entity.ResolutionId = (pCritere.Ticket.Resolution == null) ? 0 : pCritere.Ticket.Resolution.IdResolution;
            lNewTicket.Entity.PercentComplete = Convert.ToInt32(pCritere.Ticket.Avancement);
            lNewTicket.Entity.EstimatedHours = pCritere.Ticket.Temps.EstimateHours;
            lNewTicket.Entity.EstimatedMinutes = pCritere.Ticket.Temps.EstimateMinutes;
            lNewTicket.Entity.StartDate = System.DateTime.Now.Date;
            lNewTicket.Entity.DueDate = System.DateTime.Now;
            lNewTicket.Entity.Created = System.DateTime.Now;
            lNewTicket.Entity.Revised = System.DateTime.Now;
            lNewTicket.Entity.ResolvedDate = System.DateTime.Now;
            lNewTicket.Entity.ClosedDate = System.DateTime.Now;
            lNewTicket.Entity.Creator = Convert.ToInt32(pCritere.User.IdGemini);

            //jc- gestion des versions si celles-ci sont renseignées
            if (pCritere.Ticket.VersionAffectee != 0)
                lNewTicket.Entity.AffectedVersions = "|" + pCritere.Ticket.VersionAffectee.ToString() + "|";
            if (pCritere.Ticket.RegleDansLaVersion != 0)
                lNewTicket.Entity.FixedInVersionId = pCritere.Ticket.RegleDansLaVersion;

            //jc- gestion du composant s'il est renseigné
            if (pCritere.Ticket.Composant != null)
                lNewTicket.Entity.Components = "|" + pCritere.Ticket.Composant.IdComposant.ToString() + "|";

            //jc- affectation des variables constantes pour le nouveau ticket
            lNewTicket.Entity.PriorityId = 43;
            lNewTicket.Entity.Visibility = 1;
            lNewTicket.Entity.IsParent = false;
            lNewTicket.Entity.Points = 0;

            //jc- enregistrement du nouveau ticket en base
            lNewTicket = lServiceData.Item.Create(lNewTicket.Entity);

            #endregion

            #region TIME TRACKING

            //jc- si le temps à loggé est différent de 00h00min
            if (!(pCritere.Ticket.Temps.LoggedHours == 0 && pCritere.Ticket.Temps.LoggedMinutes == 0))
            {
                //jc- affectation des variables du Time Tracking
                lTimeTracking.Entity.ProjectId = lNewTicket.Entity.ProjectId;
                lTimeTracking.Entity.IssueId = lNewTicket.Entity.Id;
                lTimeTracking.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lTimeTracking.Entity.Comment = pCritere.Ticket.DescriptionTimeTracking;
                lTimeTracking.Entity.Hours = pCritere.Ticket.Temps.LoggedHours;
                lTimeTracking.Entity.Minutes = pCritere.Ticket.Temps.LoggedMinutes;
                lTimeTracking.Entity.Created = pCritere.Ticket.Temps.DateDebut;
                lTimeTracking.Entity.EntryDate = pCritere.Ticket.Temps.DateDebut;
                //tbh - Si le type de temps est renseigné, l'assigné, sinon type de temps par défault (facturable client)
                lTimeTracking.Entity.TimeTypeId = (pCritere.Ticket.TypeTemp != null) ? (int)pCritere.Ticket.TypeTemp.IdTimeType : 52;

                //jc- on enregistre le nouveau Time Tracking
                lTimeTracking = lService.Item.LogTime(lTimeTracking.Entity);
            }

            #endregion

            #region CLIENT

            //jc- si le client est renseigné
            if (pCritere.Ticket.Client != null)
            {
                CustomFieldDataDto lCustomFieldData = new CustomFieldDataDto();

                //jc- affectation des variables a la cause
                lCustomFieldData.Entity.Data = pCritere.Ticket.Client.Identifiant.ToString();
                lCustomFieldData.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lCustomFieldData.Entity.ProjectId = lNewTicket.Entity.ProjectId;
                lCustomFieldData.Entity.IssueId = lNewTicket.Entity.Id;
                //jc- affectation des constantes au nouveau client
                lCustomFieldData.Entity.CustomFieldId = (lNewTicket.Entity.ProjectId == 95) ? 100 : 99;
                lCustomFieldData.Entity.Created = System.DateTime.Now;
                lCustomFieldData.Entity.Revised = System.DateTime.Now;

                //jc- on enregistre la nouvelle cause
                lServiceData.Item.CustomFieldDataCreate(lCustomFieldData.Entity);
            }

            #endregion

            #region COMMENT

            //jc- si la description pour un commentaire est renseigné et le projet n'est pas Support ACA (101) ou Support Client (107)
            if (pCritere.Ticket.DescriptionCommentTicket != "" && pCritere.OldTicket.Projet.IdProjet != 101
                && pCritere.OldTicket.Projet.IdProjet != 107)
            {
                //jc - Déclaration des variables
                IssueCommentDto lCommentaire = new IssueCommentDto();

                //jc- on affecte les différentes valeurs au nouveau commentaire
                lCommentaire.Entity.Comment = pCritere.Ticket.DescriptionCommentTicket;
                lCommentaire.Entity.ProjectId = pCritere.OldTicket.Projet.IdProjet;
                lCommentaire.Entity.IssueId = (pCritere.OldTicket.IdTicket == 0) ? lNewTicket.Id : pCritere.OldTicket.IdTicket;
                lCommentaire.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lCommentaire.Entity.Created = System.DateTime.Now;
                lCommentaire.Entity.Fullname = pCritere.User.Login;
                //jc- affectation de constantes
                lCommentaire.Entity.IsClosing = false;
                lCommentaire.Entity.Visibility = 1;

                //jc- intégration du nouveau commentaire via l'API
                lServiceData.Item.IssueCommentCreate(lCommentaire.Entity);
            }

            #endregion

            #region PROJET

            if (pCritere.OldTicket.Projet != null)
            {
                //jc - Déclaration des variables
                CustomFieldDataDto lCustomFieldDataProjet = new CustomFieldDataDto();

                //jc- affectation des variables a la cause
                lCustomFieldDataProjet.Entity.Data = pCritere.OldTicket.Projet.IdProjet.ToString();
                lCustomFieldDataProjet.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lCustomFieldDataProjet.Entity.ProjectId = lNewTicket.Entity.ProjectId;
                lCustomFieldDataProjet.Entity.IssueId = lNewTicket.Entity.Id;
                //jc- affectation des constantes à la nouvelle cause
                lCustomFieldDataProjet.Entity.CustomFieldId = 102;
                lCustomFieldDataProjet.Entity.Created = System.DateTime.Now;
                lCustomFieldDataProjet.Entity.Revised = System.DateTime.Now;

                //jc- on enregistre la nouvelle cause
                lServiceData.Item.CustomFieldDataCreate(lCustomFieldDataProjet.Entity);
            }

            #endregion

            #region RAISON

            if (pCritere.Ticket.Raison != null)
            {
                //jc - Déclaration des variables
                CustomFieldDataDto lCustomFieldDataRaison = new CustomFieldDataDto();

                //jc- affectation des variables a la cause
                lCustomFieldDataRaison.Entity.Data = pCritere.Ticket.Raison.IdRaison.ToString();
                lCustomFieldDataRaison.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lCustomFieldDataRaison.Entity.ProjectId = lNewTicket.Entity.ProjectId;
                lCustomFieldDataRaison.Entity.IssueId = lNewTicket.Entity.Id;
                //jc- affectation des constantes à la nouvelle raison
                lCustomFieldDataRaison.Entity.CustomFieldId = 103;
                lCustomFieldDataRaison.Entity.Created = System.DateTime.Now;
                lCustomFieldDataRaison.Entity.Revised = System.DateTime.Now;

                //jc- on enregistre la nouvelle cause
                lServiceData.Item.CustomFieldDataCreate(lCustomFieldDataRaison.Entity);
            }

            #endregion

            #region PROJET CONCERNE

            //tbh- si le projet concerne n'est pas null alors on en créé un 
            if (pCritere.Ticket.ProjetConcerne != null)
            {
                //tbh - Déclaration des variables
                CustomFieldDataDto lCustomFieldProject = new CustomFieldDataDto();

                //tbh- affectation des variables a la cause
                lCustomFieldProject.Entity.Data = pCritere.Ticket.ProjetConcerne.CodeProjet.ToString();
                lCustomFieldProject.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lCustomFieldProject.Entity.ProjectId = lNewTicket.Entity.ProjectId;
                lCustomFieldProject.Entity.IssueId = lNewTicket.Entity.Id;

                //tbh- affectation des constantes à la nouvelle raison
                lCustomFieldProject.Entity.CustomFieldId = 118;
                lCustomFieldProject.Entity.Created = System.DateTime.Now;
                lCustomFieldProject.Entity.Revised = System.DateTime.Now;

                //tbh- on enregistre la nouvelle cause
                lServiceData.Item.CustomFieldDataCreate(lCustomFieldProject.Entity);
            }
            #endregion

            #region CODE AFFAIRE

            //tbh- si le code affaire n'est pas null alors on en créé un 
            if (pCritere.Ticket.CodeAffaire != null)
            {
                //tbh - Déclaration des variables
                CustomFieldDataDto lCustomFieldCodeAff = new CustomFieldDataDto();

                //tbh- affectation des variables au code affaire
                lCustomFieldCodeAff.Entity.Data = pCritere.Ticket.CodeAffaire.Code.ToString();
                lCustomFieldCodeAff.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lCustomFieldCodeAff.Entity.ProjectId = lNewTicket.Entity.ProjectId;
                lCustomFieldCodeAff.Entity.IssueId = lNewTicket.Entity.Id;

                //tbh- affectation des constantes à la nouvelle raison
                if (pCritere.Ticket.Projet != null)
                {
                    switch (pCritere.Ticket.Projet.TemplateId)
                    {
                        case 18:
                            lCustomFieldCodeAff.Entity.CustomFieldId = 39;
                            break;
                        case 26:
                            lCustomFieldCodeAff.Entity.CustomFieldId = 112;
                            break;
                        case 17:
                            lCustomFieldCodeAff.Entity.CustomFieldId = 123;
                            break;
                        case 21:
                            lCustomFieldCodeAff.Entity.CustomFieldId = 126;
                            break;
                        case 23:
                            lCustomFieldCodeAff.Entity.CustomFieldId = 125;
                            break;
                        case 22:
                            lCustomFieldCodeAff.Entity.CustomFieldId = 124;
                            break;
                        default:
                            lCustomFieldCodeAff.Entity.CustomFieldId = 112;
                            break;
                    }
                }
                else
                    lCustomFieldCodeAff.Entity.CustomFieldId = 112;

                lCustomFieldCodeAff.Entity.Created = System.DateTime.Now;
                lCustomFieldCodeAff.Entity.Revised = System.DateTime.Now;

                //tbh- on enregistre la nouvelle cause
                lServiceData.Item.CustomFieldDataCreate(lCustomFieldCodeAff.Entity);
            }

            #endregion

            #region CODE CONTRAT

            //jc- si le code contrat n'est pas null alors on en créait un 
            if (pCritere.Ticket.CodeContrat != null)
            {
                //jc - Déclaration des variables
                CustomFieldDataDto lCustomFieldContrat = new CustomFieldDataDto();

                //jc- affectation des variables a la cause
                lCustomFieldContrat.Entity.Data = pCritere.Ticket.CodeContrat.Code.ToString();
                lCustomFieldContrat.Entity.UserId = Convert.ToInt32(pCritere.User.IdGemini);
                lCustomFieldContrat.Entity.ProjectId = lNewTicket.Entity.ProjectId;
                lCustomFieldContrat.Entity.IssueId = lNewTicket.Entity.Id;
                //jc- affectation des constantes à la nouvelle raison
                lCustomFieldContrat.Entity.CustomFieldId = 124;
                lCustomFieldContrat.Entity.Created = System.DateTime.Now;
                lCustomFieldContrat.Entity.Revised = System.DateTime.Now;

                //jc- on enregistre la nouvelle cause
                lServiceData.Item.CustomFieldDataCreate(lCustomFieldContrat.Entity);
            }

            #endregion

            //jc- on retourne l'id du nouveau ticket crée
            return lNewTicket.Id;
        }

        /// <summary>
        /// Fonction qui permet la création d'un commentaire à l'aide de l'API Gemini
        /// </summary>
        /// <param name="pCritere">Critère de commentaire</param>
        /// <remarks>JClaud 2015-03-19 Création</remarks>
        public void CreateComment(ParamCommentaireDTO pParam)
        {
            //jc- on ne créait pas de commentaire si la variable est vide
            if (!String.IsNullOrWhiteSpace(pParam.Commentaire.CommentaireHtml))
            {
                //jc - Déclaration des variables
                ServiceManager lService = LanceAuthentification(pParam.User);
                IssueCommentDto lCommentaire = new IssueCommentDto();

                //jc- on affecte les différentes valeurs au nouveau commentaire
                lCommentaire.Entity.Comment = pParam.Commentaire.CommentaireHtml;
                lCommentaire.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
                lCommentaire.Entity.IssueId = pParam.Ticket.IdTicket;
                lCommentaire.Entity.UserId = Convert.ToInt32(pParam.User.IdGemini);
                lCommentaire.Entity.Created = System.DateTime.Now;
                lCommentaire.Entity.Fullname = pParam.User.Login;
                //jc- affectation de constantes
                lCommentaire.Entity.IsClosing = false;
                lCommentaire.Entity.Visibility = 1;

                //jc- intégration du nouveau commentaire via l'API
                lService.Item.IssueCommentCreate(lCommentaire.Entity);
            }
        }

        /// <summary>
        /// Fonction permettant la création de nouveaux Time Tracking via l'API Gemini
        /// </summary>
        /// <param name="pCritere">Critère de Time Tracking</param>
        /// <remarks>JClaud 2015-03-19 Création</remarks>
        public void CreateTimeTracking(ParamTimeTrackingDTO pParam)
        {
            //jc - Déclaration des variables
            ServiceManager lService = pParam.UserCreation != null ? LanceAuthentification(pParam.UserCreation) : LanceAuthentification(pParam.User);
            IssueTimeTrackingDto lTimeTracking = new IssueTimeTrackingDto();

            //jc- affectation des variables du Time Tracking
            lTimeTracking.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
            lTimeTracking.Entity.IssueId = pParam.Ticket.IdTicket;
            lTimeTracking.Entity.UserId = Convert.ToInt32(pParam.User.IdGemini);
            lTimeTracking.Entity.Comment = pParam.TimeTracking.CommentaireTimeTracking;
            lTimeTracking.Entity.Hours = pParam.TimeTracking.Heures;
            lTimeTracking.Entity.Minutes = pParam.TimeTracking.Minutes;
            lTimeTracking.Entity.Created = pParam.TimeTracking.DateAjoutTT_BDD;
            lTimeTracking.Entity.EntryDate = pParam.TimeTracking.DateSaisieTT_Ticket;
            lTimeTracking.Entity.TimeTypeId = Convert.ToInt32(pParam.TimeType.IdTimeType);

            //jc- on enregistre le nouveau Time Tracking
            lService.Item.LogTime(lTimeTracking.Entity);
        }

        /// <summary>
        /// Fonction permettant la création de nouvelle cause à l'aide de l'API Gemini
        /// </summary>
        /// <param name="pCritere">Critère de cause</param>
        /// <remarks>JClaud 2015-03-19 Création</remarks>
        public void CreateCauseData(ParamCreationCauseDTO pParam)
        {
            //jc - Déclaration des variables
            //ServiceManager lService = LanceAuthentification(pParam.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pParam.User));
            CustomFieldDataDto lCustomFieldData = new CustomFieldDataDto();

            //jc- affectation des variables a la cause
            lCustomFieldData.Entity.Data = pParam.Cause.IdCause.ToString() + "|";
            lCustomFieldData.Entity.UserId = Convert.ToInt32(pParam.User.IdGemini);
            lCustomFieldData.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
            lCustomFieldData.Entity.IssueId = pParam.Ticket.IdTicket;
            //jc- affectation des constantes à la nouvelle cause
            lCustomFieldData.Entity.CustomFieldId = 85;
            lCustomFieldData.Entity.Created = System.DateTime.Now;
            lCustomFieldData.Entity.Revised = System.DateTime.Now;

            //jc- on enregistre la nouvelle cause
            lServiceData.Item.CustomFieldDataCreate(lCustomFieldData.Entity);
        }

        /// <summary>
        /// Fonction permettant la création de nouveaux detail type à l'aide de l'API Gemini
        /// </summary>
        /// <param name="pParam">Critère de detail type</param>
        /// <remarks>JClaud 2015-07-20 Création</remarks>        
        public void CreateDetailTypeData(ParamCreationDetailTypeDTO pParam)
        {
            //jc - Déclaration des variables
            //ServiceManager lService = LanceAuthentification(pParam.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pParam.User));
            CustomFieldDataDto lCustomFieldData = new CustomFieldDataDto();

            //jc- affectation des variables a la cause
            lCustomFieldData.Entity.Data = pParam.DetailType.IdDetailType.ToString() + "|";
            lCustomFieldData.Entity.UserId = Convert.ToInt32(pParam.User.IdGemini);
            lCustomFieldData.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
            lCustomFieldData.Entity.IssueId = pParam.Ticket.IdTicket;
            //jc- affectation des constantes à la nouvelle cause
            lCustomFieldData.Entity.CustomFieldId = 96;
            lCustomFieldData.Entity.Created = System.DateTime.Now;
            lCustomFieldData.Entity.Revised = System.DateTime.Now;

            //jc- on enregistre la nouvelle cause
            lServiceData.Item.CustomFieldDataCreate(lCustomFieldData.Entity);
        }

        /// <summary>
        /// Fonction permettant la création de nouveaux KeyWord à l'aide de l'API Gemini
        /// </summary>
        /// <param name="pParam">Critère de KeyWord</param>
        /// <remarks>JClaud 2015-07-20 Création</remarks>
        public void CreateKeyWordData(ParamCreationKeyWordDTO pParam)
        {
            //jc - Déclaration des variables
            //ServiceManager lService = LanceAuthentification(pParam.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pParam.User));
            CustomFieldDataDto lCustomFieldData = new CustomFieldDataDto();

            //jc- affectation des variables a la cause
            lCustomFieldData.Entity.Data = pParam.KeyWord.IdKeyWord.ToString() + "|";
            lCustomFieldData.Entity.UserId = Convert.ToInt32(pParam.User.IdGemini);
            lCustomFieldData.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
            lCustomFieldData.Entity.IssueId = pParam.Ticket.IdTicket;
            //jc- affectation des constantes à la nouvelle cause
            lCustomFieldData.Entity.CustomFieldId = 94;
            lCustomFieldData.Entity.Created = System.DateTime.Now;
            lCustomFieldData.Entity.Revised = System.DateTime.Now;

            //jc- on enregistre la nouvelle cause
            lServiceData.Item.CustomFieldDataCreate(lCustomFieldData.Entity);
        }

        /// <summary>
        /// Fonction permettant la création de nouveaux clarte à l'aide de l'API Gemini
        /// </summary>
        /// <param name="pParam">Critère de clarte</param>
        /// <remarks>JClaud 2015-07-20 Création</remarks>
        public void CreateClarteData(ParamCreationClarteDTO pParam)
        {
            //jc - Déclaration des variables
            //ServiceManager lService = LanceAuthentification(pParam.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pParam.User));
            CustomFieldDataDto lCustomFieldData = new CustomFieldDataDto();

            //jc- affectation des variables de la clartée si != de 0
            if (pParam.Clarte != null)
                lCustomFieldData.Entity.NumericData = Convert.ToDouble(pParam.Clarte);
            lCustomFieldData.Entity.UserId = Convert.ToInt32(pParam.User.IdGemini);
            lCustomFieldData.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
            lCustomFieldData.Entity.IssueId = pParam.Ticket.IdTicket;
            //jc- affectation des constantes à la nouvelle cause
            lCustomFieldData.Entity.CustomFieldId = 98;
            lCustomFieldData.Entity.Created = System.DateTime.Now;
            lCustomFieldData.Entity.Revised = System.DateTime.Now;

            //jc- on enregistre la nouvelle cause
            lServiceData.Item.CustomFieldDataCreate(lCustomFieldData.Entity);
        }

        /// <summary>
        /// Fonction permettant la création de nouveaux project à l'aide de l'API Gemini
        /// </summary>
        public void CreateProjetData(ParamCreationProjetDTO pParam)
        {
            //jc - Déclaration des variables
            //ServiceManager lService = LanceAuthentification(pParam.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pParam.User));
            CustomFieldDataDto lCustomFieldData = new CustomFieldDataDto();

            //jc- affectation des variables a la cause
            lCustomFieldData.Entity.Data = pParam.Projet.CodeProjet.ToString();
            lCustomFieldData.Entity.UserId = Convert.ToInt32(pParam.User.IdGemini);
            lCustomFieldData.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
            lCustomFieldData.Entity.IssueId = pParam.Ticket.IdTicket;
            //jc- affectation des constantes à la nouvelle cause
            lCustomFieldData.Entity.CustomFieldId = 45;
            lCustomFieldData.Entity.Created = System.DateTime.Now;
            lCustomFieldData.Entity.Revised = System.DateTime.Now;

            //jc- on enregistre la nouvelle cause
            lServiceData.Item.CustomFieldDataCreate(lCustomFieldData.Entity);
        }

        /// <summary>
        /// Méthode qui permet de créer une version liée à un ticket
        /// </summary>
        /// <param name="pParam">Paramètre pour la création</param>
        /// <remarks>JClaud 2015-07-21 Création</remarks>
        public void CreateVersionData(ParamCreationVersionDTO pParam)
        {
            //jc - Déclaration des variables
            //ServiceManager lService = LanceAuthentification(pParam.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pParam.User));
            VersionDto lVersionDto = new VersionDto();

            //jc- affectation des variables a la cause
            lVersionDto.Entity.Name = pParam.Version.VersionName;
            lVersionDto.Entity.Label = pParam.Version.VersionNumber;
            lVersionDto.Entity.Name = pParam.Version.VersionName;
            lVersionDto.Entity.ProjectId = pParam.Version.IdProjet;

            //jc- on enregistre la nouvelle cause
            lServiceData.Projects.CreateVersion(lVersionDto.Entity);
        }

        /// <summary>
        /// Fonction permettant la création de nouveaux composant à l'aide de l'API Gemini
        /// </summary>
        /// <remarks>JClaud 2015-07-27 Création</remarks>
        public void CreateComposant(ParamCreationComposantDTO pParam)
        {
            //jc - Déclaration des variables
            //ServiceManager lService = LanceAuthentification(pParam.User);
            ServiceManager lServiceData = LanceAuthentification(CopyUserAsAPI(pParam.User));
            ComponentDto lComponent = new ComponentDto();

            //jc- affectation des variables au composant
            lComponent.Entity.Name = pParam.Composant.NomComposant;
            lComponent.Entity.Description = pParam.Composant.DescrComposant;
            lComponent.Entity.ProjectId = pParam.Ticket.Projet.IdProjet;
            lComponent.Entity.ReadOnly = false;
            //jc- affectation des constantes au nouveau composant
            lComponent.Entity.Created = System.DateTime.Now;
            lComponent.Entity.Revised = System.DateTime.Now;

            //jc- on enregistre la nouvelle cause
            lServiceData.Projects.CreateComponent(lComponent.Entity);
        }

        /// <summary>
        /// Fonction permettant la création de nouveaux groupes à l'aide de l'API Gemini
        /// </summary>
        /// <remarks>JClaud 2015-07-27 Création</remarks>
        public void CreateGroupeData(ParamCreationGroupeDTO pParam)
        {

        }
    }
}
