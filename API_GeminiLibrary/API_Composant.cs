using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Countersoft.Gemini.Commons.Dto;
using DTOLibrary.Entities.Composant;
using DTOLibrary.Entities.Projet;

namespace API_GeminiLibrary
{
    public partial class CServiceGemini
    {
        #region METHODES / FONCTIONS

        /// <summary>
        /// Fonction permettant de récupérer la liste des composants Gemini
        /// </summary>
        /// <returns>Identifiant de l'utilisateur</returns>
        /// <remarks>JClaud 2015-07-27 - Création</remarks>
        private List<ComponentDto> GetListeProjectDto(CritereComposantDTO pParam)
        {
            //jc- déclaration de variables
            List<ComponentDto> lTypeSelected;

            //jc - Retourne la liste de ComposantDto
            lTypeSelected = LanceAuthentification(pParam.User).Projects.GetComponents(pParam.IdProjet);

            //jc- restriction sur le nom du composant si renseigné
            if (pParam.NomComposant != "" && pParam.NomComposant != null)
                lTypeSelected = lTypeSelected.Where(p => p.Entity.Name == pParam.NomComposant).ToList();

            //jc - retourne la liste
            return lTypeSelected;
        }

        /// <summary>
        /// Méthode qui permet de retourner une liste de composants
        /// </summary>
        /// <param name="pParam">param</param>
        /// <returns>Liste de projets DTO</returns>
        /// <remarks>JClaud 2015-07-27 Création</remarks>
        public ObservableCollection<ComposantDTO> GetListeComposant(CritereComposantDTO pParam)
        {
            return FormatComposantToDTO(GetListeProjectDto(pParam));
        }

        /// <summary>
        /// Méthode de convertion des componentdto de gemini en ComposantDTO de l'application
        /// </summary>
        /// <param name="pIssueProjetDto">Liste de composants issue de gemini</param>
        /// <returns>Liste de ComposanttDTO objets</returns>
        /// <remarks>JClaud 2015-07-27 Création</remarks>
        private ObservableCollection<ComposantDTO> FormatComposantToDTO(List<ComponentDto> pIssueProjetDto)
        {
            //jc- on retourne une liste de ProjetDTO
            return new ObservableCollection<ComposantDTO>(pIssueProjetDto
                    .Select(p => new ComposantDTO()
                    {
                        //jc- affectation des différentes valeurs
                        IdComposant = p.Entity.Id,
                         IdProjet = p.Entity.ProjectId,
                         NomComposant = p.Entity.Name,
                         DescrComposant = p.Entity.Description,
                         IsComposantReadOnly = p.Entity.ReadOnly
                    }));
        }

        #endregion
    }
}
