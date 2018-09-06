namespace Chloe.Query.QueryExpressions
{
    internal enum QueryExpressionType
    {
        Root = 1,
        Where,
        Take,
        Skip,
        OrderBy,
        OrderByDesc,
        ThenBy,
        ThenByDesc,
        Select,
        Include,
        Aggregate,
        JoinQuery,
        GroupingQuery,
        Distinct,
    }
}