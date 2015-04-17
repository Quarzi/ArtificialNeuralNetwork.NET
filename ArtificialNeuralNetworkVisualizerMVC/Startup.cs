using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtificialNeuralNetworkVisualizerMVC.Startup))]
namespace ArtificialNeuralNetworkVisualizerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
