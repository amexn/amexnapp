
namespace Track.Core.Helpers
{

    public static class UserDefinedPageSize
    {

        public static int TestPageSize = 2;
        public static int DefaultPageSize = 10;
      

    }
    
    
    #region Enumerators
    public enum MessageType
    {
        Info = 1,//light blue
        Warning = 2,//yellow
        Success = 3,//green
        Error = 4//red


    };
   

    public enum SortOrder
    {
        Ascending = 1,
        Descending = 2
    }

    public enum UserStatus
    {
        Active = 1,
        Deactive = 2,
        Hide = 3
    }
    

    public enum UserType
    {

        Admin = 1,
        User = 2
        

    }




    
    
    
   
    public enum JsonRequestResult
    {
        Success = 1,
        Failure = 2,
        DuplicationError = 3,
        NullOrEmptyValueError = 4

    }
    #endregion
    
}
