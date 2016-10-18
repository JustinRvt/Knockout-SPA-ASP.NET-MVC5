using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Countersoft.Gemini.Commons.Dto;
using DTOLibrary.Entities.Projet;
using DTOLibrary.Entities.Projet.Methodes;

namespace API_GeminiLibrary
{
    public partial class CServiceGemini
    {
        #region METHODES / FONCTIONS
        
        /// <summary>
        /// Fonction permettant de récupérer la liste des projects Gemini
        /// </summary>
        /// <returns>Identifiant de l'utilisateur</returns>
        /// <remarks>JClaud 2015-03-12 - Création</remarks>
        private List<ProjectDto> GetListeProjectDto(CritereProjetDTO pParam)
        {
            //jc- déclaration de variables
            List<ProjectDto> lTypeSelected;

            //jc - Retourne la liste de ProjetDto
            lTypeSelected = LanceAuthentification(pParam.User).Projects.GetProjects().ToList();

            //jc- restriction sur le template id s'il est indiqué
            if(pParam.TemplateId != 0)
                lTypeSelected = lTypeSelected.Where(p => p.Template.Id == pParam.TemplateId).ToList();
            
            //jc - retourne la liste des IssueStatusDto
            return lTypeSelected;
        }

        /// <summary>
        /// Méthode qui permet de retourner une liste de projets
        /// </summary>
        /// <param name="pParam">param</param>
        /// <returns>Liste de projets DTO</returns>
        /// <remarks>JClaud 2015-07-21 Création</remarks>
        public ObservableCollection<ProjetDTO> GetListeProjets(CritereProjetDTO pParam)
        {
            return FormatProjetToDTO(GetListeProjectDto(pParam));
        }

        /// <summary>
        /// Méthode de convertion des projetdto de gemini en ProjetDTO de l'application
        /// </summary>
        /// <param name="pIssueProjetDto">Liste de projet issue de gemini</param>
        /// <returns>Liste de projetDTO objets</returns>
        /// <remarks>JClaud 2015-07-21 Création</remarks>
        private ObservableCollection<ProjetDTO> FormatProjetToDTO(List<ProjectDto> pIssueProjetDto)
        {
            //jc- on retourne une liste de ProjetDTO
            return new ObservableCollection<ProjetDTO>(pIssueProjetDto
                    .Select(p => new ProjetDTO()
                    {
                        //jc- affectation des différentes valeurs
                        CodeProjet = p.Entity.Code,
                        DescrProjet = p.Entity.Description,
                        IdProjet = p.Entity.Id,
                        LibelleProjet = p.Entity.Name,
                        TemplateId = p.Template.Id
                    }));
        }

        #endregion
    }
}
