namespace SchoolRegister.Core.Domain
{
    public static class ErrorCodes
    {
        //invalid
        public static string InvalidEmail => "invalid_email";
        public static string InvalidPassword => "invalid_password";
        public static string InvalidRole => "invalid_role";
        public static string InvalidUsername => "invalid_username";
        //subject
        public static string SubjectAlreadyAdded = "subject_already_added_for_student";
        public static string SubjectNotFound  = "subject_was_not_found";
        //student
        public static string StudentAlreadyAdded  = "studentt_already_added_for_group";
        public static string StudentNotFound  = "student_was_not_found";
        public static string StudentWithoutGroup = "student_without_group";
        

        
    }
}