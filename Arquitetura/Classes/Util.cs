
namespace Arquitetura.Classes
{
    public class Util
    {

        public static readonly string timeStampSystemUp = DateTime.Now.ToString("yyyyMMddHHmmssffff");

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

    }
}