using System.Data.Entity.ModelConfiguration.Configuration;

namespace WS_Hotline.Framework.AccesDonnees
{
    /// <summary>
    /// Interface to regitrar all configuration in entity
    /// </summary>
    public interface IEntityConfiguration
    {
        void Add(ConfigurationRegistrar pRegistrar);
    }
}
