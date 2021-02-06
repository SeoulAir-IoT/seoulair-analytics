namespace SeoulAir.Analytics.Domain.Resources
{
    public static class Strings
    {
        #region Errors and warnings messages
        
        public const string ParameterNullOrEmptyMessage = "Parameter {0} must not be null or empty string.";
        public const string ParameterBetweenMessage = "Value of parameter {0} must be between {1} and {2}.";
        public const string PaginationOrderError = "Pagination error. Invalid \"Order By\" option: {0}";
        public const string PaginationFilterError = "Pagination error. Invalid \"Filter by\" option: {0}";

        #endregion
    }
}