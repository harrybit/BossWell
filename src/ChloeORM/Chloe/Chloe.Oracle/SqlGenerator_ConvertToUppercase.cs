namespace Chloe.Oracle
{
    internal class SqlGenerator_ConvertToUppercase : SqlGenerator
    {
        protected override void QuoteName(string name)
        {
            base.QuoteName(name.ToUpper());
        }
    }
}