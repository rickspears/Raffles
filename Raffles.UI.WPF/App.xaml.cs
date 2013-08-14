using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Raffles.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e) {
            //System.Reflection.Context assembly required
            //RegistrationBuilder builder = new RegistrationBuilder();
            //builder.ForTypesDerivedFrom<IRepositoryProvider>()
            //    .Export<IRepositoryProvider>()
            //    .SelectConstructor(cinfo => cinfo[0]);
            //builder.ForTypesDerivedFrom<IUnitOfWork>()
            //    .Export<IUnitOfWork>()
            //    .SelectConstructor(cinfo => cinfo[0]);
        }
    }
}
