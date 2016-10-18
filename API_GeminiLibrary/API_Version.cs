using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Countersoft.Gemini.Commons.Dto;
using DTOLibrary.Entities.Projet;
using DTOLibrary.Entities.Version;

namespace API_GeminiLibrary
{
    public partial class CServiceGemini
    {
        #region METHODES / FONCTIONS

        /// <summary>
        /// Fonction permettant de récupérer la liste des versions Gemini
        /// </summary>
        /// <remarks>JClaud 2015-07-21 - Création</remarks>
        private List<VersionDto> GetListeVersionDto(CritereVersionDTO pParam)
        {
            //jc- déclaration de variables
            List<VersionDto> lTypeSelected = new List<VersionDto>();

            if (pParam.IdVersion != 0)
                //jc- retourne le projetDto correspondant à l'ID
                lTypeSelected.Add(LanceAuthentification(CopyUserAsAPI(pParam.User)).Projects.GetVersion(pParam.Ticket.Projet.IdProjet, pParam.IdVersion));
            else
                //jc - Retourne la liste de ProjetDto
                lTypeSelected = LanceAuthentification(CopyUserAsAPI(pParam.User)).Projects.GetVersions(pParam.Ticket.Projet.IdProjet);

            //jc- restriction sur le nom si renseigné
            if (pParam.VersionName != null && pParam.VersionName != "")
                lTypeSelected = lTypeSelected.Where(p => p.Entity.Name == pParam.VersionName).ToList();

            //jc - retourne la liste des IssueStatusDto
            return lTypeSelected;
        }

        /// <summary>
        /// Méthode qui permet de retourner une liste de projets
        /// </summary>
        /// <param name="pParam">param</param>
        /// <returns>Liste de projets DTO</returns>
        /// <remarks>JClaud 2015-07-21 Création</remarks>
        public ObservableCollection<VersionDTO> GetListeVersion(CritereVersionDTO pParam)
        {
            return FormatVersionToDTO(GetListeVersionDto(pParam));
        }

        /// <summary>
        /// Méthode de convertion des projetdto de gemini en VersionDTO de l'application
        /// </summary>
        /// <param name="pIssueProjetDto">Liste de versions issue de gemini</param>
        /// <returns>Liste de VersionDTO objets</returns>
        /// <remarks>JClaud 2015-07-21 Création</remarks>
        private ObservableCollection<VersionDTO> FormatVersionToDTO(List<VersionDto> pVersionDto)
        {
            //jc- on retourne une liste de VersionDTO
            return new ObservableCollection<VersionDTO>(pVersionDto
                    .Select(p => new VersionDTO()
                    {
                        //jc- affectation des différentes valeurs
                        IdVersion = p.Entity.Id,
                        VersionName = p.Entity.Name,
                        VersionNumber = p.Entity.Label,
                        VersionDescr = "",
                        IdProjet = p.Project.Entity.Id
                    }));
        }

        #endregion
    }
}
