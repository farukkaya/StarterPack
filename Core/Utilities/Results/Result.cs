namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        private ResultType uSER_MAX_SESSION_LIMIT;

        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(ResultType _resultType)
        {
            ResultType = _resultType;
            this.Message = ResultMessage(ResultType);
        }

        public bool Success { get; }
        public ResultType ResultType { get; }
        public string Message { get; }



        public static string ResultMessage(ResultType resultType)
        {

            string ret = "";
            switch (resultType)
            {
                case ResultType.SUCCESS:
                    ret = "SUCCESS.";
                    break;
                case ResultType.NOT_AUTHENTICATED:
                    break;
                case ResultType.NOT_AUTHORISED:
                    break;
                case ResultType.AUTHORISED:
                    break;
                case ResultType.USER_MAX_SESSION_LIMIT:
                    ret = "You have exceeded the number of sessions, please close your sessions.";
                    break;
                case ResultType.ERROR:
                    break;
                case ResultType.NOT_FOUND:
                    ret = "Data not found.";
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
