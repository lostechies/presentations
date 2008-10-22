namespace NHibernateIntro.Core.Domain
{
    public class Store
    {
        public virtual int StoreID { get; set; }
        public virtual string Name { get; set; }
        public virtual string AccountingCode { get; set; }

        public override string ToString()
        {
            return string.Format("Store ({0}):\n\t{1}\n\t(Code: {2})",
                                 StoreID, Name, AccountingCode);
        }
    }
}