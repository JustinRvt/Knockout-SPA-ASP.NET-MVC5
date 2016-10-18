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
using DTOLibrary.Entities.TimeType;


namespace API_GeminiLibrary
{
    public partial class CServiceGemini
    {
        #region METHODES/FONCTIONS
        /// <summary>
        /// Fonction permettant de tester la connexion vers Gemini
        /// Si celle-ci est correcte on retourne une liste de type
        /// </summary>
        /// <returns>Liste de Type pour le projet en cours</returns>
        /// <remarks>TBH 09-11-2015 - Création</remarks>
        private List<TimeType> GetListeTypeDto(CritereTimeTypeDTO pParam)
        {
            //tbh- déclaration de variables
            List<TimeType> lTypeSelected;

            //tbh - Retourne la liste de TimeTypeDTO
            lTypeSelected = LanceAuthentification(pParam.User).Meta.GetTimeTypes();

            //tbh- restriction sur le Template Id du TimeType si renseigné
            if (pParam.TemplateId != 0)
                lTypeSelected = lTypeSelected.Where(p => p.TemplateId == pParam.TemplateId).ToList();

            //tbh - retourne la liste
            return lTypeSelected;
        }

        /// <summary>
        /// Méthode qui permet de retourner une liste de Time Type
        /// </summary>
        /// <param name="pParam">param</param>
        /// <returns>Liste de projets DTO</returns>
        /// <remarks>TBH 09-11-2015 Création</remarks>
        public ObservableCollection<TimeTypeDTO> GetListeTimeType(CritereTimeTypeDTO pParam)
        {
            return FormatTimeTypeToDTO(GetListeTypeDto(pParam));
        }


        /// <summary>
        /// Méthode de convertion des componentdto de gemini en IssueTypeDto de l'application
        /// </summary>
        /// <param name="pIssueProjetDto">Liste de composants Issue Type de gemini</param>
        /// <returns>Liste de TimeTypeDTO objets</returns>
        /// <remarks>TBH 09-11-2015 Création</remarks>
        private ObservableCollection<TimeTypeDTO> FormatTimeTypeToDTO(List<TimeType> pIssueProjetDto)
        {
            //tbh- on retourne une liste de TimeTypeDTO
            return new ObservableCollection<TimeTypeDTO>(pIssueProjetDto
                    .Select(p => new TimeTypeDTO()
                    {
                        //tbh- affectation des différentes valeurs
                        IdTimeType = p.Id,
                        NomTimeType = p.Label,
                        DescriptionTimeType = p.Description,
                        TemplateId = p.TemplateId
                    }));
        }

        #endregion
    }
}
