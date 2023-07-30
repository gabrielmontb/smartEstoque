
using Npgsql;
using SmartEstoque.Business;
using SmartEstoque.Class;
using SmartEstoque.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Arquitetura.Classes
{
    internal static class Util
    {

        public static readonly string timeStampSystemUp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        public static AppSettings AppSettings { get; private set; }
        private static void LoadAppSettings()
        {
            if (AppSettings == null)
            {
                using StreamReader reader = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"));
                AppSettings = JsonSerializer.Deserialize<AppSettings>(reader.ReadToEnd());
            }
        }
        static Util()
        {
            // Carregando configurações.
            LoadAppSettings();
        }

        private static Thread _memoryManagementThread;

        public static bool memoryManagementThread
        {
            get
            {
                if (_memoryManagementThread == null)
                {
                    _memoryManagementThread = new Thread(async () =>
                    {
                        while (true)
                        {
                            await Task.Delay(1000 * 60);
                            try
                            {
                                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                                GC.WaitForFullGCComplete();
                                GC.WaitForFullGCApproach();
                                GC.WaitForPendingFinalizers();
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    });
                    _memoryManagementThread.Start();
                }
                return true;
            }
        }
        public static void CriaLogErro(Exception ex, string Metodo = "", string classe = "", string Param = "")
        {
            string description = "ERRO:" + Metodo + ": " + Environment.NewLine + Environment.NewLine
             + " //PARÂMETRO: " + Param +
             "Verifique a mensagem de erro a seguir para solucionar o problema." + Environment.NewLine +
             Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Metodo: " +
             ex.TargetSite.DeclaringType.FullName + ex.TargetSite.Name + Environment.NewLine + Environment.NewLine + "Origem: " +
             ex.Source + Environment.NewLine + Environment.NewLine + "Pilha de execução: " + ex.StackTrace;

            using var conn = new DbConnection().Connection;
            string query = @"INSERT INTO cadlogsis (codlog,desclalog,desmetlog,deslog) 
                                    VALUES (
                                            (SELECT COALESCE(MAX(codlog),0)+1 FROM cadlogsis)
                                            ,@desclalog
                                            ,@desmetlog
                                            ,@deslog
                                            )
                                ";
            var command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@desclalog", classe);
            command.Parameters.AddWithValue("@desmetlog", Metodo);
            command.Parameters.AddWithValue("@desmetlog", description);
        }

    }
}