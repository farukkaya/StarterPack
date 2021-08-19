namespace Core.Utilities.Results
{
    public enum ResultType
    {
        SUCCESS = 200,
        FORBIDDEN = 403,
        BAD_REQUEST = 400,
        NOT_FOUND = 404,
        NOT_AUTHENTICATED = 601,
        NOT_AUTHORISED = 602,
        AUTHORISED = 603,
        USER_MAX_SESSION_LIMIT = 604,
        ERROR = 999
    }
}