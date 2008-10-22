using System;

namespace NHibernateInto.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TryWithCatch(() =>
            {
                Sample_Executor.Execute();
            });

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Paused. Press ENTER key to continue");
            Console.ReadLine();
        }

        #region TryWithCatch()

        private static void TryWithCatch(Action safeAction)
        {
            try
            {
                safeAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion
    }
}