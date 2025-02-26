using System.Reflection;

namespace LazyDI.Core
{
    public static class AssemblyLoader
    {
        private static HashSet<string> _loadedAssemblies = new HashSet<string>();

        public static Assembly[] GetApplicationAssemblies()
        {
            //var entryAssembly = Assembly.GetEntryAssembly();
            //LoadReferencedAssemblies(entryAssembly);

            //var solutionName = "LazyDI"; // Nome da sua solução

            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            //var myAssemblies = assemblies
            //    .Where(assembly => assembly.FullName.Contains(solutionName))
            //    .ToList();


            //return AppDomain.CurrentDomain.GetAssemblies()
            //    .Where(assembly => _loadedAssemblies.Contains(assembly.FullName))
            //    .ToArray();

            var assembly = Assembly.Load("LazyDI.Test.Infra");

            // Adiciona o assembly carregado à lista de assemblies
            return AppDomain.CurrentDomain.GetAssemblies().Concat(new[] { assembly }).ToArray();
        }

        private static void LoadReferencedAssemblies(Assembly assembly)
        {
            // Verifica se o assembly já foi carregado
            if (_loadedAssemblies.Contains(assembly.FullName))
                return;

            // Adiciona o assembly à lista de carregados
            _loadedAssemblies.Add(assembly.FullName);

            var tete = assembly.GetReferencedAssemblies();

            // Carrega os assemblies referenciados
            foreach (var assemblyName in assembly.GetReferencedAssemblies())
            {
                try
                {
                    var referencedAssembly = Assembly.Load(assemblyName);
                    LoadReferencedAssemblies(referencedAssembly); // Recursão
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load assembly {assemblyName}: {ex.Message}");
                }
            }
        }
    }
}
