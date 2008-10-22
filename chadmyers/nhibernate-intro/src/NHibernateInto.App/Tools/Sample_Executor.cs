using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernateIntro.Core.Domain;
using Environment=System.Environment;

namespace NHibernateInto.App
{
    public static class Sample_Executor
    {
        public static void Execute()
        {
            while (true)
            {
                int sampleToRun = PromptForSampleToRun();

                RunSample(sampleToRun);
            }
        }

        private static void RunSample(int sampleToRun)
        {
            var cfg = new Configuration();
            cfg.AddAssembly(typeof(Customer).Assembly);

            using (ISessionFactory factory = cfg.BuildSessionFactory())
            {
                DatabaseCleaner.ClearDatabase(cfg, factory);

                switch (sampleToRun)
                {
                    case 1:
                        Save_Load_and_Delete_Example.Run(factory);
                        break;
                    case 2:
                        Save_MTO_And_Lazy_Load_Example.Run(factory);
                        break;
                    case 3:
                        CRUD_with_Collections.Run(factory);
                        break;
                    case 4:
                        Querying_Examples.Run(factory);
                        break;
                    default:
                        Console.WriteLine("Unknown sample {0}. Please try another", sampleToRun);
                        break;
                }
            }
        }

        private static int PromptForSampleToRun()
        {
            Console.WriteLine("Please select a sample to run:");
            Console.WriteLine();
            Console.WriteLine("[1] Simple save, load, and delete");
            Console.WriteLine();
            Console.WriteLine("[2] MTO relationship and lazy loading");
            Console.WriteLine();
            Console.WriteLine("[3] CRUD with OTM bag collection");
            Console.WriteLine();
            Console.WriteLine("[4] Querying");
            Console.WriteLine();
            Console.WriteLine("[q] to quit");
            Console.WriteLine();
            Console.Write("Selection> ");
            string result = Console.ReadLine();


            if( result.ToLower() == "q")
            {
                Environment.Exit(0);
            }

            int selection = 0;

            int.TryParse(result, out selection);

            return selection;
        }
    }
}